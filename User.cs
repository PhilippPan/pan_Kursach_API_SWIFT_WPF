//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRApplicationWPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public Nullable<System.DateTime> UserDateOfBirth { get; set; }
        public int StatusID { get; set; }
    
        public virtual Roles Roles { get; set; }
        public virtual Status Status { get; set; }
    }
}
