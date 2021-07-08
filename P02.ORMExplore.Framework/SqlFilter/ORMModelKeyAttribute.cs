using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.Framework.SqlFilter
{
    //only for database self - increase key
    [AttributeUsage(AttributeTargets.Property)]
    public class ORMModelKeyAttribute: Attribute
    {

    }
}
