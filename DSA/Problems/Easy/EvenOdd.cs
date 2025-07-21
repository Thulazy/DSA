using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Easy
{
    public class EvenOdd
    {
        public void FindEvenOrOdd()
        {
            int a = 11;
            var result = new List<string>
            {
                "Even","Odd"
            };
            Console.WriteLine(result[a % 2]);
        }

    }
}
