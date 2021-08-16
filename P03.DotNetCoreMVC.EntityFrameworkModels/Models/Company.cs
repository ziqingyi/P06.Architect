namespace P03.DotNetCoreMVC.EntityFrameworkModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Company")]
    public partial class Company
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreatorId { get; set; }

        public int? LastModifierId { get; set; }

        public DateTime? LastModifyTime { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
