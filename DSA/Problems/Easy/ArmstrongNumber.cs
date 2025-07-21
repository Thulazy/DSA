using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Easy
{
    public class ArmstrongNumber
    {
        public void FindArmStrongNumber(int n)
        {
            int original = n;
            int count = 0;
            int temp = n;
            while(temp > 0)
            {
                count++;
                temp = temp / 10;
            }
            temp = n;
            int sum = 0;
            while(temp > 0)
            {
                int rem = temp % 10;
                int power = 1;
                for(int i = 0; i < count; i++)
                {
                    power *= rem;
                }
                sum += power;
                temp = temp / 10;   
            }
            if(sum == original)
            {
                Console.WriteLine("Armstrong");

            }
            else
            {
                Console.WriteLine("Not armstrong");
            }
        }

    }
}
