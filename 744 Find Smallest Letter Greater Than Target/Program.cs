namespace _744_Find_Smallest_Letter_Greater_Than_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class Solution
    {
        static char[] Letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public char NextGreatestLetter(char[] letters, char target)
        {
            int targetInd = Array.IndexOf(Letters, target);
            int startIndex = Array.IndexOf(letters, target);
            if (startIndex < 0)
            {
                startIndex = 0;
            }
            char result = letters[0];
            for(int i = targetInd + 1; i < Letters.Length; i++)
            {
                int index = Array.IndexOf(letters, Letters[i], startIndex);
                if(index >= 0)
                {
                    result = letters[index];
                    break;
                }
            }
            return result;
        }
    }
}