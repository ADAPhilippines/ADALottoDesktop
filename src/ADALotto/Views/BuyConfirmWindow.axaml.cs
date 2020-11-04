using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ADALotto.Views
{
    public class BuyConfirmWindow : Window
    {
        public int[]? Combination { get; set; }
        public long Price { get; set; }
        public long Fee { get; set; }
        public bool IsConfirmed { get; private set; } = false;
        public string Passphrase { get; private set; } = string.Empty;

        public BuyConfirmWindow()
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
            this.Find<TextBlock>("lblCombination").Text = string.Join("-", Combination ?? new int[0]);
            this.Find<TextBlock>("lblPrice").Text = Math.Round((double)Price / 1000000, 6).ToString("#,0.000000");
            this.Find<TextBlock>("lblFee").Text = Math.Round((double)Fee / 1000000, 6).ToString("#,0.000000");
            this.Find<TextBlock>("lblTotal").Text = Math.Round(((double)Price + Fee) / 1000000, 6).ToString("#,0.000000");
        }

        public void ConfirmBuy(object sender, RoutedEventArgs e)
        {
			Passphrase = this.Find<TextBox>("txtPassphrase").Text;
            IsConfirmed = true;
            this.Close();
        }

        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}