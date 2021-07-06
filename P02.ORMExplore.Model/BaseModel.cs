using P02.ORMExplore.Framework.SqlFilter;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.Model
{
    public class BaseModel
    {
        [ORMModelKey]
        public int Id { get; set; }


    }
}
