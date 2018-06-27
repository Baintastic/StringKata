using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        public object Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers)) {
                return 0;
            }
            if (numbers.Length > 1) {
                var sum = 0;
                string[] splitNumbers = numbers.Split(new Char[] { ',', '\n', ';', '/' },  StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < splitNumbers.Length; i++) {

                    sum += Int32.Parse(splitNumbers[i]);
                }
                return sum;
            }
            return Int32.Parse(numbers);
        }
    }
}
