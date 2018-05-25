using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tellisense.Core
{
    public class SignUpViewModel : BaseViewModel
    {
        public ICommand SignInCommand { get; set; }
        public ICommand CompleteCommand { get; set; }

        public SignUpViewModel()
        {
            SignInCommand = new RelayCommand(async () => await SignIn());
            CompleteCommand = new RelayCommand(async () => await SignUpComplete());
        }

        public async Task SignIn()
        {
            IOC.Get<ApplicationViewModel>().Creditentials(AppPage.signIn);
            await Task.Delay(5);
        }

        public async Task SignUpComplete()
        {
            IOC.Get<ApplicationViewModel>().Creditentials(AppPage.signIn);
            await Task.Delay(5);
        }
    }
}
