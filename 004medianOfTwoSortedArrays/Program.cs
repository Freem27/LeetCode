using System.Security.Cryptography.X509Certificates;

namespace _004medianOfTwoSortedArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tests = new List<Tuple<int[], int[]>>
            {
                new Tuple<int[], int[]>(new int []{1,3}, new int[]{2}),
                new Tuple<int[], int[]>(new int []{1,2}, new int[]{3,4}),
            };
            Solution solution = new Solution();
            foreach (var test in tests)
            {
                Console.WriteLine($"nums1=[{string.Join(",", test.Item1)}], nums2=[{string.Join(",", test.Item2)}], Output = {solution.FindMedianSortedArrays(test.Item1, test.Item2)}"
                );
            }

        }
    }
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] sorted = nums1.Concat(nums2).ToArray();
            Array.Sort(sorted);
            if(sorted.Length % 2 == 0)
            {
                return (sorted[sorted.Length / 2 - 1] + sorted[sorted.Length / 2]) / 2d;
            }
            else
            {
                return sorted[sorted.Length / 2];
            }
        }
    }
}