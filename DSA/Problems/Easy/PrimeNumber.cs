using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Easy
{
    public class PrimeNumber
    {
        public void FindPrimeNumber(int n)
        {
            if(n == 1)
            {
                Console.WriteLine("Not a prime");
            }
            if(n == 2)
            {
                Console.WriteLine("prime");
            }
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    Console.WriteLine("Not a prime");
                }
            }
            Console.WriteLine("prime");
        }
    }
}
