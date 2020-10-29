using System;
using System.Linq;
using ADALotto.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Threading;

namespace ADALotto.Views
{
    public class MainWindow : Window
    {
        private TextBox[]? LottoBoxes { get; set; }
        public MainWindowViewModel? ViewModel
        {
            get
            {
                return this.DataContext as MainWindowViewModel;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Opened += OnOpened;
        }

        private async void OnOpened(object? sender, EventArgs e)
        {
            if (ViewModel != null)
            {
                // ViewModel.Digits = 6;
                // GenerateLottoBoxes();
                // ViewModel.NewWalletRequest += OnNewWalletRequest;
                // ViewModel.TicketBuyComplete += OnTicketBuyCompleted;
                // await ViewModel.InitializeCardanoNodeAsync();

				await Dispatcher.UIThread.InvokeAsync(async () =>
				{
					var buyConfirmWindow = new BuyConfirmWindow();
					await buyConfirmWindow.ShowDialog(this);
				});
            }
        }

        private void OnTicketBuyCompleted(object? sender, EventArgs e) => LottoBoxes.ToList().ForEach(lb => lb.Text = string.Empty);

        private void OnNewWalletRequest(object? sender, EventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(async () =>
            {
                var newPassWindow = new NewPassphraseWindow();
                await newPassWindow.ShowDialog(this);
                ViewModel?.GenerateWalletWithPass(newPassWindow.Passphrase);
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
                newLottoBox.Watermark = "00";
                newLottoBox.Width = 43;
                newLottoBox.FontSize = 30;
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
    }
}