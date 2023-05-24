using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace DiagramEditor.Models.Converters
{
    public class EllipseCoordinateConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int num)
            {

                return num / 2;
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
