using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace P02.ORMExplore.Framework.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAttribute : AbstractValidateAttribute
    {
        private string _EmailRegular = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public override ValidateErrorModel Validate(object oValue)
        {
            bool test1 = oValue != null;
            bool test2 = !string.IsNullOrWhiteSpace(oValue.ToString());
            bool test3 = Regex.IsMatch(oValue.ToString(), this._EmailRegular);

            if (!test1)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(EmailAttribute)} oValue is null"
                };
            }
            if (!test2)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(EmailAttribute)} oValue is empty"
                };
            }

            if (!test3)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(EmailAttribute)} oValue is null"
                };
            }
            else
            {
                return new ValidateErrorModel()
                {
                    Result = true,
                    Message = $"{nameof(EmailAttribute)} all good"
                };
            }

        }

    }
}
