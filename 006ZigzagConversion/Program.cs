namespace _006ZigzagConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> tests = new List<string>
            {
                "PAYPALISHIRING",
                //"ABCD",
            };
            Solution solution = new Solution();
            tests.ForEach(test =>
            {
                Console.WriteLine($"input: {test} output: {solution.Convert(test, 4)}");
            });
        }
    }
    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            var result = string.Empty;
            var matrix = new string[numRows];
            int currColIndex = 0;
            int currRowIndex = 0;
            int currZigZagRowIndex = numRows - 2;
            for (int i = 0; i < s.Length; i++)
            {
                bool isFullRow = currColIndex == 0 || numRows == 1 || currColIndex % (numRows - 1) == 0;
                for (int rowNum = 0; rowNum < numRows; rowNum++)
                {
                    if (isFullRow)
                    {
                        if (i + rowNum < s.Length)
                        {
                            matrix[currRowIndex + rowNum] = matrix[currRowIndex + rowNum] += s[i + rowNum];
                        }
                    }
                    else
                    {
                        if (rowNum == currZigZagRowIndex)
                        {
                            matrix[currRowIndex + rowNum] = matrix[currRowIndex + rowNum] += s[i];
                        }
                        //else
                        //{
                        //    matrix[currRowIndex + rowNum] = matrix[currRowIndex + rowNum] += "_";
                        //}
                    }
                }
                if (!isFullRow)
                {
                    currZigZagRowIndex = currZigZagRowIndex == 1 ? numRows - 2 : currZigZagRowIndex - 1;
                }
                else
                {
                    i = i + numRows - 1;
                }
                currColIndex++;
            }
            foreach(var row in matrix)
            {
                result += row;
                //Console.WriteLine(row);
            }

            return result;
        }
    }
}