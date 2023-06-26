namespace _2462_Total_Cost_to_Hire_K_Workers
{
    public class TestCase
    {
        public TestCase(int[] costs, int k, int candidates, int expectedResult) {
            Costs = costs;
            K = k;
            Candidates = candidates;
            ExpectedResult = expectedResult;
        }
        public int[] Costs { get; set; }
        public int K { get; set; }
        public int Candidates { get; set; }
        public int ExpectedResult { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var testCases = new TestCase[]
            {
                new TestCase(new int [] {17,12,10,2,7,2,11,20,8}, 3,4 ,11),
                new TestCase(new int [] { 1,2,4,1},3 ,3 ,4),
                new TestCase(new int [] {31,25,72,79,74,65,84,91,18,59,27,9,81,33,17,58 },11 ,2 ,423),
                new TestCase(new int [] {50,80,34,9,86,20,67,94,65,82,40,79,74,92,84,37,19,16,85,20,79,25,89,55,67,84,3,79,38,16,44,2,54,58 }, 7 ,12 , 95),
                new TestCase(new int [] { 48},1 , 1,48),
                //new TestCase(new int [] { }, , ,),
            };
            Solution s = new Solution();
            foreach (var testCase in testCases)
            {
                var result = s.TotalCost(testCase.Costs , testCase.K, testCase.Candidates);
                if(result != testCase.ExpectedResult) {
                    Console.WriteLine($"Costs: [{string.Join(",", testCase.Costs)}] k={testCase.K} candidates={testCase.Candidates} result={result} exectedResult={testCase.ExpectedResult}");
                }
            }
        }
    }

    public class Solution
    {
        public long TotalCost(int[] costs, int k, int candidates)
        {
            long resut = 0;
            PriorityQueue<int, int> startQueue = new PriorityQueue<int, int>();
            PriorityQueue<int, int> endQueue = new PriorityQueue<int, int>();
            int sIndex = 0;
            int eIndex = costs.Length - 1;
            while (startQueue.Count < candidates)
            {
                startQueue.Enqueue(costs[sIndex],costs[sIndex]);
                sIndex++;
            }

            while (endQueue.Count < candidates && sIndex < eIndex)
            {
                endQueue.Enqueue(costs[eIndex], costs[eIndex]);
                eIndex--;
            }
            while (k > 0)
            {
                if(endQueue.Count == 0 || (startQueue.Count>0 && startQueue.Peek() <= endQueue.Peek()))
                {
                    resut += startQueue.Dequeue();
                    if (sIndex <= eIndex)
                    {
                        startQueue.Enqueue(costs[sIndex], costs[sIndex]);
                        sIndex++;
                    }
                }
                else
                {
                    resut += endQueue.Dequeue();

                    if (sIndex <= eIndex)
                    {
                        endQueue.Enqueue(costs[eIndex], costs[eIndex]);
                        eIndex--;
                    }
                }
                k--;
            }

            return resut;
        }
        public long TotalCost2(int[] costs, int k, int candidates)
        {
            int resut = 0;
            var costList = costs.ToList();
            for (int i = 0; i < k; i++)
            {
                int minCost;
                bool removeFromEnd = false;
                if (costList.Count > candidates * 2)
                {
                    var strippedList = new List<int>();
                    var firstList = costList.Take(candidates);
                    strippedList.AddRange(firstList);
                    strippedList.AddRange(costList.TakeLast(candidates));
                    minCost = strippedList.Min();
                    removeFromEnd = !firstList.Contains(minCost);
                }
                else
                {
                    minCost = costList.Min();
                }

                if (removeFromEnd)
                {
                    costList.RemoveAt(costList.LastIndexOf(minCost));
                }
                else
                {
                    costList.RemoveAt(costList.IndexOf(minCost));
                }
                resut += minCost;
            }

            return resut;
        }
    }
}