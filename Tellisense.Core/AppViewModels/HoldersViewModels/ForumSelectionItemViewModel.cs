using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tellisense.Core
{
    public class ForumSelectionItemViewModel : BaseViewModel
    {
        public int ForumID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICommand Command1_Enter { get; set; }
        public ICommand Command1_Delete { get; set; }
        public ForumSelectionItemViewModel()
        {
            Command1_Enter = new RelayCommand(async () => await enter());

        }

        public async Task enter()
        {
            IOC.Get<ApplicationViewModel>().ViewShift(ForumID);
            await Task.Delay(10);
        }
    }
}
