namespace _007ReverseInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tests = new List<int>
            {
                //10,
                //123,
                //-123,
                //120,
                //1534236469,
                //-2147483648,
                1563847412,
            };
            Solution solution = new Solution();
            tests.ForEach(test =>
            {
                Console.WriteLine($"input: {test} output: {solution.Reverse(test)}");
            });
        }
        public class Solution
        {
            public int Reverse(int x)
            {
                int result = 0;
                bool minus = x < 0;
                if (x == Int32.MinValue)
                {
                    return 0;
                }
                x = Math.Abs(x);
                var rankInt = (int)Math.Log(x, 10);
                while (x >= 10)
                {
                    int lastDight = x % 10;
                    x = (x - lastDight) / 10;
                    if (rankInt >= 9 && lastDight > 2)
                    {
                        return 0;
                    }
                    result = result + lastDight * (int)Math.Pow(10, rankInt--);
                    if(result < 0)
                    {
                        return 0;
                    }
                }
                result = result + x * (int)Math.Pow(10, rankInt);

                if ( minus )
                {
                    result = -result;
                }
                return result;
            }
        }

        public int Reverse2(int x)
        {
            try
            {
                return Int32.Parse(string.Join("", Math.Abs(x).ToString().Reverse()));
            }
            catch (OverflowException)
            {
                return 0;
            }
        }
    }
}