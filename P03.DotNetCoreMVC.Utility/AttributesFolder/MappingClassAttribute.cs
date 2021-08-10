using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.AttributesFolder
{
    // used for link to the database table name, sometimes the class name is diff to table name.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class MappingClassAttribute : Attribute
    {
        public string MappingName { get; private set; }
        public MappingClassAttribute(string mappingName)
        {
            this.MappingName = mappingName;
        }
    }
}
