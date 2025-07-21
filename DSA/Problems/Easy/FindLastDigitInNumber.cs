using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Easy
{
    public class FindLastDigitInNumber
    {
        public void FindLastDigitInANumber(string a, string b)
        {
            int lastDigitOfA = a[a.Length - 1] - '0';

            if (b == "0")
            {
                Console.WriteLine("Last Digit is 1");
                return;
            }

            Dictionary<int, int[]> cycles = new Dictionary<int, int[]>()
        {
            { 0, new int[] { 0 } },
            { 1, new int[] { 1 } },
            { 2, new int[] { 2, 4, 8, 6 } },
            { 3, new int[] { 3, 9, 7, 1 } },
            { 4, new int[] { 4, 6 } },
            { 5, new int[] { 5 } },
            { 6, new int[] { 6 } },
            { 7, new int[] { 7, 9, 3, 1 } },
            { 8, new int[] { 8, 4, 2, 6 } },
            { 9, new int[] { 9, 1 } }
        };

            int[] cycle = cycles[lastDigitOfA];
            int cycleLength = cycle.Length;

            int mod = 0;
            for (int i = 0; i < b.Length; i++)
            {
                int digit = b[i] - '0';
                mod = (mod * 10 + digit) % cycleLength;
            }

            int indexInCycle = mod == 0 ? cycleLength - 1 : mod - 1;

            Console.WriteLine($"Last Digit is {cycle[indexInCycle]}");
        }
    }
}
