using System;
using System.Diagnostics;
using ADALotto.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace ADALotto.Views
{
	public class NewPassphraseWindow : Window
	{
		
		public NewPassphraseWindow()
		{
			InitializeComponent();
		}
		
		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}