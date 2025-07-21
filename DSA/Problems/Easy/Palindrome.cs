using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Easy
{
    public class Palindrome
    {
        public void FindPalindrome(int n)
        {
            int original = n;
            int result = 0;
            while(n > 0)
            {
                int rem = n % 10;
                result = result * 10 +rem;
                n = n / 10;
            }
            if(original == result)
            {
                Console.WriteLine("It is palindrome");
            }
            else
            {
                Console.WriteLine("not palindrome");
            }
        }
    }
}
