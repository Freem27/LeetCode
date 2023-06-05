namespace _008StringToIntegerATOI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tests = new List<string>
            {
                "2147483648",
                "  -0012a42",
                "+1",
                "42",
                "   -42",
                "4193 with words",
                "words and 987",
                "-91283472332",
            };
            Solution solution = new Solution();
            tests.ForEach(test =>
            {
                Console.WriteLine($"input: {test} output: {solution.MyAtoi(test)}");
            });
        }
    }
    public class Solution
    {
        public int MyAtoi(string s)
        {
            bool minus = false;
            int result = 0;
            string step = "NONE";
            int numIndex = 0;
            foreach(char c in s)
            {
                bool stop = false;
                switch (step)
                {
                    case "NONE":
                        if (c == ' ')
                        {
                            break;
                        }
                        else if (c == '+')
                        {
                            step = "NUMBER";
                        }else if (c == '-')
                        {
                            minus = true;
                            step = "NUMBER";
                        }
                        else if (IsDight(c))
                        {
                            result = ToInt(c);
                            numIndex++;
                            step = "NUMBER";
                        }
                        else
                        {
                            return 0;
                        }
                        break;
                    case "NUMBER":
                        if (!IsDight(c))
                        {
                            stop = true;
                            break;
                        }
                        else
                        {
                            if(result > 214748364.8d)
                            {
                                return minus ? Int32.MinValue : Int32.MaxValue;
                            }
                            result = result * 10 + ToInt(c);
                            if(result < 0)
                            {
                                return minus ? Int32.MinValue : Int32.MaxValue;
                            }
                        }
                        break;
                }

                if (stop)
                {
                    break;
                }
            }

            if (minus)
            {
                result = -result;
            }

            return result;
        }

        private bool IsDight(char c)
        {
            return (int)c >= 48 && (int)c <= 57;
        }

        private int ToInt(char c)
        {
            return (int)c - 48;
        }
    }
}