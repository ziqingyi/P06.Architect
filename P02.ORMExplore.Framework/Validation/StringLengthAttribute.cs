using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.Framework.Validation
{
    public class StringLengthAttribute : AbstractValidateAttribute
    {
        private int _min = 0;
        private int _max = 0;

        public StringLengthAttribute(int min, int max)
        {
            this._max = max;
            this._min = min;
        }

        public override ValidateErrorModel Validate(object oValue)
        {
            bool test1 = oValue != null;
            bool test2 = oValue.ToString().Length >= this._min;
            bool test3 = oValue.ToString().Length <= this._max;

            if (!test1)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(oValue)} value is null"
                };
            }
            if (!test2)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(oValue)} value is less than min"
                };
            }
            if (!test3)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(oValue)} value is more than max"
                };
            }
            else
            {
                return new ValidateErrorModel()
                {
                    Result = true,
                    Message = $"{nameof(oValue)} value all good"
                };
            }


        }










    }
}
