namespace _047_Permutations_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var testCases = new List<TestCase> {
                new TestCase(new int[]{1, 1, 2}),
                new TestCase(new int[]{0, 1}),
                new TestCase(new int[]{1}),
            };
            Solution s = new Solution();
            foreach (var testCase in testCases)
            {
                var result = s.PermuteUnique(testCase.Nums);
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
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            if (nums.Length == 1)
            {
                return new List<IList<int>>() { nums.ToList() };
            }
            else if (nums.Length == 2)
            {
                if (nums[0] == nums[1])
                {
                    return new List<IList<int>>
                    {
                        new List<int> { nums[0], nums[1] },
                    };
                }

                return new List<IList<int>>
                {
                    new List<int> { nums[0], nums[1] },
                    new List<int> { nums[1], nums[0] },
                };
            }
            else
            {
                var result = new List<IList<int>>();
                for (int i = 0; i < nums.Length; i++)
                {
                    int first = nums[i];
                    var arr = nums.ToList();
                    arr.RemoveAt(i);
                    foreach (var p in PermuteUnique(arr.ToArray()))
                    {
                        var forAdd = new List<int> { first };
                        forAdd.AddRange(p);
                        if (!result.Any(r =>
                        {
                            for (int ri = 0; ri < r.Count; ri++)
                            {
                                if (r[ri] != forAdd[ri])
                                {
                                    return false;
                                }
                            }
                            return true;
                        })) 
                        {
                            result.Add(forAdd);
                        }
                    }
                }
                return result;
            }
        }
    }
}