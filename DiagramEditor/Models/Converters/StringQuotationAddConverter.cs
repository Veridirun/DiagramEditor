﻿using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace DiagramEditor.Models.Converters
{
    public class StringQuotationAddConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                if (str != "")
                    return "«" + str + "»";
                return null;
            }
            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
