using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ADALotto.Views
{
    public class WithdrawConfirmWindow : Window
    {
        public long Amount { get; set; }
        public long Fee { get; set; }
        public string WalletAddress { get; private set; } = string.Empty;
        public string Passphrase { get; private set; } = string.Empty;
        public bool IsConfirmed { get; private set; } = false;

        public WithdrawConfirmWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.Opened += OnWindowOpened;
        }

        private void OnWindowOpened(object? sender, EventArgs e)
        {
            this.Find<TextBlock>("lblAmount").Text = Math.Round((double)Amount / 1000000, 6).ToString("#,0.000000");
            this.Find<TextBlock>("lblFee").Text = Math.Round((double)Fee / 1000000, 6).ToString("#,0.000000");
        }

        public void ConfirmWithdraw(object sender, RoutedEventArgs e)
        {
            IsConfirmed = true;
			WalletAddress = this.Find<TextBox>("txtWalletAddress").Text;
			Passphrase = this.Find<TextBox>("txtPassphrase").Text;
            this.Close();
        }

        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}