using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2
{
    public class BasedNumber : IComparable
    {
        public string Value { get; set; }
        public int Base { get; set; }

        public BasedNumber(string value, int _base)
        {
            this.Value = value;
            this.Base = _base;
        }

        #region Operator Methods

        public static BasedNumber operator ++(BasedNumber number)
        {
            var decimalValue = number.ToDecimal();
            return Parse(decimalValue + 1, number.Base);
        }

        public static bool operator <=(BasedNumber firstNumber, BasedNumber secondNumber)
        {
            var comparedValue = firstNumber.CompareTo(secondNumber);
            return !(comparedValue > 0);
        }

        public static bool operator >=(BasedNumber firstNumber, BasedNumber secondNumber)
        {
            var comparedValue = firstNumber.CompareTo(secondNumber);
            return !(comparedValue < 0);
        }

        public static BasedNumber operator +(BasedNumber number, int unit)
        {
            var decimalValue = number.ToDecimal();
            decimalValue += unit;
            return Parse(decimalValue, number.Base);
        }

        #endregion

        #region Public Methods

        public int CompareTo(object obj)
        {
            var instaceValue = this.ToDecimal();
            var compareValue = ((BasedNumber)obj).ToDecimal();
            if (instaceValue < compareValue)
            {
                return -1;
            }
            else if (instaceValue == compareValue)
            {
                return 0;
            }
            return 1;
        }

        public static long GetDecimal(char value, int _base)
        {
            var basedValue = new BasedNumber(value.ToString(), _base);
            return basedValue.ToDecimal();
        }

        public static BasedNumber GetMaxNumber(int _base)
        {
            var count = _base - 1;

            var maxDigit = count.ToString();
            if (_base >= 10)
            {
                maxDigit = GetDigit(count);
            }

            var basedValue = string.Join(string.Empty, Enumerable.Repeat(maxDigit, count));
            var number = new BasedNumber(basedValue, _base);
            return number;
        }

        public static BasedNumber Parse(long value, int _base)
        {
            var basedValue = GetNextBaseDigit(value, _base);
            var number = new BasedNumber(basedValue, _base);
            return number;
        }

        public long ToDecimal()
        {
            if (this.Base != 10)
            {
                var revertedNumber = this.Value.Reverse();
                int powNumber = 0;
                long decimalValue = 0;
                foreach (var digit in revertedNumber)
                {
                    var decimalDigitValue = 10;
                    if (char.IsNumber(digit))
                    {
                        decimalDigitValue = Convert.ToInt32(digit.ToString());
                    }
                    decimalValue += decimalDigitValue * Convert.ToInt64(Math.Pow(this.Base, powNumber));
                    powNumber++;
                }
                return decimalValue;
            }
            return long.Parse(this.Value);
        }

        public override string ToString()
        {
            return this.Value;
        }

        #endregion

        #region Auxiliar Methods

        private static string GetNextBaseDigit(long dividend, int _base)
        {
            if (dividend < _base)
            {
                return dividend.ToString();
            }
            var rest = dividend % _base;
            var quotient = (dividend - rest) / _base;

            return GetNextBaseDigit(quotient, _base) + GetDigit(rest);
        }

        private static string GetDigit(long decimalValue)
        {
            if (decimalValue >= 10)
                return Convert.ToChar(decimalValue + 55).ToString();
            return decimalValue.ToString();
        }

        #endregion
    }
}
