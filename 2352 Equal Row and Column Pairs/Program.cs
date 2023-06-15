namespace _2352_Equal_Row_and_Column_Pairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.EqualPairs(new int[][] {
                new int[] { 3,2,1 },
                new int[] { 1,7,6 },
                new int[] { 2,7,7 },
            });
        }
    }

    public class Solution
    {
        public int EqualPairs(int[][] grid)
        {
            int result = 0;
            int[][] cols = new int[grid.Length][];
            for (int colIndex = 0; colIndex < grid.Length; colIndex++)
            {
                int[] col = new int[grid.Length];
                for (int rowIndex = 0; rowIndex < grid.Length; rowIndex++)
                {
                    col[rowIndex] = grid[rowIndex][colIndex];
                }
                cols[colIndex] = col;
            }

            for (int rowIndex = 0; rowIndex < grid.Length; rowIndex++)
            {
                int[] row = grid[rowIndex];
                foreach(var col in cols)
                {
                    bool equals = true;
                    for(int i = 0; i < row.Length; i++)
                    {
                        if (col[i] != row[i])
                        {
                            equals = false;
                            break;
                        }
                    }
                    if (equals)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }

}