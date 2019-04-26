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
            var additionalDelimiter = "";
            if (input.StartsWith("//"))
            {
                input = input.Replace("\n", "~");
                int startIndex = getIndexOfLastCharInSequence(input, "//");
                int endIndex = input.IndexOf("~;");

                additionalDelimiter = "|" + input.Substring(startIndex, endIndex - startIndex);
                input = input.Substring(getIndexOfLastCharInSequence(input, "~;"));
            }
            return ",|\n" + additionalDelimiter;
        }

        private static int getIndexOfLastCharInSequence(string input, string sequence)
        {
            return input.IndexOf(sequence) + sequence.Length;
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