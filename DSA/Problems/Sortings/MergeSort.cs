using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Problems.Sortings
{
    public class MergeSort
    {
        public void SortArrayUsingMergeSort(int[] array)
        {
            int length = array.Length;
            if (length <= 1) return;
            int leftSize = length / 2;
            int rightSize = length - leftSize;

            int[] leftArray = new int[leftSize];
            int[] rightArray = new int[rightSize];

            int i = 0;
            int j = 0;
            for (; i < length; i++)
            {
                if (i < leftSize)
                {
                    leftArray[i] = array[i];
                }
                else
                {
                    rightArray[j] = array[i];
                    j++;
                }
            }

            SortArrayUsingMergeSort(leftArray);
            SortArrayUsingMergeSort(rightArray);
            Merge(leftArray, rightArray, array);
        }

        public static void Merge(int[] leftArray, int[] rightArray, int[] array)
        {
            int length = array.Length;
            int leftSize = length / 2;
            int rightSize = length - leftSize;

            int i = 0, left = 0, right = 0;
            while (left < leftSize && right < rightSize)
            {
                if (leftArray[left] < rightArray[right])
                {
                    array[i] = leftArray[left];
                    i++;
                    left++;
                }
                else
                {
                    array[i] = rightArray[right];
                    i++;
                    right++;
                }
            }

            while (left < leftSize)
            {
                array[i] = leftArray[left];
                i++;
                left++;
            }

            while (right < rightSize)
            {
                array[i] = rightArray[right];
                i++;
                right++;
            }
        }
    }
}
