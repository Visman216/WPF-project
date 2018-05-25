using System.Threading.Tasks;
using System.Windows.Input;

namespace Tellisense.Core
{
    public class SignInViewModel : BaseViewModel
    {
        public ICommand SignInCommand { get; set; }
        public ICommand SignUpCommand { get; set; }

        public SignInViewModel()
        {
            // SignInCommand = new RelayParametrizedCommand(async (parameter) => await SignIn(parameter));
            SignInCommand = new RelayCommand(async () => await SignIn());
            SignUpCommand = new RelayCommand(async () => await SignUp());
        }
        
         
        public async Task SignIn()
        {
            IOC.Get<ApplicationViewModel>().EnterForums(); // EnterForums(Id, password)
            await Task.Delay(500);
        }

        public async Task SignUp()
        {
            IOC.Get<ApplicationViewModel>().Creditentials(AppPage.signUp);
            await Task.Delay(500);
        }
    }
}
