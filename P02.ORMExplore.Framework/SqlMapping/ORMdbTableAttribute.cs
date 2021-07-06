using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.Framework.SqlMapping
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ORMdbTableAttribute: ORMAbstractMappingAttribute
    {
        public ORMdbTableAttribute(string tableName) : base(tableName)
        {

        }

    }
}
