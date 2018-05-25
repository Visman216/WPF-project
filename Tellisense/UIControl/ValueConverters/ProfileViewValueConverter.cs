using System;
using System.Diagnostics;
using System.Globalization;
using Tellisense.Core;

namespace Tellisense
{
    public class ProfileViewValueConverter : BaseValueConverter<ProfileViewValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((ProfileView)value)
            {
                case ProfileView.overview :
                    return new Overview();
                case ProfileView.messages:
                    return new Messages();
                case ProfileView.followed:
                    return new Followed();
                default :
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
