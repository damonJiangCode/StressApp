using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyXamarinApp.Converters
{
    public class YesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string yesNo = value as string;
            return yesNo == "yes";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isToggled = (bool)value;
            return isToggled ? "yes" : "no";
        }
    }

}

