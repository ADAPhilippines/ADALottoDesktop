using System;
using System.Linq;
using ADALotto.Events;
using ADALotto.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Threading;
using SAIB.CardanoWallet.NET;

namespace ADALotto.Views
{
    public class MainWindow : FluentWindow
    {
        private TextBox[]? LottoBoxes { get; set; }
        private MessageBox? LoadingBox { get; set; }
        public MainWindowViewModel? ViewModel
        {
            get
            {
                return this.DataContext as MainWindowViewModel;
            }
        }
        public MainWindow()
        {
            LoadingBox = new MessageBox();
            InitializeComponent();
            Opened += OnOpened;
        }

        private async void OnOpened(object? sender, EventArgs e)
        {
            if (ViewModel != null)
            {
                ViewModel.Digits = 6;
                GenerateLottoBoxes();
                ViewModel.NewWalletRequest += OnNewWalletRequest;
                ViewModel.TicketBuyComplete += OnTicketBuyCompleted;
                ViewModel.BuyRequest += OnTicketBuyRequest;
                ViewModel.WithdrawalRequest += OnWithdrawalRequest;
                ViewModel.TransactionFail += OnTransactionFailed;
                ViewModel.LoadingStartRequest += OnLoadingStartRequest;
                ViewModel.LoadingEndRequest += OnLoadingEndRequest;
                await ViewModel.InitializeCardanoNodeAsync();
            }
        }

        private void OnLoadingEndRequest(object? sender, EventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
           {
               if (LoadingBox != null)
               {
                   LoadingBox.IsClosePrevented = false;
                   LoadingBox.Close();
               }
           });
        }

        private void OnLoadingStartRequest(object? sender, LoadingStartEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                LoadingBox = new MessageBox
                {
                    Title = "Loading",
                    Message = e.Message,
                    ButtonLabel = "Ok",
                    IsClosePrevented = true
                };
                LoadingBox.ShowDialog(this);
            });
        }

        private void OnTransactionFailed(object? sender, EventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                MessageBox.Show("Error", "Transaction failed, try again in a bit...", "Ok", this);
            });
        }

        private void OnWithdrawalRequest(object? sender, ConfirmWithdrawalEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(async () =>
            {
                var confirmWithdrawWindow = new WithdrawConfirmWindow
                {
                    Amount = e.Amount,
                    Fee = e.Fee
                };
                await confirmWithdrawWindow.ShowDialog(this);

                if (confirmWithdrawWindow.IsConfirmed)
                {
                    ViewModel?.Withdraw(confirmWithdrawWindow.WalletAddress, confirmWithdrawWindow.Passphrase);
                }
            });
        }

        private void OnTicketBuyRequest(object? sender, ConfirmBuyTicketEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(async () =>
            {
                var buyConfirmWindow = new BuyConfirmWindow
                {
                    Combination = e.Combination,
                    Fee = e.Fee,
                    Price = e.Price
                };
                await buyConfirmWindow.ShowDialog(this);
                if (buyConfirmWindow.IsConfirmed)
                {
                    ViewModel?.BuyTicket(buyConfirmWindow.Passphrase);
                }
            });
        }

        private void OnTicketBuyCompleted(object? sender, EventArgs e) => LottoBoxes.ToList().ForEach(lb => lb.Text = string.Empty);

        private void OnNewWalletRequest(object? sender, EventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(async () =>
            {
                var mnemonics = await CardanoWalletAPI.GenerateMnemonicsAsync();
                var newPassWindow = new NewPassphraseWindow
                {
                    Mnemonics = mnemonics
                };
                await newPassWindow.ShowDialog(this);
                ViewModel?.GenerateWalletWithPass(newPassWindow.Passphrase, mnemonics);
            });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Code to Generate Lotto Boxes Dynamically
        /// </summary>
        private void GenerateLottoBoxes()
        {
            var digits = ViewModel?.Digits ?? 0;

            LottoBoxes = new TextBox[digits];
            var panelLottoNumbers = this.FindControl<StackPanel>("panelLottoNumbers");
            panelLottoNumbers.Children.Clear();

            for (int x = 0; x < digits; x++)
            {
                var newLottoBox = new TextBox();
                newLottoBox.Classes.Add("lottobox");
                newLottoBox.Watermark = "??";
                newLottoBox.TextAlignment = TextAlignment.Center;
                newLottoBox.KeyUp += OnLottNumberInput;
                newLottoBox.Tag = x;
                panelLottoNumbers.Children.Add(newLottoBox);
                LottoBoxes[x] = newLottoBox;
            }
        }

        private void OnLottNumberInput(object? sender, KeyEventArgs e)
        {
            var textBox = (sender as TextBox);
            var tag = textBox?.Tag.ToString();
            var numberIdx = -1;

            if (tag != null)
            {
                numberIdx = int.Parse(tag);
            }

            if (textBox != null && textBox.Text != null)
            {
                if (textBox.Text.Length >= 2 && numberIdx < ViewModel?.Digits - 1)
                {
                    if (LottoBoxes != null)
                    {
                        LottoBoxes[numberIdx + 1].Focus();
                        LottoBoxes[numberIdx + 1].SelectionStart = 2;
                        LottoBoxes[numberIdx + 1].SelectionEnd = 2;
                    }
                }

                if (textBox.Text.Length <= 0 && e.Key == Key.Back && numberIdx > 0)
                {
                    if (LottoBoxes != null)
                    {
                        LottoBoxes[numberIdx - 1].Focus();
                        LottoBoxes[numberIdx - 1].SelectionStart = 2;
                        LottoBoxes[numberIdx - 1].SelectionEnd = 2;
                    }
                }

                if (textBox.Text.Length > 2 && e.Key != Key.Back)
                {
                    textBox.Text = textBox.Text.Substring(0, 2);
                }

                if (ViewModel != null && ViewModel.Combination != null)
                {
                    var isValid = int.TryParse(textBox.Text, out var n);
                    if (isValid)
                    {
                        ViewModel.Combination[numberIdx] = n;
                    }
                    else
                    {
                        textBox.Text = string.Empty;
                    }
                }
            }
            else if (textBox?.Text == null && e.Key == Key.Back && LottoBoxes != null)
            {
                LottoBoxes[numberIdx - 1].Focus();
                LottoBoxes[numberIdx - 1].SelectionStart = 2;
                LottoBoxes[numberIdx - 1].SelectionEnd = 2;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            ViewModel?.StopNode();
            base.OnClosing(e);
        }

        public void ShutdownApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}