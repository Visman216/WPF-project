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
    
    public partial class User
    {
        public User()
        {
            this.Post = new HashSet<Post>();
            this.Thread = new HashSet<Thread>();
            this.Post1 = new HashSet<Post>();
        }
    
        public int user_ID { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string e_mail_address { get; set; }
        public System.DateTime date_joined { get; set; }
        public string status { get; set; }
        public byte[] picture { get; set; }
    
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Thread> Thread { get; set; }
        public virtual ICollection<Post> Post1 { get; set; }
    }
}
