using System.Collections.ObjectModel;
using Tellisense.Data;

namespace Tellisense.Core
{
    public class ThreadPageViewModel : BaseViewModel
    {
        IDataAccessService _serviceProxy;
        public int ThreadID { get; set; }

        public ObservableCollection<PostBubbleViewModel> Items { get; set; }
        public ThreadPageViewModel()
        {
            _serviceProxy = new DataAccessService();

            int k = IOC.Get<ApplicationViewModel>().PositionTree.Count;
            ThreadID = IOC.Get<ApplicationViewModel>().PositionTree[k - 1];

            Items = new ObservableCollection<PostBubbleViewModel>();
            foreach (var item in _serviceProxy.GetPosts(ThreadID))
            {
                PostBubbleViewModel temp = new PostBubbleViewModel();

                User user = new User();
                user = _serviceProxy.GetUser(item.poster);

                temp.PostContent = item.content;
                temp.DatePosted = item.date_posted;
                temp.PostedBy = user.name;
                temp.ProfilePic = user.picture;
                Items.Add(temp);
            }
        }
    }
}
