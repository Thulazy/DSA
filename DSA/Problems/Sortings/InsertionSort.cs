using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Sortings
{
    public class InsertionSort
    {
        public void SortArrayUsingInsertionSort(List<int> nums)
        {
            Console.WriteLine("Unsorted Array (Insertion Sort)");
            foreach (var items in nums)
            {
                Console.WriteLine(items);
            }
            int len = nums.Count();
            for (int i = 1; i < len; i++)
            {
                int key = nums[i];
                int prevIndex = i - 1;
                while (prevIndex >= 0 && nums[prevIndex] > key)
                {
                    nums[prevIndex + 1] = nums[prevIndex];
                    prevIndex--;
                }
                nums[prevIndex + 1] = key;
            }
            Console.WriteLine("sorted Array (Insertion Sort)");
            foreach (var items in nums)
            {
                Console.WriteLine(items);
            }
        }
    }
}
