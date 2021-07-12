using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace P02.ORMExplore.Framework.Validation
{
    public class PhoneAttribute : AbstractValidateAttribute
    {
        private string _PhoneRegular = @"`[1]+[3,5]+\d[9]";

        public override ValidateErrorModel Validate(object oValue)
        {
            bool test1 = oValue != null;
            bool test2 = !string.IsNullOrWhiteSpace(oValue.ToString());
            bool test3 = Regex.IsMatch(oValue.ToString(), this._PhoneRegular);

            if (!test1)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(PhoneAttribute)} oValue is null"
                };
            }
            if (!test2)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(PhoneAttribute)} oValue is empty"
                };
            }
            if (!test3)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(PhoneAttribute)} oValue is null"
                };
            }
            else
            {
                return new ValidateErrorModel()
                {
                    Result = true,
                    Message = $"{nameof(PhoneAttribute)} all good"
                };
            }

        }

    }
}
