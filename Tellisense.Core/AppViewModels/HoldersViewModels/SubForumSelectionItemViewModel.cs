using System.Threading.Tasks;
using System.Windows.Input;

namespace Tellisense.Core
{
    public class SubForumSelectionItemViewModel : BaseViewModel
    {
        public int SubforumID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICommand Command1_Enter { get; set; }
        public ICommand Command1_Delete { get; set; }
        public SubForumSelectionItemViewModel()
        {
            Command1_Enter = new RelayCommand(async () => await enter());
            
        }

        public async Task enter()
        {
            IOC.Get<ApplicationViewModel>().ViewShift(SubforumID);
            await Task.Delay(500);
        }
    }
}
