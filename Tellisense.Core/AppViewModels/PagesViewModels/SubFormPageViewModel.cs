using System.Collections.ObjectModel;
using Tellisense.Data;

namespace Tellisense.Core
{
    public class SubFormPageViewModel : BaseViewModel
    {
        IDataAccessService _serviceProxy;
        public int SubForumID { get; set; }

        public ObservableCollection<ThreadSelectionItemViewModel> Items { get; set; }
        public SubFormPageViewModel()
        {
            _serviceProxy = new DataAccessService();

            int k = IOC.Get<ApplicationViewModel>().PositionTree.Count;
            SubForumID = IOC.Get<ApplicationViewModel>().PositionTree[k-1];

            Items = new ObservableCollection<ThreadSelectionItemViewModel>();
            foreach (var item in _serviceProxy.GetThreads(SubForumID))
            {
                ThreadSelectionItemViewModel temp = new ThreadSelectionItemViewModel();
                
                Post post = new Post();
                User user = new User();
                post = _serviceProxy.GetPost((item.key_post).Value);
                user = _serviceProxy.GetUser(post.poster);

                temp.ThreadID = item.thread_ID;
                temp.Title = item.thread_Title;
                temp.Description = item.thread_description;
                temp.Posted_by = user.name;
                temp.Date_posted = post.date_posted;
                temp.View_Count = item.view_count;
                Items.Add(temp);
            }
        }
    }
}
