using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ADALotto.Views
{
    public class BuyConfirmWindow : Window
    {
        public int[]? Combination { get; set; }
        public long Price { get; set; }
        public long Fee { get; set; }

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
            this.Find<TextBlock>("txtCombination").Text = string.Join("-", Combination ?? new int[0]);
            this.Find<TextBlock>("txtPrice").Text = Math.Round((double)Price / 1000000, 6).ToString("#,0.000000");
            this.Find<TextBlock>("txtFee").Text = Math.Round((double)Fee / 1000000, 6).ToString("#,0.000000");
            this.Find<TextBlock>("txtTotal").Text = Math.Round(((double)Price + Fee) / 1000000, 6).ToString("#,0.000000");
        }
    }
}