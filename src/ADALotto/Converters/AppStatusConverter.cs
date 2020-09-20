using System;
using System.Globalization;
using ADALotto.Enumerations;
using Avalonia.Data.Converters;

namespace ADALotto.Converters
{
	public class AppStatusConverter : IValueConverter
	{
		public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Enum.GetName(typeof(AppStatus), value);
		}

		public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(value != null && value is string)
				return Enum.Parse(typeof(AppStatus), (string)value);
			return null;
		}
	}
}