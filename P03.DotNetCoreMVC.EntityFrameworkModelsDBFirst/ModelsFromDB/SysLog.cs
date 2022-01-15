using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.ModelsFromDB
{
    public partial class SysLog
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Introduction { get; set; }
        public string Detail { get; set; }
        public byte LogType { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public int? LastModifierId { get; set; }
    }
}
