namespace _016_3Sum_Closest
{
    internal class TestCase
    {
        public TestCase(int[] nums, int target, int expectedResult)
        {
            Nums = nums;
            Target = target;
            ExpectedResult = expectedResult;
        }
        public int[] Nums { get; set; }
        public int Target { get; set; }
        public int ExpectedResult { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var testCases = new List<TestCase> {
                new TestCase(new int[] {4,0,5,-5,3,3,0,-4,-5}, -2, -2),
                new TestCase(new int[] {-1,2,1,-4}, 1, 2),
                new TestCase(new int[] {0,0,0}, 1, 0),
                new TestCase(new int[] {1,1,1,0}, 100, 3),
            };

            Solution s = new Solution();
            foreach (var testCase in testCases)
            {
                var result = s.ThreeSumClosest(testCase.Nums, testCase.Target);
                if (result != testCase.ExpectedResult)
                {
                    Console.WriteLine($"Value: [{string.Join(',', testCase.Nums)}], Result: {result}, ExpectedResult: {testCase.ExpectedResult}");
                }
            }
        }
    }

    public class Solution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int result = nums[0] + nums[1] + nums[2];
            int currDiff = Math.Abs(result - target);
            for (int i1 = 0; i1 < nums.Length - 1; i1++)
            {
                for (int i2 = i1 + 1; i2< nums.Length - 1; i2++)
                {
                    if (i1 == i2)
                    {
                        continue;
                    }
                    int sum = nums[i1] + nums[i2];
                    for (int i3 = nums.Length - 1; i3 > i2; i3--)
                    {
                        int s = sum + nums[i3];
                        if (s == target)
                        {
                            return target;
                        }
                        if (Math.Abs(target - s) < currDiff)
                        {
                            result = s;
                            currDiff = Math.Abs(result - target);
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}