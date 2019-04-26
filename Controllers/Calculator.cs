using System;
using System.Text.RegularExpressions;

namespace Eventim
{
    internal class Calculator
    {
        internal int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }
            string[] digitArray = ExtractDigitArray(ref input);
            var result = CalculateAddition(digitArray);
            return result;
        }

        private static string[] ExtractDigitArray(ref string input)
        {
            string delimiter = ExtractDelimiter(ref input);
            var digitArray = Regex.Split(input, delimiter);
            return digitArray;
        }

        private static string ExtractDelimiter(ref string input)
        {
            var delimiter = "";
            if (input.StartsWith("//"))
            {
                input = input.Replace("\n", "~");
                int pFrom = input.IndexOf("//") + "//".Length;
                int pTo = input.IndexOf("~;");

                string result = input.Substring(pFrom, pTo - pFrom);

                delimiter = "|" + result;

                input = input.Substring(input.IndexOf("~;") + "~;".Length);

            }
            return ",|\n" + delimiter;
        }



        private static int CalculateAddition(string[] arr)
        {
            int result = 0;
            foreach (string number in arr)
            {
                result += Convert.ToInt32(number);
            }
            return result;
        }
    }
}