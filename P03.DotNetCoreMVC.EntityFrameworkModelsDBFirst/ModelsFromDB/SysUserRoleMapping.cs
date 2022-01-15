using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.ModelsFromDB
{
    public partial class SysUserRoleMapping
    {
        public int Id { get; set; }
        public int SysUserId { get; set; }
        public int SysRoleId { get; set; }
    }
}
