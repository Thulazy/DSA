using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Sortings
{
    public class BubbleSort
    {
        public void SortArrayUsingBubbleSort(int[] nums)
        {
            Console.WriteLine("Unsorted Array: ");
            for(int i = 0;i< nums.Length;i++)
            {
                Console.Write($"{nums[i]}\n");
            }
            int n = nums.Length;
            for (int j = 0; j < n - 1; j++)
            {
                bool swapped = false;
                for (int i = 0; i < n - 1 - j; i++)
                {
                    if (nums[i] > nums[i + 1])
                    {
                        int temp = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
            Console.WriteLine("sorted Array: ");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"{nums[i]}\n");
            }
        }
    }
}
