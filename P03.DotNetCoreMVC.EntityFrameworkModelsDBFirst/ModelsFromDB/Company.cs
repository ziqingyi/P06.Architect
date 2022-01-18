using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.ModelsFromDB
{
    public partial class Company
    {
        public Company()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public int? LastModifierId { get; set; }
        public DateTime? LastModifyTime { get; set; }

        public virtual User Creator { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
