using System;
using System.Diagnostics;
using System.Globalization;
using Tellisense.Core;

namespace Tellisense
{
    public class AppPageValueConverter : BaseValueConverter<AppPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((AppPage)value)
            {
                case AppPage.signIn :
                    return new SignInPage();
                case AppPage.signUp:
                    return new SignUpPage();
                case AppPage.general:
                    return new General();
                case AppPage.forum:
                    return new ForumPage();
                case AppPage.subForum:
                    return new SubForumPage();
                case AppPage.thread:
                    return new ThreadPage();
                case AppPage.profile:
                    return new UserProfilePage();
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
