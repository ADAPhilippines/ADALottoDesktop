using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADALotto.Events;
using ADALotto.ViewModels;
using ADALottoModels;
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
        private List<TextBox>? LottoBoxes { get; set; }
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
                LottoBoxes = new List<TextBox>();
                ViewModel.Digits = 6;
                RefreshLottoBoxes();
                ViewModel.NewWalletRequest += OnNewWalletRequest;
                ViewModel.TicketBuyComplete += OnTicketBuyCompleted;
                ViewModel.BuyRequest += OnTicketBuyRequest;
                ViewModel.WithdrawalRequest += OnWithdrawalRequest;
                ViewModel.TransactionFail += OnTransactionFailed;
                ViewModel.LoadingStartRequest += OnLoadingStartRequest;
                ViewModel.LoadingEndRequest += OnLoadingEndRequest;
                ViewModel.DaedalusNotFound += OnDaedalusNotFound;
                ViewModel.GameFetch += OnGameFetched;
                ViewModel.InvalidCombinationRequest += OnInvalidCombinationRequest;
                await ViewModel.InitializeCardanoNodeAsync();
            }
        }

        private void OnInvalidCombinationRequest(object? sender, EventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(async () =>
            {
                await MessageBox.ShowAsync("Error", "Digits must be between 1 - 99...", "Ok", this);
                LottoBoxes?.ForEach(l => l.Text = string.Empty);
            });
        }

        private void OnGameFetched(object? sender, GameFetchEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(async () =>
            {
                if (e.GameState != null)
                {
                    if (ViewModel != null && e.GameState.GameGenesisTxMeta != null)
                        ViewModel.Digits = e.GameState.GameGenesisTxMeta.Digits;
                    RefreshPastCombinations(e.GameState);
                }
                RefreshLottoBoxes(e);
                await RefreshTicketsAsync();
            });
        }

        private async Task RefreshTicketsAsync()
        {
            var spTickets = this.Find<StackPanel>("spTickets");

            if (ViewModel != null && !string.IsNullOrEmpty(ViewModel.WalletAddress) && ViewModel.Game != null)
            {
                var tickets = await ViewModel.Game.GetTicketsByAddressAsync(ViewModel.WalletAddress);
                spTickets.Children.Clear();
                foreach (var txId in tickets.Keys)
                {
                    var grid = new Grid
                    {
                        ColumnDefinitions = new ColumnDefinitions("1*,1*")
                    };

                    var tb1 = new TextBlock
                    {
                        Classes = new Classes("ALResultRow"),
                        TextAlignment = TextAlignment.Center
                    };

                    tb1.Text = $"{txId.Substring(0, 7)}...{txId.Substring(txId.Length - 8, 7)}";

                    var tb2 = new TextBlock
                    {
                        Classes = new Classes("ALResultRow"),
                        TextAlignment = TextAlignment.Center
                    };
                    tb2.Text = tickets[txId];

                    Grid.SetColumn(tb1, 0);
                    Grid.SetColumn(tb2, 1);

                    grid.Children.Add(tb1);
                    grid.Children.Add(tb2);

                    spTickets.Children.Add(grid);
                }
            }
        }

        private void RefreshPastCombinations(ALGameState gameState)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                var spPrevResults = this.Find<StackPanel>("spPrevCombs");
                spPrevResults.Children.Clear();

                if (gameState.PreviousResults != null)
                {
                    foreach (var r in gameState.PreviousResults)
                    {
                        var grid = new Grid
                        {
                            ColumnDefinitions = new ColumnDefinitions("1*,1*,1*")
                        };

                        var tb1 = new TextBlock
                        {
                            Classes = new Classes("ALResultRow"),
                            TextAlignment = TextAlignment.Center
                        };

                        tb1.Text = r.DrawDate.ToString("yyyy-MM-dd");

                        var tb2 = new TextBlock
                        {
                            Classes = new Classes("ALResultRow"),
                            TextAlignment = TextAlignment.Center
                        };
                        tb2.Text = string.Join('-', r.Numbers.Select(n => n.Number));

                        var tb3 = new TextBlock
                        {
                            Classes = new Classes("ALResultRow"),
                            TextAlignment = TextAlignment.Center
                        };
                        tb3.Text = $"₳ {(double)r.Prize / 1000000:N}";

                        grid.Children.Add(tb1);
                        grid.Children.Add(tb2);
                        grid.Children.Add(tb3);

                        Grid.SetColumn(tb1, 0);
                        Grid.SetColumn(tb2, 1);
                        Grid.SetColumn(tb3, 2);

                        spPrevResults.Children.Add(grid);
                    }
                }
            });
        }

        private void OnDaedalusNotFound(object? sender, EventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(async () =>
            {
                await MessageBox.ShowAsync("Error", "Daedalus is required to use ADALotto, please install it and try again...", "Exit", this);
                this.Close();
            });
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
                _ = MessageBox.ShowAsync("Error", "Transaction failed, balance in UTXOs might be to low...", "Ok", this);
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

        private void RefreshLottoBoxes(GameFetchEventArgs? e = null)
        {
            var digits = ViewModel?.Digits ?? 0;
            if (LottoBoxes != null && digits != LottoBoxes.Count)
            {
                var panelLottoNumbers = this.FindControl<StackPanel>("panelLottoNumbers");
                var boxCountDiff = LottoBoxes.Count - digits;

                if (boxCountDiff > 0)
                {
                    for (int x = LottoBoxes.Count - 1; x >= digits; x--)
                    {
                        var box = LottoBoxes[x];
                        LottoBoxes.Remove(box);
                        panelLottoNumbers.Children.Remove(box);
                    }
                }
                else
                {
                    for (int x = LottoBoxes.Count; x < digits; x++)
                    {
                        var newLottoBox = new TextBox();
                        newLottoBox.Classes.Add("lottobox");
                        newLottoBox.Watermark = "??";
                        newLottoBox.TextAlignment = TextAlignment.Center;
                        newLottoBox.KeyUp += OnLottNumberInput;
                        newLottoBox.Tag = x;
                        newLottoBox.IsReadOnly = true;
                        panelLottoNumbers.Children.Add(newLottoBox);
                        LottoBoxes.Add(newLottoBox);
                    }

                    if (e != null && e.GameState != null)
                    {
                        if (e.GameState.PreviousResults == null || e.GameState.PreviousResults.Count() <= 0)
                        {
                            LottoBoxes.ForEach(l => l.IsReadOnly = false);
                        }
                    }
                    else if (e == null)
                    {
                        LottoBoxes.ForEach(l => l.IsReadOnly = false);
                    }

                }
            }

            var combination = e?.Game?.Combination.ToArray();

            var isDrawing = e != null && e.GameState != null && e.GameState.IsDrawing && (ViewModel?.IsInitialGameSyncComplete ?? false) && e.GameState.IsRunning;
            if (isDrawing && LottoBoxes != null && e != null && e.Game != null && ViewModel != null && combination != null)
            {
                ViewModel.Combination = new int[digits];
                for (var x = 0; x < LottoBoxes.Count; x++)
                {
                    var lottoBox = LottoBoxes[x];
                    lottoBox.IsReadOnly = true;
                    lottoBox.Text = x > combination.Length - 1 ? "??" : combination[x].Number;
                }
            }

            if (combination != null && combination.Length == digits && (e?.Game?.IsInitialSyncFinished ?? false))
            {
                _ = Dispatcher.UIThread.InvokeAsync(async () =>
                {
                    LottoBoxes.Last().Text = combination.Last().Number;
                    if (LottoBoxes != null)
                    {
                        await Task.Delay(10 * 1000);
                        foreach (var lottoBox in LottoBoxes)
                        {
                            if (lottoBox.IsReadOnly)
                            {
                                lottoBox.IsReadOnly = false;
                                lottoBox.Text = string.Empty;
                            }
                        }
                        e?.Game?.ClearCombination();
                    }
                });
            }
        }

        private void OnLottNumberInput(object? sender, KeyEventArgs e)
        {
            var textBox = (sender as TextBox);
            e.Handled = textBox != null && (textBox.IsEnabled || textBox.IsReadOnly);

            if (ViewModel != null && ViewModel.Game != null && ViewModel.GameState != null && !ViewModel.GameState.IsDrawing && ViewModel.Game.IsInitialSyncFinished)
            {
                var tag = textBox?.Tag.ToString();
                var numberIdx = -1;

                if (tag != null)
                {
                    numberIdx = int.Parse(tag);
                }

                if (textBox != null && textBox.Text != null)
                {
                    if (LottoBoxes != null && LottoBoxes.Count > 1)
                    {
                        if (textBox.Text.Length >= 2 && numberIdx < ViewModel?.Digits - 1)
                        {
                            LottoBoxes[numberIdx + 1].Focus();
                            LottoBoxes[numberIdx + 1].SelectionStart = 2;
                            LottoBoxes[numberIdx + 1].SelectionEnd = 2;
                        }

                        if (textBox.Text.Length <= 0 && e.Key == Key.Back && numberIdx > 0)
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
                else if (textBox?.Text == null && e.Key == Key.Back && LottoBoxes != null && LottoBoxes.Count > 1 && numberIdx > 0)
                {
                    LottoBoxes[numberIdx - 1].SelectionStart = 2;
                    LottoBoxes[numberIdx - 1].SelectionEnd = 2;
                }
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