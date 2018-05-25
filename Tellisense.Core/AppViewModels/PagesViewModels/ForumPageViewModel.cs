using System.Collections.ObjectModel;
using System.Windows.Input;
using Tellisense.Data;

namespace Tellisense.Core
{
    public class ForumPageViewModel : BaseViewModel
    {
        IDataAccessService _serviceProxy;
        public int ForumID { get; set; }

        public ObservableCollection<SubForumSelectionItemViewModel> Items { get; set; }
        public ForumPageViewModel()
        {
            _serviceProxy = new DataAccessService();

            int k = IOC.Get<ApplicationViewModel>().PositionTree.Count;
            ForumID = IOC.Get<ApplicationViewModel>().PositionTree[k - 1];

            Items = new ObservableCollection<SubForumSelectionItemViewModel>();
            foreach (var item in _serviceProxy.GetSubForums(ForumID))
            {
                SubForumSelectionItemViewModel temp = new SubForumSelectionItemViewModel();
                temp.SubforumID = item.subforum_ID;
                temp.Title = item.subforum_Title;
                Items.Add(temp);
            }
        }
    }
}
