namespace _003LongestSubstringWithoutRepeatingCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> tests = new List<string>
            {
                "abcabcbb",
                "bbbbb",
                "pwwkew",
                "dvdf",
                "anviaj",
            };
            Solution solution = new Solution();
            tests.ForEach(test =>
            {
                Console.WriteLine($"input: {test} output: {solution.LengthOfLongestSubstring(test)}");
            });
        }
    }
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var chars = s.ToCharArray();
            List<char> currSubstr = new List<char>();
            int result = 0;
            int startSubstrIndex = 0;
            //string longestSubstr = string.Empty;
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                if (currSubstr.Contains(c))
                {
                    if (result < currSubstr.Count())
                    {
                        result = currSubstr.Count();
                        //longestSubstr = string.Join("", currSubstr);
                    }
                    i = startSubstrIndex++;
                    currSubstr = new List<char> { chars[i] };
                }
                else
                {
                    currSubstr.Add(c);
                }

                if(chars.Length == i + 1 && result < currSubstr.Count())
                {
                    result = currSubstr.Count();
                    //longestSubstr = string.Join("", currSubstr);
                }
            }
            return result;
        }
    }
}