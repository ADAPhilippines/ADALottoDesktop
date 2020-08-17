using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace ADALotto.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		private string greeting = "Greetings!";
		public string Greeting
		{
			get => greeting;
			set => this.RaiseAndSetIfChanged(ref greeting, value);
		}

		public int Digits { get; set; } = 6;

		public void Test()
		{
			Greeting = "Hello World";
		}
	}
}
