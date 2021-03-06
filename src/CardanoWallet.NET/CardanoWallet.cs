﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAIB.CardanoWallet.NET.Models;
using SAIB.CardanoWallet.NET.Models.Responses;

namespace SAIB.CardanoWallet.NET
{
    public enum WalletStyle
    {
        Unknown,
        Random,
        Icarus,
        Trezor,
        Ledeger
    }

    public enum WalletStatus
    {
        Unknown,
        Ready,
        Syncing
    }

    public enum WalletAddressState
    {
        Unknown,
        Used,
        Unused
    }

    public class CardanoWallet
    {
        public string Id { get; private set; } = string.Empty;
        public string Name { get; private set; }
        private string[]? _mnemonics { get; set; }
        private string _passphrase { get; set; } = string.Empty;
        public WalletBalance Balance { get; private set; } = new WalletBalance();
        public WalletState State { get; private set; } = new WalletState();
        public Tip Tip { get; private set; } = new Tip();
        public IEnumerable<WalletAddress>? Addresses { get; private set; }
        #region Events
        public event EventHandler? WalletRestoring;
        #endregion

        #region Constructors
        /// <summary>
        /// Generates a new Cardano Wallet with a random 24-word recovery phrase
        /// </summary>
        /// <param name="name"></param>
        /// <param name="passphrase"></param>
        public CardanoWallet(string name, string passphrase)
        {
            Name = name;
            _passphrase = passphrase;
            GenerateWallet();
        }

        public CardanoWallet(string name, string passphrase, string[] mnemonics)
        {
            Name = name;
            _passphrase = passphrase;
            _mnemonics = mnemonics;
            GenerateWallet();
        }

        public CardanoWallet(string id, string name, string passphase)
        {
            Id = id;
            Name = name;
            _passphrase = passphase;
        }

        public CardanoWallet(WalletResponse walletData)
        {
            Id = walletData.Id;
            Name = walletData.Name;
        }
        #endregion

        #region Private Methods
        private async void GenerateWallet()
        {
            if (_mnemonics == null)
                _mnemonics = await CardanoWalletAPI.GenerateMnemonicsAsync();
            Id = await CardanoWalletAPI.RestoreWalletAsync(Name, _mnemonics, _passphrase);
            WalletRestoring?.Invoke(this, new EventArgs());
        }
        #endregion

        public async Task RefreshAsync()
        {
            var walletResponse = await CardanoWalletAPI.GetWalletsByIdAsync(Id);
            await RefreshAsync(walletResponse);
        }

        private async Task RefreshAsync(WalletResponse walletResponse)
        {
            Balance = walletResponse.Balance ?? Balance;
            Name = walletResponse.Name;
            State = walletResponse.State ?? State;
            Tip = walletResponse.Tip ?? Tip;
            Addresses = await CardanoWalletAPI.GetWalletAddressesAsync(Id);
        }

        public async Task<string> GenerateAddressAsync(long? index = null)
        {
            var result = await CardanoWalletAPI.GenerateAddressByWalletIdAsync(Id, _passphrase, index);
            return result;
        }

        public async Task<long> EstimateFee(long lovelaceAmount, string address, object? metadata = null)
        {
            var selfAddress = Addresses.First().Id;
            if (Balance != null && Balance.Total != null && selfAddress != null)
            {
                var payments = new List<Payment>() {
                    new Payment
                    {
                        Amount = new BalanceData
                        {
                            Quantity = lovelaceAmount,
                            Unit = BalanceUnit.Lovelace
                        },
                        Address = address
                    },
                    new Payment
                    {
                        Amount = new BalanceData
                        {
                            Quantity = Balance.Total.Quantity - lovelaceAmount,
                            Unit = BalanceUnit.Lovelace
                        },
                        Address = selfAddress
                    }
                };
                return await CardanoWalletAPI.EstimateTransactionFeeAsync(Id, payments, metadata);
            }
            throw new Exception("Estimate failed.");
        }

        public async Task<string?> SendAsync(long lovelaceAmount, string address, string passphrase, object? metadata = null)
        {
            var selfAddress = Addresses.First().Id;
            if (Balance != null && Balance.Total != null && selfAddress != null)
            {
                await RefreshAsync();
                var payments = new List<Payment>();
                if (Balance.Total.Quantity == lovelaceAmount)
                {
                    payments.Add(new Payment
                    {
                        Amount = new BalanceData
                        {
                            Quantity = lovelaceAmount,
                            Unit = BalanceUnit.Lovelace
                        },
                        Address = address
                    });

                    // First Fee Estimate
                    var fee = await CardanoWalletAPI.EstimateTransactionFeeAsync(Id, payments, metadata);

                    var selfPayment = payments[0];
                    if (selfPayment != null && selfPayment.Amount != null)
                        selfPayment.Amount.Quantity = selfPayment.Amount.Quantity - fee;

                    // Second Fee Estimate
                    // @TODO wtf am I doing

                    fee = await CardanoWalletAPI.EstimateTransactionFeeAsync(Id, payments, metadata);

                    if (selfPayment != null && selfPayment.Amount != null)
                        selfPayment.Amount.Quantity = Balance.Total.Quantity - fee;

                    return await CardanoWalletAPI.CreateTransactionAsync(Id, passphrase, payments, metadata);
                }
                else
                {
                    payments.Add(new Payment
                    {
                        Amount = new BalanceData
                        {
                            Quantity = lovelaceAmount,
                            Unit = BalanceUnit.Lovelace
                        },
                        Address = address
                    });
                    payments.Add(new Payment
                    {
                        Amount = new BalanceData
                        {
                            Quantity = Balance.Total.Quantity - lovelaceAmount,
                            Unit = BalanceUnit.Lovelace
                        },
                        Address = selfAddress
                    });
                    
                    // First Fee Estimate
                    var fee = await CardanoWalletAPI.EstimateTransactionFeeAsync(Id, payments, metadata);

                    var selfPayment = payments[1];
                    if (selfPayment != null && selfPayment.Amount != null)
                        selfPayment.Amount.Quantity = selfPayment.Amount.Quantity - fee;

                    // Second Fee Estimate
                    // @TODO wtf am I doing

                    fee = await CardanoWalletAPI.EstimateTransactionFeeAsync(Id, payments, metadata);

                    if (selfPayment != null && selfPayment.Amount != null)
                        selfPayment.Amount.Quantity = selfPayment.Amount.Quantity - fee;

                    return await CardanoWalletAPI.CreateTransactionAsync(Id, passphrase, payments, metadata);
                }
            }
            throw new Exception("Transaction failed.");
        }

        public async Task<Transaction?> GetTransactionByIdAsync(string txId)
        {
            return await CardanoWalletAPI.GetTransactionByIdAsync(Id, txId);
        }
    }
}
