using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Sortings
{
    public class QuickSort
    {
        public void SortArrayUsingQuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    SortArrayUsingQuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    SortArrayUsingQuickSort(arr, pivot + 1, right);
                }
            }
        }

        public int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                if (arr[left] < pivot)
                {
                    left++;
                }
                if (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
