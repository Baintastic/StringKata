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
            if (numbers.Contains('-')) {
                var negatives = "";
                for (int j =0; j < numbers.Length; j++) {
                    if (numbers[j].Equals('-') ){
                        negatives += numbers[j]+""+numbers[j+1]+" ";
                    }
                }
                throw new Exception("Negatives Not Allowed : "+ negatives + "");
            }
            if (numbers.Length > 1) {
                var sum =   numbers.Split(new char[] {',','\n',';', '@', '$', '#', '*', '%', '!','/','[',']' } ,StringSplitOptions.RemoveEmptyEntries)
                                                                                                                        .Select(n => Int32.Parse(n)) // get the "list" of integers
                                                                                                                        .Sum();
                return sum;
              
            }
            return int.Parse(numbers);
        }
    }
}
