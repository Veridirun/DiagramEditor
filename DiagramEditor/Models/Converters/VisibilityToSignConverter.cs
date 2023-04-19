﻿using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramEditor.Models.Converters
{
    public class VisibilityToSignConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if(value is string val)
                {
                    switch (val)
                    {
                        case "public":
                            return "+";
                        case "protected":
                            return "#";
                        case "private":
                            return "-";
                        case "package":
                            return "~";
                        default:
                            return "!";
                    }

                }
                return null;
            }
            else 
                return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
