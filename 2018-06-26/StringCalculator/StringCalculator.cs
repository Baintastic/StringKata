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
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }
           
            if (numbers.Length > 1)
            {
                if (numbers.Contains("//")) {
                    var index = numbers.IndexOf("n");
                     numbers = numbers.Substring(index+1);

                }
                var sum = 0;
              
                var separators = new[] {",","\n",";"};
                var splitNumbers = numbers.Split(separators, StringSplitOptions.RemoveEmptyEntries);
             
                for (int i = 0; i < splitNumbers.Length; i++)
                {
                    sum += int.Parse(splitNumbers[i]);
                }
                return sum;
            }

            return int.Parse(numbers);
        }
    }
}
