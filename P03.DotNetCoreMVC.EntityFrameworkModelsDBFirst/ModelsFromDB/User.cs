using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.ModelsFromDB
{
    public partial class User
    {
        public User()
        {
            Company = new HashSet<Company>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int State { get; set; }
        public int UserType { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public int? LastModifierId { get; set; }
        public DateTime? LastModifyTime { get; set; }

        public virtual Company CompanyNavigation { get; set; }
        public virtual ICollection<Company> Company { get; set; }
    }
}
