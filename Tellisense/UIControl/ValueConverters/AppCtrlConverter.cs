using System;
using System.Globalization;

namespace Tellisense
{
    public class AppCtrlConverter : BaseValueConverter<AppCtrlConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((AppCtrl)value)
            {
                case AppCtrl.top:
                    return new TopContol();

                default:
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
