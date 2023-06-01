using System;
namespace _20ValidParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var testStrings = new string[] { "()", "()[]{}", "(]" };
            Solution solution = new Solution();
            foreach (var testString in testStrings)
            {
                Console.WriteLine($"{testString}\t->\t{solution.IsValid(testString)}");
            }
        }
    }

    public class Solution
    {
        private static char[] openChars = new[] { '[', '(', '{' }; 
        private static char[] closeChars = new[] { ']', ')', '}' }; 
        public bool IsValid(string s)
        {
            List<char> closeList = new List<char>();
            foreach (char c in s) { 
                if(openChars.Contains(c))
                {
                    closeList.Add(closeChars[Array.IndexOf(openChars, c)]);
                    continue;
                }
                
                if(closeChars.Contains(c) && closeList.LastOrDefault() == c)
                {
                    closeList.RemoveAt(closeList.Count - 1);
                }
                else
                {
                    return false;
                }
            }
            return !closeList.Any();
        }
    }
}