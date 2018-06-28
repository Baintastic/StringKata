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
                for (int j = 0; j < numbers.Length; j++) {

                    if (numbers[j] == '-') {
                        negatives += j+j+1;
                    }
                }
                throw new Exception("Negatives not allowed");
            }
            if (numbers.Length == 1) {
                return Int32.Parse(numbers);
            }
            var sum = 0;
            var splitNumbers = numbers.Split(new Char[] { ',','\n','/',';', ':', '#', '$', '%', '*', '!' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splitNumbers.Length; i++) {
                sum += Int32.Parse(splitNumbers[i]);
            }
            return sum;
            
        }
    }
}
