using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.Framework.SqlMapping
{
    public abstract class ORMAbstractMappingAttribute:Attribute
    {
        private string _mappingName;
        public ORMAbstractMappingAttribute(string name)
        {
            this._mappingName = name;
        }
        public string GetMappingName()
        {
            return this._mappingName;
        }
    }
}
