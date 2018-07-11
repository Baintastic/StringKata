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
        public object Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }
            CheckForNegativeNumbers(input);
            if (input.StartsWith("//"))
            {
                var indexOfNewLine = input.IndexOf('\n');
                input = input.Substring(indexOfNewLine);
            }
            int sum = CalculateSum(input);
            return sum;
        }

        private static int CalculateSum(string input)
        {
            return input.Split(new char[] { ',', '\n', ';', '*', '!', '@', '#', '%', '&', '(', ')' }, StringSplitOptions.RemoveEmptyEntries).Select(part => Convert.ToInt32(part)).Where(num => num <= 1000).Sum();
        }

        private static void CheckForNegativeNumbers(string input)
        {
            if (input.Contains('-'))
            {
                var negatives = "";
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i].Equals('-'))
                    {
                        negatives += $"{input[i]}{input[i + 1]} ";
                    }
                }
                throw new Exception($"negatives not allowed : {negatives}");
            }
        }
    }
}
