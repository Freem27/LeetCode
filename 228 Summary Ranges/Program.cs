namespace _228_Summary_Ranges
{
    public class TestCase
    {
        public int[] Nums { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var testCases = new List<TestCase> {
                new TestCase { Nums = new int[] { 0, 1, 2, 4, 5, 7 } },
                new TestCase { Nums = new int[] {0,2,3,4,6,8,9 } },
            };
            Solution s = new Solution();
            foreach(var testCase in testCases)
            {
                Console.WriteLine($"input: [{string.Join(',', testCase.Nums)}]");
                foreach(var res in s.SummaryRanges(testCase.Nums))
                {
                    Console.WriteLine(res);
                }
                Console.WriteLine();
            }
        }
    }

    public class Solution
    {
        public IList<string> SummaryRanges(int[] nums)
        {
            List<string> result = new List<string>();
            bool continule = false;
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (!continule)
                {
                    result.Add($"{num}");
                    continule = true;
                }
                
                if(continule)
                {
                    do
                    {
                        if (i == nums.Length - 1 || nums[i + 1] - 1 != num)
                        {
                            if (num.ToString() != result.Last())
                            {
                                result[result.Count - 1] = result.Last() + "->" + num.ToString();
                            }
                            continule = false;
                            break;
                        }
                        num = nums[++i];
                    }
                    while (i < nums.Length);
                }
            }

            return result;
        }
    }
}