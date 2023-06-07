using System.Diagnostics;

namespace _010RegularExpressionMatching
{
    internal class TestCase
    {
        public TestCase(string text, string pattern, bool result)
        {
            Text = text;
            Pattern = pattern;
            ExpectedResult = result;
        }
        public string Text { get; set; }
        public string Pattern { get; set; }
        public bool ExpectedResult { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var testCases = new List<TestCase>
            {
                new TestCase("cabcbabbacabbbba", "b*.*aa.*c*c*aa*b*", false),
                new TestCase("ab", ".*..", true),
                new TestCase("cbbbaccbcacbcca", "b*.*b*a*.a*b*.a*", true),
                new TestCase("a", "..", false),
                new TestCase("a", ".*..a*", false),
                new TestCase("baabbbaccbccacacc", "c*..b*a*a.*a..*c", true),
                new TestCase("aaabaaaababcbccbaab", "c*c*.*c*a*..*c*", true),
                new TestCase("a", "ab*a", false),
                new TestCase("abbabaaaaaaacaa", "a*.*b.a.*c*b*a*c*", true),
                new TestCase("aab", "b.*", false),
                new TestCase("a", "..*", true),
                new TestCase("aaa", "ab*a*c*a", true),
                new TestCase("ab", ".*", true),
                new TestCase("aa", "a*", true),
                new TestCase("aaa", "ab*ac*a", true),
                new TestCase("mississippi", "mis*is*p*.", false),
                new TestCase("mississippi", "mis*is*ip*.", true),
                new TestCase("aab", "c*a*b", true),
                new TestCase("aaa", "ab*a", false),
                new TestCase("abcd", "d*", false),
                new TestCase("aa", "a", false),
            };
            Solution solution = new Solution();

            foreach (var testCase in testCases)
            {
                var result = solution.IsMatch(testCase.Text, testCase.Pattern);
                if (result != testCase.ExpectedResult)
                {

                    Console.WriteLine($"string: '{testCase.Text}', pattern: '{testCase.Pattern}', isMatch: {result}");
                }
            }
        }
    }
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            int currPatternIndex = p.Length;
            if (p.IndexOf('.') == -1 && p.IndexOf('*') == -1)
            {
                return s == p;
            }
            for (int i = s.Length - 1; i >= 0; i--)
            {
                currPatternIndex--;
                if (currPatternIndex < 0)
                {
                    return false;
                }
                char c = s[i];
                switch (p[currPatternIndex])
                {
                    case '.':
                        break;
                    case '*':
                        char? prevPatternChar = currPatternIndex > 0 ? p[currPatternIndex - 1] : null;
                        if (c != prevPatternChar && prevPatternChar != '.')
                        {
                            i++;
                            currPatternIndex--;
                            break;
                        }

                        int startIndex = i;
                        if (prevPatternChar == '.')
                        {
                            currPatternIndex--;
                            if (currPatternIndex == 0)
                            {
                                return true;
                            }
                            startIndex = 0;
                        }
                        else
                        {
                            while (startIndex != 0)
                            {
                                if (c != prevPatternChar)
                                {
                                    break;
                                }
                                else
                                {
                                    startIndex--;
                                    c = s[startIndex];
                                }
                            }
                        }

                        for (int len = i; len >= startIndex; len--)
                        {
                            string substr = s.Substring(0, len + 1);
                            string subpattern = p.Substring(0, currPatternIndex);
                            if (IsMatch(substr, subpattern))
                            {
                                return true;
                            }
                            if (prevPatternChar != '.')
                            {
                                subpattern = p.Substring(0, currPatternIndex - 1);
                                if (IsMatch(substr, subpattern))
                                {
                                    return true;
                                }
                            }
                        }
                        i = 0;
                        break;
                    default:
                        if (c != p[currPatternIndex])
                        {
                            return false;
                        }
                        break;
                }
                if ((currPatternIndex == 0 || p.Substring(0, currPatternIndex) == ".*") && i == 0)
                {
                    return true;
                }

            }

            var splittedP = p;
            int splitIndex = splittedP.Length;
            while (splitIndex > 1 && splittedP[splitIndex - 1] == '*')
            {
                if (splittedP[splitIndex - 2] == '.')
                {
                    break;
                }
                splitIndex -= 2;
                splittedP = splittedP.Substring(0, splitIndex);
            }

            while (splittedP.Length > 1 && splittedP[1] == '*')
            {
                if (splittedP[0] == '.')
                {
                    break;
                }
                splittedP = splittedP.Substring(2);
            }

            return splittedP == s || splittedP == ".*" || (p != splittedP && IsMatch(s, splittedP));
        }
    }
}