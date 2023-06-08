namespace _017_Letter_Combinations_of_a_Phone_Number
{
    internal class TestCase
    {
        public TestCase(string dights, List<string> expectedResult)
        {
            Dights = dights;
            ExpectedResult = expectedResult;
        }

        public string Dights { get; set; }
        public List<string> ExpectedResult { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var testCases = new List<TestCase>
            {
                new TestCase("2", new List<string> {"a","b","c"}),
                new TestCase("23", new List<string> {"ad","ae","af","bd","be","bf","cd","ce","cf"}),
            };
            Solution s = new Solution();
            foreach (var testCase in testCases)
            {
                var result = s.LetterCombinations(testCase.Dights);
                if (!Equals(result.ToList(), testCase.ExpectedResult))
                {
                    Console.WriteLine($"Dights: [{string.Join(',', testCase.Dights)}], Result: [{string.Join(',', result)}], ExpectedResult: [{string.Join(',', testCase.ExpectedResult)}]");
                }
            }
        }
        private static bool Equals(List<string> first, List<string> second)
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
                                               //0   1     2      3      4      5      6       7      8       9    
        static string[] letters = new string[] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits))
            {
                return new List<string>() {  };
            }
            if (digits.Length == 1)
            {
                return letters[Int32.Parse(digits)].Select(c => c.ToString()).ToList();
            }

            var result = new List<string>();
            foreach (var dight in digits) {
                var left = (List<string>)LetterCombinations(dight.ToString());
                if (result.Any())
                {
                    int rLen = result.Count;
                    for(int r = 0; r < rLen; r++) {
                        string rVal = result[r];
                        for(int i = 0; i < left.Count; i++)
                        {
                            if (i == 0)
                            {
                                result[r] += left[i];
                            }
                            else
                            {
                                result.Add(rVal + left[i]);
                            }
                        }
                    }
                }
                else
                {
                    result = left;
                }
            }
            return result;
        }
    }
}