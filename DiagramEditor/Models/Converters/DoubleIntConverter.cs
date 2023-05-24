using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System.Globalization;

namespace DiagramEditor.Models.Converters
{
    public class DoubleIntConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is double num)
            {
                return (int)num;
            }
            return 0;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int num)
            {
                return (double)num;
            }
            return 0;
        }
    }
}

