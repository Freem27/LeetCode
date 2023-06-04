namespace _005LongestPalindromicSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> tests = new List<string>
            {
                "babad",
                "cbbd",
                "a",
                "abb",
            };
            Solution solution = new Solution();
            tests.ForEach(test =>
            {
                Console.WriteLine($"input: {test} output: {solution.LongestPalindrome(test)}");
            });
        }
    }
    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            string result = s[0].ToString();
            for (int startIndex = 0; startIndex < s.Length; startIndex++)
            {
                for (int endIndex = startIndex + 1; endIndex < s.Length; endIndex++)
                {
                    int len = endIndex - startIndex + 1;
                    if (result.Length >= len)
                    {
                        continue;
                    }
                    string substr = s.Substring(startIndex, endIndex - startIndex + 1);
                    if (IsPalindrome(substr))
                    {
                        result = substr;
                    }
                }
            }
            return result;
        }

        private bool IsPalindrome(string substr)
        {
            for(int i  = 0; i < substr.Length / 2; i++)
            {
                if (substr[i] != substr[substr.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}