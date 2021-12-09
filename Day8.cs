using System.Text;

namespace AdventOfCode2021
{
    internal class Day8 : Day
    {
        private const string INPUT_OUTPUT_SEPARATOR = " | ";
        private const string NUMBERS_SEPARATOR = " ";
        private const int ONE_PARTS = 2;
        private const int FOUR_PARTS = 4;
        private const int SEVEN_PARTS = 3;
        private const int EIGHT_PARTS = 7;

        protected override long Part1(IList<string> list)
        {
            int firstPartsSum = 0;
            
            foreach (var item in list)
            {
                string[] numbers = item.Split(INPUT_OUTPUT_SEPARATOR);
                string[] outputs = numbers[1].Split(NUMBERS_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);

                firstPartsSum += outputs.Where<string>(output => output.Length == ONE_PARTS || output.Length == FOUR_PARTS || output.Length == SEVEN_PARTS || output.Length == EIGHT_PARTS).Count();
            }

            return firstPartsSum;
        }

        protected override long Part2(IList<string> list)
        {
            int totalNumber = 0;

            foreach (var item in list)
            {
                string[] numbers = item.Split(INPUT_OUTPUT_SEPARATOR);
                string[] inputs = numbers[0].Split(NUMBERS_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
                string[] outputs = numbers[1].Split(NUMBERS_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);

                string[] numberStrings = new string[10];
                numberStrings[1] = inputs.Where<string>(input => input.Length == ONE_PARTS).FirstOrDefault(string.Empty);
                numberStrings[4] = inputs.Where<string>(input => input.Length == FOUR_PARTS).FirstOrDefault(string.Empty);
                numberStrings[7] = inputs.Where<string>(input => input.Length == SEVEN_PARTS).FirstOrDefault(string.Empty);
                numberStrings[8] = inputs.Where<string>(input => input.Length == EIGHT_PARTS).FirstOrDefault(string.Empty);

                numberStrings[3] = inputs.Where<string>(input => input.Length == 5 && ContainsAll(input, numberStrings[1].ToCharArray())).FirstOrDefault(string.Empty);

                char[] diff1And4 = Difference(numberStrings[4], numberStrings[1]);
                numberStrings[5] = inputs.Where<string>(input => input.Length == 5 && ContainsAll(input, diff1And4)).FirstOrDefault(string.Empty);

                numberStrings[2] = inputs.Where<string>(input => input.Length == 5 && !string.Equals(input, numberStrings[5]) && !string.Equals(input, numberStrings[3])).FirstOrDefault(string.Empty);

                numberStrings[6] = inputs.Where<string>(input => input.Length == 6 && !ContainsAll(input, numberStrings[1].ToCharArray())).FirstOrDefault(string.Empty);

                numberStrings[9] = inputs.Where<string>(input => input.Length == 6 && ContainsAll(input, numberStrings[3].ToCharArray())).FirstOrDefault(string.Empty);

                numberStrings[0] = inputs.Where<string>(input => input.Length == 6 && !string.Equals(input, numberStrings[6]) && !string.Equals(input, numberStrings[9])).FirstOrDefault(string.Empty);

                StringBuilder numberStringBuilder = new();
                foreach (string output in outputs)
                {
                    int number = Array.FindIndex(numberStrings, numberString => output.Length == numberString.Length && ContainsAll(numberString, output.ToCharArray()));
                    numberStringBuilder.Append(number);
                }

                int outputNumber = int.Parse(numberStringBuilder.ToString());
                totalNumber += outputNumber;
            }

            return totalNumber;
        }

        private static bool ContainsAll(string numberString, char[] otherNumber)
        {
            return otherNumber.All(l => numberString.Contains(l));
        }

        private static char[] Difference(string oneNumberString, string otherNumberString)
        {
            string longNumberString = oneNumberString;
            string shortNumberString = otherNumberString;
            if(otherNumberString.Length > oneNumberString.Length)
            {
                longNumberString = otherNumberString;
                shortNumberString = oneNumberString;
            }

            return longNumberString.ToCharArray().Where<char>(l => !shortNumberString.Contains(l)).ToArray();
        }
    }
}