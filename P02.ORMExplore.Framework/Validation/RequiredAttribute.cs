using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.Framework.Validation
{
    public class RequiredAttribute : AbstractValidateAttribute
    {

        public override ValidateErrorModel Validate(object oValue)
        {
            bool test1 = oValue != null;
            bool test2 = !string.IsNullOrWhiteSpace(oValue.ToString());

            if (!test1)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(RequiredAttribute)} oValue is null"
                };
            }
            if (!test2)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(RequiredAttribute)} oValue is empty"
                };
            }
            else
            {
                return new ValidateErrorModel()
                {
                    Result = true,
                    Message = $"{nameof(RequiredAttribute)} all good"
                };
            }


        }
    }
}
