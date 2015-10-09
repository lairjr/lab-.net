using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2
{
    public class RuleVerifier
    {
        public static bool IsInRule(BasedNumber first, BasedNumber second)
        {
            return RuleVerifier.HasOneDigitDiff(first.Value, second.Value);
        }

        private static bool HasOneDigitDiff(string first, string second)
        {
            var firstChars = first.ToCharArray();
            var secondChars = second.ToCharArray();

            var lenghtDiff = firstChars.Length - secondChars.Length;

            if (lenghtDiff != 0)
                return false;

            return RuleVerifier.HasOndeDigitDiffSameLength(firstChars, secondChars);
        }

        private static bool HasOndeDigitDiffSameLength(char[] first, char[] second)
        {
            var countMissChar = 0;

            for (var index = 0; index < first.Length; index++)
            {
                if (first[index] != second[index])
                    countMissChar++;
            }

            return countMissChar == 1;
        }
    }
}
