using System;
using System.ComponentModel;
using System.Diagnostics;
using ADALotto.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using MessageBox.Avalonia;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;
using MessageBoxIcons = MessageBox.Avalonia.Enums.Icon;

namespace ADALotto.Views
{
    public class NewPassphraseWindow : FluentWindow
    {
        public string Passphrase { get; private set; } = string.Empty;
        private bool CanClose { get; set; }
        public string[]? Mnemonics { get; set; }

        public NewPassphraseWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            Opened += OnWindowOpened;
            Closing += OnWindowClosing;
        }

        private void OnWindowOpened(object? sender, EventArgs e)
        {
            var txtSeed = this.FindControl<TextBox>("txtSeed");
			txtSeed.Text = string.Join(" ", Mnemonics ?? new string[0]);
        }

        private void OnWindowClosing(object? sender, CancelEventArgs e)
        {
            e.Cancel = !CanClose;
        }

        public void OnBtnDoItPressed(object sender, RoutedEventArgs e)
        {
            var txtNewPass = this.FindControl<TextBox>("txtNewPassphrase");
            var txtConfPass = this.FindControl<TextBox>("txtConfirmPassphrase");
            if (txtNewPass.Text == null)
            {
                var messageBoxStandardWindow = MessageBoxManager
                    .GetMessageBoxStandardWindow(new MessageBoxStandardParams
                    {
                        ButtonDefinitions = ButtonEnum.Ok,
                        ContentTitle = "Error",
                        ContentMessage = "You must enter a passphrase!",
                        Icon = MessageBoxIcons.Error
                    });
                messageBoxStandardWindow.Show();
            }
            else if (txtNewPass.Text.Length < 10 || txtNewPass.Text.Length > 255)
            {
                var messageBoxStandardWindow = MessageBoxManager
                    .GetMessageBoxStandardWindow(new MessageBoxStandardParams
                    {
                        ButtonDefinitions = ButtonEnum.Ok,
                        ContentTitle = "Error",
                        ContentMessage = "Passphrase must be between 10 to 255 characters!",
                        Icon = MessageBoxIcons.Error
                    });
                messageBoxStandardWindow.Show();
            }
            else if (txtNewPass.Text != txtConfPass.Text)
            {
                var messageBoxStandardWindow = MessageBoxManager
                    .GetMessageBoxStandardWindow(new MessageBoxStandardParams
                    {
                        ButtonDefinitions = ButtonEnum.Ok,
                        ContentTitle = "Error",
                        ContentMessage = "Passphrase must match!",
                        Icon = MessageBoxIcons.Error
                    });
                messageBoxStandardWindow.Show();
            }
            else
            {
                Passphrase = txtNewPass.Text;
                CanClose = true;
                this.Close();
            }
        }
    }
}