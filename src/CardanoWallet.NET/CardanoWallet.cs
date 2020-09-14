using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SAIB.CardanoWallet.NET.Models;

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
        public string Id { get; private set; }
        public string Name { get; private set; }
        private string[] _mnemonics { get; set; }
        private string _passphrase { get; set; }
        public WalletBalance Balance { get; private set; } = new WalletBalance();
        public WalletState State { get; private set; } = new WalletState();
        public Tip Tip { get; private set; } = new Tip();

        public CardanoWallet(string id, string passphase)
        {
            Id = id;
            _passphrase = passphase;
            _mnemonics = new string[0];
            Name = string.Empty;
        }

        public async Task RefreshAsync()
        {
            var walletResponse = await CardanoWalletAPI.GetWalletAsync(Id);
            Balance = walletResponse.Balance ?? Balance;
            Name = walletResponse.Name;
            State = walletResponse.State ?? State;
            Tip = walletResponse.Tip ?? Tip;
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
