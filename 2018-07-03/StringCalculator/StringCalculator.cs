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
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers)) {
                return 0;
            }
            if (numbers.Contains('-')) {
                var negatives = "";
                for (int x = 0; x < numbers.Length; x++) {
                    if (numbers[x].Equals('-')) {
                        negatives += " "+numbers[x] + "" + numbers[x + 1];
                    }

                }
                throw new Exception("negatives not allowed :" +negatives);

            }
            if (numbers.Length > 1) {
                var sum = 0;
                numbers = numbers.Replace("[","");
                numbers = numbers.Replace("]", "");
                var splitNumbers = numbers.Split(new char[] { ',','\n',';','!', '@', '#', '$', '%', '*', '/'}, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < splitNumbers.Length; i++)
                {
                    var number = Int32.Parse(splitNumbers[i]);
                    if (number <= 1000) {
                        sum += number;
                    }                 
                }
                return sum;
            }         
            return Int32.Parse(numbers);
        }
    }
}
