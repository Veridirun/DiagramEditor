using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace DiagramEditor.Models.Converters
{
    public class IsInterfaceToStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool isInterface)
            {
                if (isInterface == true)
                {
                    return "«Interface»";
                }
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
