using System;
using System.Collections.Generic;
using System.Linq;

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
            if (HasCustomDelimiter(input))
            {
                var indexOfNewLine = input.IndexOf('\n');
                input = input.Substring(indexOfNewLine);
            }
            var numbers = Split(input);
            CheckForNegativeNumbers(numbers);
            return CalculateSum(numbers);
        }

        private static bool HasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static IEnumerable<int> Split(string input)
        {
            return input.Split(new char[] { ',', '\n', ';', '*', '!', '@', '#', '%', '&', '(', ')' }, StringSplitOptions.RemoveEmptyEntries).Select(part => Convert.ToInt32(part));
        }

        private static void CheckForNegativeNumbers(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(x => x < 0);
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed : {string.Join(",", negatives)}");
            }
        }

        private static int CalculateSum(IEnumerable<int> numbers)
        {
            return numbers.Where(num => num <= 1000).Sum();
        }
    }
}
