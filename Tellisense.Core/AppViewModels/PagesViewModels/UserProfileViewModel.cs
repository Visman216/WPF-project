using System.Threading.Tasks;
using System.Windows.Input;

namespace Tellisense.Core
{
    public class UserProfileViewModel : BaseViewModel
    {
        public ProfileView CurrentSelection { get; set; } = ProfileView.overview;
        public ICommand Command1 { get; set; }
        public ICommand Command2 { get; set; }
        public ICommand Command3 { get; set; }
        public ICommand Command4 { get; set; }

        public UserProfileViewModel()
        {
            //SignInCommand = new RelayParametrizedCommand(async (parameter) => await SignIn(parameter));
            Command1 = new RelayCommand(async () => await select(ProfileView.overview));
            Command3 = new RelayCommand(async () => await select(ProfileView.messages));
            Command2 = new RelayCommand(async () => await select(ProfileView.followed));
            Command4 = new RelayCommand(async () => await leavePage());
        }

        public async Task select(ProfileView select)
        {
            CurrentSelection = select;
            await Task.Delay(500);
        }

        public async Task leavePage()
        {
            IOC.Get<ApplicationViewModel>().EnterForums();
            await Task.Delay(500);
        }
    }
}
