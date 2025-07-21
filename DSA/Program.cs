using DSA.Problems.Easy;
using DSA.Problems.Sortings;
using System.Linq;
using System.Threading.Tasks;

namespace DSA
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int[] nums = { 4, 6, 2, 4, 6, 1 };
            SelectionSort s = new SelectionSort();
            s.SortArrayUsingSelectionSort(nums);
        }
    }
}
