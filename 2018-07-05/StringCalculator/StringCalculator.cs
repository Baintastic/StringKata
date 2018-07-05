using System;
using System.Linq;

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
                    if (numbers[j].Equals('-')) {
                        negatives += $"{numbers[j]}{numbers[j + 1]} " ;
                    }
                }
                throw new Exception($"negatives not allowed : {negatives}");
            }
            if (numbers.Length > 1) {
                var sum = 0;
                numbers = numbers.Replace("[", "");
                numbers = numbers.Replace("]", "");
                var splitNumbers = numbers.Split(new char[] { ',','\n','/','@', '#', '$', '%', '*', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < splitNumbers.Length; i++) {
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
