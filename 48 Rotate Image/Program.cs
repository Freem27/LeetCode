namespace _48_Rotate_Image
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var testCases = new List<TestCase> {
                //new TestCase(new int[][]{ new int[] {1,2,3 }, new int[] {4,5,6 }, new int[] {7,8,9 }}),
                //new TestCase(new int[][]{ new int[] {5,1,9,11 }, new int[] {2,4,8,10}, new int[] {13,3,6,7}, new int[]{ 15,14,12,16} }),
                new TestCase(new int[][]{   new int[] {1,1,1,1,1,1,1,1 },
                                            new int[] {2,2,2,2,2,2,2,2 },
                                            new int[] {3,3,3,3,3,3,3,3 },
                                            new int[] {4,4,4,4,4,4,4,4 },
                                            new int[] {5,5,5,5,5,5,5,5 },
                                            new int[] {6,6,6,6,6,6,6,6 },
                                            new int[] {7,7,7,7,7,7,7,7 },
                                            new int[] {8,8,8,8,8,8,8,8 },
                }),
            };
            Solution s = new Solution();
            foreach (var testCase in testCases)
            {
                Console.WriteLine($"Matrix\n{string.Join('\n', testCase.Matrix.Select(s => string.Join('\t', s)))}");
                s.Rotate(testCase.Matrix);
                Console.WriteLine();
                Console.WriteLine($"result\n{string.Join('\n', testCase.Matrix.Select(s => string.Join('\t', s)))}");
                Console.WriteLine("=================");
            }
        }
    }

    public class TestCase
    {
        public TestCase(int[][] matrix)
        {
            Matrix = matrix;
        }
        public int[][] Matrix { get; set; }

    }

    public class Solution
    {
        public void Rotate(int[][] matrix)
        {
            int len = matrix.Length;
            for(int start =  0; start <= matrix.Length / 2; start++) {
                int row = start;
                for(int col = start; col < (len == 1 ? 1:len-1); col++)
                {
                    RotateCell(matrix, row, col);
                }
                Console.WriteLine();
                len--;
            }

        }
        private void RotateCell(int[][] matrix, int row, int col)
        {
            int first = matrix[row][col];
            int n = matrix.Length - 1;
            matrix[row][col] = matrix[n - col][row]; //up
            matrix[n - col][row] = matrix[n-row][n - col];//left
            matrix[n - row][n - col] = matrix[col][n - row];//down
            matrix[col][n - row] = first;//right
        }
    }
}