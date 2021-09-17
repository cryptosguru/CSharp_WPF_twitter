﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace tweetz.core.Converters
{
    internal class TextFormattingModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is true
                ? "Display"
                : "Ideal";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}