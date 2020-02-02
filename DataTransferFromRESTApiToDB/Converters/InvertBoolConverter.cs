﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace DataTransferFromRESTApiToDB
{
    /// <summary>
    /// Преобразование true в false и наоборот.
    /// </summary>
    public class InvertBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}