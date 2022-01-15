using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.ModelsFromDB
{
    public partial class SysUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public byte Status { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long? Qq { get; set; }
        public string WeChat { get; set; }
        public byte? Sex { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public int? LastModifyId { get; set; }
    }
}
