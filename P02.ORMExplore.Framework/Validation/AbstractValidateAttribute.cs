using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.Framework.Validation
{
    public abstract class AbstractValidateAttribute: Attribute
    {
        private Func<object, ValidateErrorModel> _func;

        public AbstractValidateAttribute(Func<object, ValidateErrorModel> func)
        {
            this._func = func;
        }
        // sub class don't need to override all methods in parent class, 
        // use delegate to pass to constructor, 
        public ValidateErrorModel ValideSelf(object oValue)
        {
            return this._func.Invoke(oValue);
        }

        public abstract ValidateErrorModel Validate(object oValue);
    }
}
