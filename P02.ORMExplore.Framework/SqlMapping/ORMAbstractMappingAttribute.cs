using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.Framework.SqlMapping
{
    public abstract class ORMAbstractMappingAttribute:Attribute
    {
        private string _name;
        public ORMAbstractMappingAttribute(string name)
        {
            this._name = name;
        }
        public string GetName()
        {
            return this._name;
        }
    }
}
