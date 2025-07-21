﻿using DSA.Problems.Easy;
using DSA.Problems.Sortings;
using System.Linq;
using System.Threading.Tasks;

namespace DSA
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int[] nums = { 4, 1, 3, 9, 7 };
            List<int> numsList = nums.ToList();
            InsertionSort s = new InsertionSort();
            s.SortArrayUsingInsertionSort(numsList);
        }
    }
}