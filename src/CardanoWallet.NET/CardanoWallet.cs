using System;
using System.Collections.Generic;
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
        private string[] _mnemonics { get; set; } = new string[24];
        private string _passphrase { get; set; }
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
            _passphrase = string.Empty;
            RefreshAsync(walletData);
        }
        #endregion

        #region Private Methods
        private async void GenerateWallet()
        {
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

        public async Task<bool> SendAsync(long amount, string address)
        {
            await RefreshAsync();
            var payments = new List<Payment>() {
                new Payment
                {
                    Amount = new BalanceData
                    {
                        Quantity = amount,
                        Unit = BalanceUnit.Lovelace
                    },
                    Address = address
                }
            };

            var fee = await CardanoWalletAPI.EstimateTransactionFeeAsync(Id, payments);

            if (fee + amount > Balance?.Available?.Quantity)
                return false;

            return await CardanoWalletAPI.CreateTransactionAsync(Id, _passphrase, payments);
        }
    }
}
