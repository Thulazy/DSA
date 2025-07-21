using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Easy
{
    public class PrintDivisors
    {
        public void PrintAllDivisors(int n)
        {
            string result = string.Empty;   
            for(int i = 1; i <= n; i++)
            {
                if(n % i == 0)
                {
                    result += string.Join(" ", i, " ");
                }
            } 
        }
    }
}
