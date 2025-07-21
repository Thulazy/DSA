using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Easy
{
    public class SquareRoot
    {
        public void FindSquareRoot(int n)
        {
            if (n < 0)
            {
                Console.WriteLine("No real numbers");
            }
            int i = 1;
            while(i * i <= n)
            {
                i++;
            }
            Console.WriteLine(i - 1);

        }
    }
}
