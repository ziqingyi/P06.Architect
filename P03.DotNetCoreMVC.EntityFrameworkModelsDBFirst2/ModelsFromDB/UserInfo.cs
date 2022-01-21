using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst2.ModelsFromDB
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte Status { get; set; }
        public int UserAge { get; set; }
        public string Description { get; set; }
        public string Description01 { get; set; }
        public string Remark { get; set; }
        public int? SysUserId { get; set; }

        public virtual SysUser SysUser { get; set; }
    }
}
