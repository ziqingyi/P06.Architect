using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst2.ModelsFromDB
{
    public partial class Conmpany
    {
        public Conmpany()
        {
            SysUserCompany = new HashSet<SysUser>();
            SysUserCompanyId1Navigation = new HashSet<SysUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? CreatorId { get; set; }
        public int? LastModifierId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SysUser> SysUserCompany { get; set; }
        public virtual ICollection<SysUser> SysUserCompanyId1Navigation { get; set; }
    }
}
