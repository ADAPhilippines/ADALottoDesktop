using System;
using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ADALotto.Views
{
    public class MessageBox : FluentWindow
    {
        private string _message = string.Empty;
        public string Message
        {
            get => _message;

            set
            {
                _message = value;
                RefreshData();
            }
        }
        private string _buttonLabel { get; set; } = string.Empty;
        public string ButtonLabel
        {
            get => _buttonLabel;
            set
            {
                _buttonLabel = value;
                RefreshData();
            }
        }
        private TextBlock? tbMessage { get; set; }
        private TextBlock? tbButtonLabel { get; set; }
        private bool _isClosePrevented = false;
        public bool IsClosePrevented
        {
            get => _isClosePrevented;
            set
            {
                _isClosePrevented = value;
                this.Find<Button>("btnAction").IsVisible = !_isClosePrevented;
            }
        }
        public MessageBox()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.Opened += OnMessageBoxOpened;
            this.Closing += OnMessageBoxClosing;
        }

        private void OnMessageBoxClosing(object? sender, CancelEventArgs e)
        {
            e.Cancel = IsClosePrevented;
        }

        private void OnMessageBoxOpened(object? sender, EventArgs e)
        {
            tbMessage = this.Find<TextBlock>("tbMessage");
            tbButtonLabel = this.Find<TextBlock>("tbButtonLabel");
            RefreshData();
        }

        private void RefreshData()
        {
            if (tbMessage != null)
                tbMessage.Text = Message;

            if (tbButtonLabel != null)
                tbButtonLabel.Text = ButtonLabel;
        }

        public static void Show(string title, string message, string buttonLabel = "Ok", Window? parent = null)
        {
            new MessageBox
            {
                Title = title,
                Message = message,
                ButtonLabel = buttonLabel
            }.ShowDialog(parent);
        }

        private void OnActionClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}