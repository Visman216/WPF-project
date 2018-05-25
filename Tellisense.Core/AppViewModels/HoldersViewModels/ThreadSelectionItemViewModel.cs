using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tellisense.Core
{
    public class ThreadSelectionItemViewModel : BaseViewModel
    {
        public int ThreadID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Posted_by { get; set; }
        public DateTime Date_posted { get; set; }
        public int View_Count { get; set; }

        public ICommand Command1_Enter { get; set; }
        public ICommand Command1_Delete { get; set; }
        public ThreadSelectionItemViewModel()
        {
            Command1_Enter = new RelayCommand(async () => await enter());

        }

        public async Task enter()
        {
            IOC.Get<ApplicationViewModel>().ViewShift(ThreadID);
            await Task.Delay(500);
        }
    }
}
