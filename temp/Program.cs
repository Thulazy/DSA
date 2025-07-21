using DSA.Problems;
using System.Linq;
using System.Threading.Tasks;

namespace DSA
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ValvePressureCalculator model = new ValvePressureCalculator();
            model.Main();


            //int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            //int min = arr.Min();
            //int max = arr.Max();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i] == min)
            //    {
            //        Console.WriteLine("Buy at " + arr[i]);
            //    }
            //    if (arr[i] == max)
            //    {
            //        Console.WriteLine("Sell at " + arr[i]);
            //    }
            //}
            //    //swap two variables without temp variable
            //string s1 = "Thulasiram";
            //string s2 = "Siyamasekaran";
            //Console.WriteLine(s1 + " " + s2);
            //(s1, s2) = (s2, s1);
            //Console.WriteLine(s1 + " " + s2);
            //Console.WriteLine("Hello, World!");

            //    //abstract, virtual
            //    Test2 t = new Test2();
            //    Console.WriteLine("Array 1:\n");
            //    for (int i = 0; i < t.y.Length; i++)
            //    {
            //        Console.WriteLine(t[i]);
            //    }
            //    Console.WriteLine("Array 2 as Array 1: \n");

            //    for (int i = 0; i < t.array2.Length; i++)
            //    {
            //        Console.WriteLine(t.array2[i]);
            //    }

            //    Console.WriteLine(t.x.ToString());
            //    t.read();

            //    //two sum
            //    int[] nums = [2, 7, 11, 15];
            //    int target = 9;
            //    int[] result = new int[2];
            //    for (int i = 0; i < nums.Length; i++)
            //    {
            //        for (int j = i + 1; j < nums.Length; j++)
            //        {
            //            if (nums[i] + nums[j] == target)
            //            {
            //                result[0] = i;
            //                result[1] = j;
            //                Console.WriteLine(result[0]);
            //                Console.WriteLine(result[1]);
            //            }
            //        }
            //    }

            //    //remove duplicates and return the count
            //    string s = "pwwkew";
            //    List<string> strings = new List<string>();
            //    for (int i = 0; i < s.Length; i++)
            //    {
            //        for (int j = i; j < s.Length; j++)
            //        {
            //            if (strings.Contains(s[j].ToString()))
            //            {
            //                break;
            //            }
            //            strings.Add(s[j].ToString());
            //        }
            //    }
            //    Console.WriteLine(strings.Count);

            //    //find median 1,2,3,4,5,6
            //    int[] nums1 = new int[] { 1, 2, 3 };
            //    int[] nums2 = new int[] { 4, 5, 6 };
            //    int[] numResult = nums1.Concat(nums2).OrderBy(x => x).ToArray();
            //    double median = 0;
            //    int len = numResult.Length;
            //    if (len % 2 == 0)
            //    {
            //        median = (numResult[len / 2 - 1] + numResult[len / 2]) / 2.0;
            //    }
            //    else
            //    {

            //        median = numResult[len / 2];
            //    }


            //    //spiral order
            //    int[,] matrixA =
            //    {
            //        { 1, 2, 3 },
            //        { 4, 5, 6 },
            //        { 7, 8, 9 }
            //    };

            //    int rowLen = matrixA.GetLength(0) - 1;
            //    int colLen = matrixA.GetLength(1) - 1;
            //    int row = 0;
            //    int col = 0;
            //    while (row <= rowLen && col <= colLen)
            //    {
            //        //moving right
            //        for (int i = col; i <= colLen; i++)
            //        {
            //            Console.WriteLine(matrixA[row, i]);
            //        }
            //        row++;
            //        //move down
            //        for (int i = row; i <= rowLen; i++)
            //        {
            //            Console.WriteLine(matrixA[i, colLen]);
            //        }
            //        colLen--;
            //        if (row <= rowLen)
            //        {
            //            //move left
            //            for (int i = colLen; i >= col; i--)
            //            {
            //                Console.WriteLine(matrixA[rowLen, i]);
            //            }
            //            rowLen--;
            //        }
            //        if (col <= colLen)
            //        {
            //            //move up
            //            for (int i = rowLen; i >= row; i--)
            //            {
            //                Console.WriteLine(matrixA[i, col]);
            //            }
            //            col++;
            //        }
            //    }
            //}


            //public abstract class Test1
            //{
            //    public abstract int x { get; }
            //    public int[] array = { 1, 2, 3, 4, 5 };
            //    public int[] array2 = { 5, 4, 5, 6 };
            //    public virtual void read()
            //    {
            //        Console.WriteLine("Moving");
            //    }
            //}


            //public class Test2 : Test1
            //{
            //    public override int x => 10;
            //    public int[] y = { 4, 3, 2, 1 };
            //    public int this[int index]
            //    {
            //        get
            //        {
            //            return y[index];
            //        }
            //        set
            //        {
            //            y[index] = value;
            //        }
            //    }
            //    public int[] array2
            //    {
            //        get
            //        {
            //            return y;
            //        }
            //        set
            //        {
            //            y = value;
            //        }
            //    }
            //    public override void read()
            //    {
            //        Console.WriteLine("Moved");
            //    }

            //int n = 5;
            //int start = 0;
            //var list = new string[n];
            //var tempList = new List<string>();
            //for (int i = 1; i <= n; i++)
            //{
            //    if (i == 1)
            //    {
            //        list[start] = i.ToString();
            //        start++;
            //    }
            //    else
            //    {
            //        var temp = list[start - 1].Split(',').ToList();
            //        tempList.AddRange(temp);
            //        var groupedElements = tempList.GroupBy(x => x).Select(x => new
            //        {
            //            Count = x.Count(),
            //            Element = x.Key
            //        }).ToList();
            //        var countList = new List<string>();
            //        foreach (var item in groupedElements)
            //        {
            //            countList.Add(item.Count.ToString());
            //            countList.Add(item.Element);
            //        }
            //        list[start] = string.Join(",", countList);
            //        start++;
            //        tempList.Clear();
            //    }
            //}
            //foreach (var item in list)
            //{
            //    Console.WriteLine(string.Join(",", item));
            //}


            //int[] arr = { 7, 2, 5, 10, 8 };
            //var list = new List<int>();
            //var tempArr = arr;
            //var keyValuePairs = new Dictionary<string, List<int>>();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    list.Add(arr[i]);
            //    var t = tempArr.Where(x => !list.Contains(x)).ToList();
            //    if (!keyValuePairs.ContainsKey($"{string.Join(',', list) + ":" + i.ToString()}"))
            //    {
            //        keyValuePairs.Add($"{string.Join(',', list) + ":" + i.ToString()}", t);
            //    }
            //    else
            //    {
            //        keyValuePairs[$"{string.Join(',', list) + ":" + i.ToString()}"].AddRange(t);
            //    }
            //}
            //var keySums = new Dictionary<int, int>();
            //foreach (var items in keyValuePairs.Where(x => x.Value.Count > 0))
            //{
            //    Console.WriteLine($"{items.Key} : {string.Join(",", items.Value)}");
            //    var firstPair = items.Key.Split(':')[0].Split(',').Select(int.Parse).Sum();
            //    var secondPair = items.Value.Sum();

            //    keySums.Add(firstPair, secondPair);
            //}
            //var maxList = new List<int>();
            //foreach (var item in keySums)
            //{
            //    if(item.Key > item.Value)
            //    {
            //        maxList.Add(item.Key);
            //    }
            //    else
            //    {
            //        maxList.Add(item.Value);
            //    }
            //}
            //Console.WriteLine($"Answer: {maxList.Min()}");

            // Check if a string is a palindrome
            //string a = "malayalam";
            //string b = "";
            //for (int i = a.Length - 1; i >= 0; i--)
            //{
            //    b += a[i];
            //}
            //if (a == b)
            //{
            //    Console.WriteLine("Palindrome");
            //}
            //else
            //{
            //    Console.WriteLine("Not a Palindrome");
            //}

            //// Find the index of a target value in an array, or insert it in sorted order
            //int[] sums = { 1, 3, 5, 6 };
            //int target = 2;
            //bool isFound = false;
            //for (int i = 0; i < sums.Length; i++)
            //{
            //    if (sums[i] == target)
            //    {
            //        isFound = true;
            //        Console.WriteLine($"Found at index {i}");
            //        break;
            //    }
            //}
            //if (!isFound)
            //{
            //    List<int> sumList = sums.ToList();
            //    sumList.Add(target);
            //    sumList.Sort();
            //    int index = sumList.IndexOf(target);
            //}

            //// Find the length of the last word in a string
            //string s = "   fly me   to   the moon  ";
            //var splitedWords = s.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList();
            //int length = splitedWords.Last().Count();


            //int inp1 = 2;
            //int inp2 = 3;
            //int inp3 = 100;
            //var list = new List<int>();
            //int currentValue = 2;
            //int start = 0;
            //while (true)
            //{
            //    if(start == 0)
            //    {
            //        list.Add(inp1);
            //        start++;
            //    }
            //    currentValue *= inp2;
            //    if (currentValue > inp3)
            //    {
            //        break;
            //    }
            //    list.Add(currentValue);
            //}
            //int[] ints = list.ToArray();
            //foreach (var i in ints)
            //{
            //    Console.WriteLine(ints[i]);
            //}

            //string inp1 = "ABCD";
            //int[] inp2 = { 1, 2, 1 };
            //string temp = "";
            //for (int i = 0; i < inp2.Length; i++)
            //{
            //    var list = inp1.ToCharArray();
            //    if (!string.IsNullOrEmpty(temp))
            //    {
            //        list = temp.ToCharArray();
            //    }
            //    if (inp2[i] == 1)
            //    {
            //        char s = list[0];
            //        list[0] = list[list.Length - 1];
            //        list[list.Length - 1] = s;

            //        temp = string.Join("", list);
            //        Console.WriteLine(temp);
            //    }
            //    else
            //    {
            //        int start = 0;
            //        int end = list.Length / 2;
            //        while (start < list.Length && end < list.Length)
            //        {
            //            char s = list[start];
            //            list[start] = list[end];
            //            list[end] = s;
            //            start++;
            //            end++;
            //        }
            //        Console.WriteLine(list);
            //    }
            //}

            //int n = 5;
            //int temp = n - 1;
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        if (i == j || j == temp)
            //        {
            //            Console.Write("*");
            //            if(j == temp)
            //            {
            //                temp--;
            //            }
            //        }
            //        else
            //        {
            //            Console.Write(" ");
            //        }
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
