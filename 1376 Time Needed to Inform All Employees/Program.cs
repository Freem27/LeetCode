namespace _1376_Time_Needed_to_Inform_All_Employees
{
    internal class TestCase
    {
        public TestCase(int n, int headId, int[] manager, int[] informTime, int expectedResult)
        {
            N= n; 
            HeadId = headId;
            Manager = manager;
            InfromTime = informTime;
            ExpectedResult =expectedResult;
        }
        public int N { get; set; }
        public int HeadId { get; set; }
        public int[] Manager { get; set; }
        public int[] InfromTime { get; set; }
        public int ExpectedResult { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var testCases = new List<TestCase> {
                new TestCase(8, 0, new int[]{-1,5,0,6,7,0,0,0},  new int[]{89,0,0,0,0,523,241,519}, 612),
                new TestCase(1, 0, new int[]{-1},  new int[]{0}, 0),
                new TestCase(6, 2, new int[]{2,2,-1,2,2,2},  new int[]{0,0,1,0,0,0}, 1),
                new TestCase(15, 0, new int[]{-1,0,0,1,1,2,2,3,3,4,4,5,5,6,6},  new int[]{1,1,1,1,1,1,1,0,0,0,0,0,0,0,0}, 3),
            };
            Solution s = new Solution();
            foreach (var testCase in testCases)
            {
                var result = s.NumOfMinutes(testCase.N, testCase.HeadId, testCase.Manager, testCase.InfromTime);
                if(result != testCase.ExpectedResult)
                {
                    Console.WriteLine($"n = {testCase.N}, headId = {testCase.HeadId}, manager = [{string.Join(',', testCase.Manager)}]," +
                        $" informTime = [{string.Join(',', testCase.InfromTime)}], result = {result}, expectedResult = {testCase.ExpectedResult}");
                }
            }
        }
    }
    public class Solution
    {
        Dictionary<int, int[]> ms = new Dictionary<int, int[]>();
        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            ms.Clear();
            for (int i = 0; i < manager.Length; i++)
            {
                ms.Add(i, new int[] { manager[i], informTime[i] });
            }

            int result = informTime[headID];
            int maxChildTime = CalcChildsMaxTime(headID);
            result += maxChildTime;
            return result;
        }

        private int CalcChildsMaxTime(int headId)
        {
            var childs = ms.Where(m => m.Value[0] == headId).ToList();
            int maxChildTime = 0;
            
            foreach (var child in childs)
            {
                ms.Remove(child.Key);
                int subtime = child.Value[1] + CalcChildsMaxTime(child.Key);
                if(subtime > maxChildTime)
                {
                    maxChildTime = subtime;
                    break;
                }
            }
            return maxChildTime;
        }

        public int NumOfMinutes1(int n, int headID, int[] manager, int[] informTime)
        {
            int result = informTime[headID];
            int maxSubtime = 0;
            for (int subHeadIndex = 0; subHeadIndex < manager.Length; subHeadIndex++)
            {
                if (manager[subHeadIndex] == headID)
                {
                    int subtime = NumOfMinutes1(n, subHeadIndex, manager, informTime);
                    if (subtime > maxSubtime)
                    {
                        maxSubtime = subtime;
                    }
                }
            }
            result += maxSubtime;
            return result;
        }
    }
}