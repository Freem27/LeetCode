namespace _046Permutations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var testCases = new List<TestCase> {
                new TestCase(new int[]{1, 2, 3}),
                new TestCase(new int[]{0, 1}),
                new TestCase(new int[]{1}),
            };
            Solution s = new Solution();
            foreach (var testCase in testCases)
            {
                var result = s.Permute(testCase.Nums);
                Console.WriteLine($"nums = [{string.Join(',', testCase.Nums)}], result = [{string.Join(',', result.Select(r => $"[{string.Join(',', r)}]"))}],");
            }
        }
    }

    public class TestCase
    {
        public TestCase(int[] nums)
        {
            Nums = nums;
        }
        public int[] Nums { get; set; }

    }

    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            if (nums.Length == 1)
            {
                return new List<IList<int>>() { nums.ToList() };
            } else if (nums.Length == 2)
            {
                return new List<IList<int>>
                {
                    new List<int> { nums[0], nums[1] },
                    new List<int> { nums[1], nums[0] },
                };
            } else
            {
                var result = new List<IList<int>>();
                for(int i=0; i<nums.Length; i++)
                {
                    int first = nums[i];
                    var arr = nums.ToList();
                    arr.RemoveAt(i);
                    foreach (var p in Permute(arr.ToArray()))
                    {
                        var forAdd = new List<int>{ first };
                        forAdd.AddRange(p);
                        result.Add(forAdd);
                    }
                }
                return result;
            }
        }
    }
}