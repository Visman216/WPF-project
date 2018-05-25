using System;
using System.Collections.Generic;
using Tellisense.Data;

namespace Tellisense.Core
{
    public class ApplicationViewModel : BaseViewModel
    {
        public AppPage CurrentPage { get; set; } = AppPage.profile;
        public AppCtrl CurrentControl { get; set; } = AppCtrl.none;
        public NavPriviledge CurrentPriviledge { get; set; } = NavPriviledge.none;

        public List<int> PositionTree { get; set; }

        public ApplicationViewModel()
        {
            PositionTree = new List<int>();
        }

        public void UserPage()
        {
            CurrentPage = AppPage.profile;
            CurrentControl = AppCtrl.none;
        }

        public void NewPost()
        {
            CurrentPage = AppPage.newPost;
            CurrentControl = AppCtrl.none;
        }

        public void Creditentials(AppPage page)
        {
            CurrentPage = page;
        }
        

        public void EnterForums()
        {
            PositionTree.Clear();
            PositionTree.Add(0);
            CurrentPage = AppPage.general;
            CurrentControl = AppCtrl.top;
        }


        public void ViewShift(int context)
        {
            PositionTree.Add(context);
            CurrentPage++;
        }


        public void ViewJump(int context)
        {
            int k = PositionTree.FindIndex(id => id == context);
            int K = PositionTree.Count;
            PositionTree.RemoveRange(k - 1, K - k);
            CurrentPage += (k + 4);
        }
    }
}