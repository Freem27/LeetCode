namespace _015_3Sum
{
    internal class TestCase
    {
        public TestCase(int[] nums, List<List<int>> expectedResult)
        {
            Nums = nums;
            ExpectedResult = expectedResult;
        }

        public int[] Nums { get; set; }
        public List<List<int>> ExpectedResult { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var testCases = new List<TestCase> {
                new TestCase(new int[] {-4,-2,-2,-2,0,1,2,2,2,3,3,4,4,6,6},new List<List<int>>{ 
                    new List<int> { -4,-2,6 },
                    new List<int> { -4,0,4 },
                    new List<int> { -4,1,3 },
                    new List<int> { -4,2,2 },
                    new List<int> { -2,-2,4 },
                    new List<int> { -2,0,2 },
                }),
                new TestCase(new int[] {-1,0,1,0},new List<List<int>>{ new List<int> { -1, 0, 1 } }),
                new TestCase(new int[] {0,0,0,0},new List<List<int>>{ new List<int> { 0, 0, 0 } }),
                new TestCase(new int[] {-1,0,1,2,-1,-4},new List<List<int>>{ new List<int> { -1, -1, 2 }, new List<int> { -1, 0, 1 } }),
                new TestCase(new int[] {0,1,1},new List<List<int>>{ }),
                new TestCase(new int[] {0,0,0},new List<List<int>>{ new List<int> { 0, 0, 0 } }),
            };

            Solution s = new Solution();
            foreach (var testCase in testCases)
            {
                var result = s.ThreeSum(testCase.Nums);
                if (!Equals(result, testCase.ExpectedResult))
                {
                    Console.WriteLine($"Value: [{string.Join(',', testCase.Nums)}], Result: [{string.Join(',', result.Select(r => $"[{string.Join(',', r)}]").ToList())}], ExpectedResult: [{string.Join(',', testCase.ExpectedResult.Select(r => $"[{string.Join(',', r)}]").ToList())}]");
                }
            }
        }

        private static bool Equals(IList<IList<int>> first, List<List<int>> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }
            foreach (var subListFirs in first)
            {
                bool founded = false;
                foreach (var subListSecond in second)
                {
                    if (Equals(subListFirs.ToList(), subListSecond))
                    {
                        founded = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (!founded)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool Equals(List<int> first, List<int> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }
            first.Sort();
            second.Sort();
            for (int i = 0; i < first.Count; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);
            for (int i1 = 0; i1 < nums.Length - 2; i1++)
            {
                if (nums[i1] > 0)
                {
                    break;
                }
                int val1 = nums[i1];
                for (int i2 = i1 + 1; i2 < nums.Length - 1; i2++)
                {
                    int val2 = nums[i2];
                    int summ = val1 + val2;
                    if (summ > 0)
                    {
                        break;
                    }
                    else
                    {
                        for (int i3 = nums.Length - 1; i3 > i2; i3--)
                        {
                            int val3 = nums[i3];
                            if ((summ + val3) == 0 && i1 != i3 && i1 != i2 && i2 != i3)
                            {
                                var forAdd = new int[]{ val1, val2, val3 };
                                Array.Sort(forAdd);
                                var prev = result.LastOrDefault();
                                if(prev==null || prev[0] != forAdd[0] || prev[1] != forAdd[1] || prev[2] != forAdd[2])
                                {
                                    result.Add(forAdd);
                                }
                                break;
                            }
                            if (summ + val3 < 0)
                            {
                                break;
                            }
                        }
                    }

                    while (i2 + 1 > nums.Length - 1 && val2 == nums[i2 + 1])
                    {
                        i2++;
                    }
                }

                while (i1 + 1 < nums.Length - 1 && val1 == nums[i1 + 1])
                {
                    i1++;
                }
            }
            return result;
        }
    }
}