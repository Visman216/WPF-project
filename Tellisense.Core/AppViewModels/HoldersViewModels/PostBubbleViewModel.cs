using System;

namespace Tellisense.Core
{
    public class PostBubbleViewModel : BaseViewModel
    {
        public string PostContent { get; set; }
        public string PostedBy { get; set; }
        public byte[] ProfilePic { get; set; }
        public DateTime DatePosted { get; set; }

    }
}
