//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tellisense.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Post
    {
        public Post()
        {
            this.Thread1 = new HashSet<Thread>();
            this.User1 = new HashSet<User>();
        }
    
        public int post_ID { get; set; }
        public System.DateTime date_posted { get; set; }
        public Nullable<System.DateTime> last_edited { get; set; }
        public int poster { get; set; }
        public int in_thread { get; set; }
        public string content { get; set; }
    
        public virtual Thread Thread { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Thread> Thread1 { get; set; }
        public virtual ICollection<User> User1 { get; set; }
    }
}
