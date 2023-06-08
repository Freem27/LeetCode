namespace _012IntegerToRoman
{
    internal class TestCase
    {
        public TestCase(int value, string expectedResult)
        {
            Value = value;
            ExpectedResult = expectedResult;
        }

        public int Value { get; set; }
        public string ExpectedResult { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var testCases = new List<TestCase> {
                new TestCase(3, "III"),
                new TestCase(4, "IV"),
                new TestCase(40, "XL"),
                new TestCase(400, "CD"),
                new TestCase(5, "V"),
                new TestCase(6, "VI"),
                new TestCase(677, "DCLXXVII"),
                new TestCase(7, "VII"),
                new TestCase(9, "IX"),
                new TestCase(90, "XC"),
                new TestCase(900, "CM"),
                new TestCase(58, "LVIII"),
                new TestCase(1994, "MCMXCIV"),
            };

            Solution s =new Solution();
            foreach (var testCase in testCases)
            {
                var result = s.IntToRoman(testCase.Value);
                if(result != testCase.ExpectedResult)
                {
                    Console.WriteLine($"Value: {testCase.Value}, Result: {result}, ExpectedResult: {testCase.ExpectedResult}");
                }
            }
        }
    }
    public class Solution
    {
                                                 //   0    1    2    3    4    5    6
        private static char[] Symbols =  new char[] { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
        private static int[] Values =     new int[] {  1,   5,   10,  50, 100, 500, 1000 };

        public string IntToRoman(int num)
        {
            string result = "";
            int multiplier = 0;
            while(num > 10)
            {
                var rightDight = num % 10;
                num = num / 10;
                multiplier++;
                result = DightToRoman(rightDight, multiplier) + result;
            }
            multiplier++;
            result = DightToRoman(num, multiplier) + result;
            return result;
        }

        private string DightToRoman(int num, int multiplyer)
        {
            if(num == 0)
            {
                return "";
            }
            int index = Array.IndexOf(Values, (int)(num * Math.Pow(10, multiplyer - 1)));
            if (index > 0)
            {
                return Symbols[index].ToString();
            }

            int baseIndex = GetBaseIndex(multiplyer);

            if (num < 5)
            {
                if (num == 4)
                {
                    return $"{Symbols[baseIndex]}{Symbols[baseIndex + 1]}";
                }
                return new string(Symbols[baseIndex], num);
            }
            else
            {
                if (num == 9)
                {
                    return $"{Symbols[baseIndex]}{Symbols[GetBaseIndex(multiplyer + 1)]}";
                }
                return $"{Symbols[GetBaseIndex(multiplyer) + 1]}" + new string(Symbols[baseIndex], num - 5);
            }

        }

        private int GetBaseIndex(int multiplyer)
        {
            switch (multiplyer)
            {
                case 0:
                case 1:
                    return 0;
                case 2:
                    return 2;
                case 3:
                    return 4;
                case 4:
                    return 6;
                default:
                    throw new ApplicationException($"Unexpected multiplier: {multiplyer}");
            }
        }
    }
}