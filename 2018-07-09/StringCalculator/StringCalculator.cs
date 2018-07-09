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
            CheckForNegatives(input);
            input = Filter(input);
            var sum = GetSum(input);
            return sum;
        }

        private static int GetSum(string input)
        {
            string[] numbers = Split(input);
            var sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                var number = Int32.Parse(numbers[i]);
                if (number <= 1000)
                {
                    sum += number;
                }
            }
            return sum;
        }

        private static string[] Split(string input)
        {
            return input.Split(new char[] { ',', '\n', ';', '#', '*', '@', '!', '%', '&', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static string Filter(string input)
        {
            if (input.StartsWith("//"))
            {
                input = input.Replace("[", "");
                input = input.Replace("]", "");
                var end = input.IndexOf("\n");
                input = input.Substring(end);
            }

            return input;
        }

        private static void CheckForNegatives(string input)
        {
            if (input.Contains('-'))
            {
                var negatives = "";
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j].Equals('-'))
                    {
                        negatives += $"{input[j]}{input[j + 1]} ";
                    }
                }
                throw new Exception($"negatives not allowed : {negatives}");
            }
        }
    }
}
