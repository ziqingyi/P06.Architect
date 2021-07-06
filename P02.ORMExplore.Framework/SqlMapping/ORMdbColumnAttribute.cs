using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.Framework.SqlMapping
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ORMdbColumnAttribute : ORMAbstractMappingAttribute
    {
        public ORMdbColumnAttribute(string columnName) : base(columnName)
        {

        }

    }
}
