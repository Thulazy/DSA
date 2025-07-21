using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Sortings
{
    public class SelectionSort
    {
        public void SortArrayUsingSelectionSort(int[] nums)
        {
            Console.WriteLine("UnSorted Array(Selection sort): ");
            foreach (var items in nums)
            {
                Console.WriteLine(items);
            }
            int n = nums.Length;
            for(int i = 0; i < n - 1; i++)
            {
                int min_id = i; //assuming smallest element
                for(int j = i + 1;j< n; j++) // to find actual minimum
                {
                    if (nums[j] < nums[min_id])
                    {
                        min_id = j;
                    }
                }
                // Move minimum element to its correct position
                int temp = nums[i];
                nums[i] = nums[min_id]; 
                nums[min_id] = temp;
            }
            Console.WriteLine("Sorted Array(Selection sort): ");
            foreach(var items in nums)
            {
                Console.WriteLine(items);
            }
        }
    }
}
