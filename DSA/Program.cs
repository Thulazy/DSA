﻿﻿using DSA.Problems.Easy;
using DSA.Problems.Sortings;
using System.Linq;
using System.Threading.Tasks;

namespace DSA
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int[] nums = { 8, 2, 5, 3, 4, 7, 6, 1 };
            List<int> numsList = nums.ToList();
            QuickSort s = new QuickSort();
            s.SortArrayUsingQuickSort(nums, 0 , nums.Length - 1);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
        }
    }
}