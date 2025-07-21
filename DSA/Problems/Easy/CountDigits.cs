using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Easy
{
    public class CountDigits
    {
        public void CountDigitsInANumber(int n)
        {
            int count = 0;
            string N = n.ToString();
            for (int i = 0; i < N.Length; i++)
            {
                int b = N[i] - '0';
                if(b <= 0)
                {
                    continue;
                }
                if (n % b == 0)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
