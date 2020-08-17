using System;
using System.Diagnostics;
using ADALotto.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace ADALotto.Views
{
	public class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Opened += OnOpened;
#if DEBUG
			this.AttachDevTools();
#endif
		}

		private void OnOpened(object sender, EventArgs e)
		{
			GenerateLottoBoxes();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
			// var binPath = @"D:\Program Files\Daedalus Mainnet";
			// Process p = new Process();
			// p.StartInfo = new ProcessStartInfo
			// {
			// 	FileName = $"{binPath}\\cardano-node.exe",
			// 	Arguments= string.Join(
			// 		" ",
			// 		"run",
			// 		"--topology", $"\"{binPath}\\topology.yaml\"",
			// 		"--database-path", "\"C:\\Users\\clark\\AppData\\Roaming\\Daedalus Mainnet\\chain\"",
			// 		"--config", $"\"{binPath}\\config.yaml\"",
			// 		"--port", "3000",
			// 		"--socket-path=\"\\\\.\\pipe\\cardano-lotto\""
			// 	),
			// 	UseShellExecute = false,
			// 	RedirectStandardOutput = true
			// };
			// p.OutputDataReceived += OnOutputDataReceived;
			// p.Start();
			// p.BeginOutputReadLine();
			// p.WaitForExit();
			// p.Close();
		}

		private void GenerateLottoBoxes()
		{
			var panelLottoNumbers = this.FindControl<StackPanel>("panelLottoNumbers");
			var viewModel = DataContext as MainWindowViewModel;
			panelLottoNumbers.Children.Clear();

			for (int x = 0; x < viewModel.Digits; x++)
			{
				var newLottoBox = new TextBox();
				newLottoBox.Watermark = "00";
				newLottoBox.Width = 43;
				newLottoBox.FontSize = 30;
				newLottoBox.TextAlignment = TextAlignment.Center;
				panelLottoNumbers.Children.Add(newLottoBox);
			}
		}

		private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
		}
	}
}