using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TrocaOdonto.Models;
using Xamarin.Forms;

namespace TrocaOdonto.Views.Converters
{
    public class RecoveryPasswordConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values.Length == 2)
            {
                string newPassword = values[0].ToString();
                string newPasswordVerification = values[1].ToString();
                return new RecoveryPassword { NewPassword = newPassword, NewPasswordVerification = newPasswordVerification };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw null;
        }
    }
}
