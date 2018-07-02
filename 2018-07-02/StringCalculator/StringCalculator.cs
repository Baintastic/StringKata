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
                var splitNumbers =   numbers.Split(new char[] {',','\n',';', '@', '$', '#', '*', '%', '!','/','[',']' } ,StringSplitOptions.RemoveEmptyEntries);
                var sum = 0;
                for (int i = 0; i < splitNumbers.Length; i++) {
                    if (Int32.Parse(splitNumbers[i]) <= 1000) {
                        sum += Int32.Parse(splitNumbers[i]);

                    }             
                }
                return sum;
              
            }
            return int.Parse(numbers);
        }
    }
}
