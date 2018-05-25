using System.Collections.ObjectModel;
using Tellisense.Data;

namespace Tellisense.Core
{
    public class GeneralPageViewModel : BaseViewModel
    {
        IDataAccessService _serviceProxy;

        public ObservableCollection<ForumSelectionItemViewModel> Items { get; set; }
        public GeneralPageViewModel()
        {

            _serviceProxy = new DataAccessService();

            Items = new ObservableCollection<ForumSelectionItemViewModel>();
            foreach (var item in _serviceProxy.GetForums())
            {
                ForumSelectionItemViewModel temp = new ForumSelectionItemViewModel();
                temp.ForumID = item.forum_ID;
                temp.Title = item.forum_Title;
                temp.Description = item.forum_description;
                Items.Add(temp);
            }
        }
    }
}
