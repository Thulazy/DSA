using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Easy
{
    public class FindGCD
    {
        public void CalculateGCD(int a, int b)
        {
            int rem = 1;
            int divisor = a < b ? a : b;
            int dividend = a > b ? a : b;
            while (rem != 0){
                rem = dividend % divisor;
                if(rem != 0)
                {
                    dividend = divisor;
                    divisor = rem;
                }
            }
            Console.WriteLine($"GCD is {divisor}");
        }
    }
}
