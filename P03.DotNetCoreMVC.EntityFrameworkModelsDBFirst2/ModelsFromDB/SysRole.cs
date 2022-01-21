using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst2.ModelsFromDB
{
    public partial class SysRole
    {
        public SysRole()
        {
            SysUserRoleMapping = new HashSet<SysUserRoleMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public int? LastModifierId { get; set; }

        public virtual ICollection<SysUserRoleMapping> SysUserRoleMapping { get; set; }
    }
}
