using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Numbers
{
    public class BasedNumberVerifier
    {
        public static bool HasSequentialSumMoreThen(BasedNumber number, int topSum)
        {
            if (number.Value.Length > 1) {
                for (int x = 0; x < number.Value.Length - 1; x++)
                {
                    var subResult = Math.Abs(BasedNumber.GetDecimal(number.Value[x + 1], number.Base) - BasedNumber.GetDecimal(number.Value[x], number.Base));
                    if (subResult > topSum)
                        return false;
                }
                return true;
            }
            return false;
        }

        public static bool HasDuplicate(BasedNumber number)
        {
            return number.Value.GroupBy(c => c).Where(c => c.Count() > 1).Any();
        }
    }
}
