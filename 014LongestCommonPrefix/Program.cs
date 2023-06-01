internal class Program
{
    private static void Main(string[] args)
    {
        Solution s = new Solution();
        //Console.WriteLine(s.LongestCommonPrefix(new string[] { "flower", "flow", "flight"}));
        //Console.WriteLine(s.LongestCommonPrefix(new string[] { "dog", "racecar", "car" }));
        Console.WriteLine(s.LongestCommonPrefix(new string[] { "ab", "a" }));
    }
}

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        string result = "";
        bool stop = false;
        for (int i = 0; i< strs[0].Length; i++)
        {
            char c = strs[0][i];
            foreach (string str in strs)
            {
                if(str.Length -1 < i)
                {
                    stop = true;
                    break;
                }
                if(c != str[i])
                {
                    stop = true;
                }
            }
            if (stop)
            {
                return result;
            }
            result += c.ToString();
        }
        return result;
    }
}