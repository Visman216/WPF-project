using System;
using System.Diagnostics;
using System.Globalization;
using Tellisense.Core;

namespace Tellisense
{
    public class IOC_ValueConverter : BaseValueConverter<IOC_ValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)parameter)
            {
                case nameof(ApplicationViewModel):
                    return IOC.Get<ApplicationViewModel>();
                    
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
