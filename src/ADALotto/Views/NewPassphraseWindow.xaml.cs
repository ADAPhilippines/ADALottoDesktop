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
    public class NewPassphraseWindow : Window
    {
        public string Passphrase { get; private set; } = string.Empty;
        private bool CanClose { get; set; }
        public NewPassphraseWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            Closing += OnWindowClosing;
        }

        private void OnWindowClosing(object? sender, CancelEventArgs e)
        {
            e.Cancel = !CanClose;
        }

        public void OnBtnDoItPressed(object sender, RoutedEventArgs e)
        {
            var newPass = this.FindControl<TextBox>("NewPassphrase");
            var confPass = this.FindControl<TextBox>("ConfirmPassphrase");
            if (newPass.Text == null)
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
            else if (newPass.Text.Length < 10 || newPass.Text.Length > 255)
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
            else if (newPass.Text != confPass.Text)
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
                Passphrase = newPass.Text;
                CanClose = true;
                this.Close();
            }
        }
    }
}