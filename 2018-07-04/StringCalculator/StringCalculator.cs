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
            if (numbers.Contains('-'))
            {
                var negatives = "";
                negatives = GetNegatives(numbers, negatives);
                throw new Exception("negatives not allowed : " + negatives);
            }
            if (numbers.Length > 1)
            {
                var sum = 0;
                string[] splitNumbers = GetSplit(numbers);
                sum = Calculate(sum, splitNumbers);
                return sum;
            }
            return Int32.Parse(numbers);
        }

        private static string GetNegatives(string numbers, string negatives)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[j].Equals('-'))
                {
                    negatives += numbers[j] + "" + numbers[j + 1] + " ";
                }
            }
            return negatives;
        }

        private static int Calculate(int sum, string[] splitNumbers)
        {
            for (int i = 0; i < splitNumbers.Length; i++)
            {
                var number = Int32.Parse(splitNumbers[i]);
                if (number <= 1000) {
                    sum += number;
                }           
            }
            return sum;
        }

        private static string[] GetSplit(string numbers)
        {
            numbers = numbers.Replace("[","");
            numbers = numbers.Replace("]", "");
            return numbers.Split(new char[] { ',', '\n', ';' ,'/','@' ,'#','$','%','*','&' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
