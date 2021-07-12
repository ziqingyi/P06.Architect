using System;
using System.Collections.Generic;
using System.Text;
using P02.ORMExplore.Framework.SqlFilter;
using P02.ORMExplore.Framework.SqlMapping;
using P02.ORMExplore.Framework.Validation;

namespace P02.ORMExplore.Model.DbModels
{
    [ORMdbTable("Company")]
    public class CompanyModel : BaseModel
    {
        [ORMdbColumn("Name")]
        [StringLength(5, 20)]
        public string CompanyName { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreatorId { get; set; }

        public Nullable<int> LastModifierId { get; set; }

        public DateTime? LastModifyTime { get; set; }
    }
}
