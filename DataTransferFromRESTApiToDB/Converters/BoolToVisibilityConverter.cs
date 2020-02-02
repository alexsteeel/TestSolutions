using System;
using System.Globalization;
using System.Windows.Data;

namespace DataTransferFromRESTApiToDB
{
    /// <summary>
    /// Преобразование bool в видимость элемента.
    /// true - элемент видимый, false - скрытый.
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return "Visible";
            }
            else
            {
                return "Hidden";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
