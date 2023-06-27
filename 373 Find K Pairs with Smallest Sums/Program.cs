using System.Globalization;

namespace _373_Find_K_Pairs_with_Smallest_Sums
{
    public class TestCase
    {
        public TestCase(int[] nums1, int[] nums2, int k, List<List<int>> expectedResult)
        {
            Nums1 = nums1;
            Nums2 = nums2;
            K = k;
            ExpectedResult = expectedResult;
        }
        public int[] Nums1 { get; set; }
        public int[] Nums2 { get; set; }
        public int K { get; set; }
        public List<List<int>> ExpectedResult { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var testCases = new TestCase[]
            {
                new TestCase(new int []{ 1, 7, 11 },new int []{ 2, 4, 6 }, 3, new List<List<int>>{ new List<int> { 1 ,2 },new List<int> { 1, 4 }, new List<int> {1,6 } }),
                new TestCase(new int []{ 1, 1, 2 },new int []{ 1, 2, 3 }, 2, new List<List<int>>{ new List<int> { 1, 2 },new List<int> { 1, 4 }, new List<int> {1,6 } }),
                new TestCase(new int []{ 1, 2 },new int []{ 3 }, 3, new List<List<int>>{ new List<int> { 1,2 },new List<int> { 1, 4 }, new List<int> {1,6 } }),
            };
            Solution s = new Solution();
            foreach (var testCase in testCases)
            {
                var result = s.KSmallestPairs(testCase.Nums1, testCase.Nums2, testCase.K);
                Console.WriteLine($"[{string.Join(',', result.Select(r => $"[{string.Join(',', r)}]"))}]");
            }
        }
    }

    public class Solution
    {
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            IList<IList<int>> result = new List<IList<int>>();
            PriorityQueue<(int ind1, int ind2), int> queue = new PriorityQueue<(int ind1, int ind2), int>();
            queue.Enqueue((0, 0), nums1[0] + nums1[0]);
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            while (queue.Count > 0 && result.Count() < k)
            {
                var curr = queue.Dequeue();
                result.Add(new List<int> { nums1[curr.ind1], nums2[curr.ind2] });
                if (curr.ind1 + 1 < nums1.Length && !visited.Contains((curr.ind1 + 1, curr.ind2)))
                {
                    queue.Enqueue((curr.ind1 + 1, curr.ind2), nums1[curr.ind1 + 1] + nums2[curr.ind2]);
                    visited.Add((curr.ind1 + 1, curr.ind2));
                }
                if (curr.ind2 + 1 < nums2.Length && !visited.Contains((curr.ind1, curr.ind2 + 1)))
                {
                    queue.Enqueue((curr.ind1, curr.ind2 + 1), nums1[curr.ind1] + nums2[curr.ind2 + 1]);
                    visited.Add((curr.ind1, curr.ind2 + 1));
                }
            }
            return result;
        }
    }
}