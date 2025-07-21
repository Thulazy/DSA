using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Easy
{
    public class ReverseNumber
    {
        public void ReverseANumber(int n)
        {
            int rem = 0;
            int result = 0;

            while (n != 0)
            {
                rem = n % 10;
                result = result * 10 + rem;
                n = n / 10;
                
            }
            Console.WriteLine(result);
        }
    }
}
