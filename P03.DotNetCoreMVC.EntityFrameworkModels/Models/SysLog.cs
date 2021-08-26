﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.EntityFrameworkModels.Models
{
    [Table("SysLog")]
    public partial class SysLog
    {
        public int Id { get; set; }

        [Required]
        //[StringLength(36)]
        public string UserName { get; set; }

        [Required]
        [StringLength(1000)]
        public string Introduction { get; set; }

        [StringLength(4000)]
        public string Detail { get; set; }

        public byte LogType { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreatorId { get; set; }

        public DateTime? LastModifyTime { get; set; }

        public int? LastModifierId { get; set; }
    }
}
