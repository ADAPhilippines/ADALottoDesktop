using System;
using System.Diagnostics;
using ADALotto.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Threading;

namespace ADALotto.Views
{
    public class MainWindow : Window
    {
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
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private async void OnOpened(object? sender, EventArgs e)
        {
            GenerateLottoBoxes();
            if (ViewModel != null)
            {
                await ViewModel.InitializeCardanoNodeAsync();
                ViewModel.NewWalletRequest += OnNewWalletRequest;
            }
        }

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
            var panelLottoNumbers = this.FindControl<StackPanel>("panelLottoNumbers");
            panelLottoNumbers.Children.Clear();
            for (int x = 0; x < ViewModel?.Digits; x++)
            {
                var newLottoBox = new TextBox();
                newLottoBox.Watermark = "00";
                newLottoBox.Width = 43;
                newLottoBox.FontSize = 30;
                newLottoBox.TextAlignment = TextAlignment.Center;
                panelLottoNumbers.Children.Add(newLottoBox);
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            ViewModel?.StopNode();
            base.OnClosing(e);
        }
    }
}