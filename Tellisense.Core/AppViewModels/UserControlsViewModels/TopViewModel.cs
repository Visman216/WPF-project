using Ninject.Planning.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tellisense.Core
{
    public class TopViewModel : BaseViewModel
    {
        public ICommand VisitProfile { get; set; }
        public ICommand Command2 { get; set; }

        public ObservableCollection<PositionNodeViewModel> PositionTree { get; set; }
        public TopViewModel()
        {

            /*PositionTree = new ObservableCollection<PositionNodeViewModel>();
            foreach(var item in IOC.Get<ApplicationViewModel>().PositionTree)
            {
                PositionNodeViewModel temp = new PositionNodeViewModel();
                temp.levelname = item;
                PositionTree.Add(temp);
            }*/
            //SignInCommand = new RelayParametrizedCommand(async (parameter) => await SignIn(parameter));
            VisitProfile = new RelayCommand(async () => await GoTo());
        }

        public async Task GoTo()
        {
            IOC.Get<ApplicationViewModel>().UserPage();
            await Task.Delay(500);
        }
        
    }
}
