using System;
using System.Collections.Generic;
using System.Text;
using P02.ORMExplore.Framework.Validation;

namespace P02.ORMExplore.Model.DbModels
{
    public class User : BaseModel
    {
        [StringLength(10, 50)]
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public int State { get; set; }

        public int UserType { get; set; }

        public DateTime LastLoginTime { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreatorId { get; set; }

        public int LastModifierId { get; set; }

        public DateTime LastModifyTime { get; set; }
    }
}
