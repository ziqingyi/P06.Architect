using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.Framework.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LongValueRangeAttribute : AbstractValidateAttribute
    {
        private long _Min = 0;
        private long _Max = 0;

        public LongValueRangeAttribute(long min, long max)
        {
            this._Min = min;
            this._Max = max;
        }

        public override ValidateErrorModel Validate(object oValue)
        {

            bool test1 = oValue != null;
            var val = long.TryParse(oValue.ToString(), out long lValue);
            bool test2 = lValue >= this._Min;
            bool test3 = lValue <= this._Max;

            if (!test1)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(LongValueRangeAttribute)} oValue is null"
                };
            }
            if (!test2)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(LongValueRangeAttribute)} oValue is less than min"
                };
            }
            if (!test3)
            {
                return new ValidateErrorModel()
                {
                    Result = false,
                    Message = $"{nameof(LongValueRangeAttribute)} oValue is more than max"
                };
            }
            else
            {
                return new ValidateErrorModel()
                {
                    Result = true,
                    Message = $"{nameof(LongValueRangeAttribute)} all good"
                };
            }

        }



    }
}
