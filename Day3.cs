using System.Text;

namespace AdventOfCode2021
{
    internal class Day3 : Day
    {
        private const char ZERO_BIT = '0';
        private const char ONE_BIT = '1';

        protected override long Part1(IList<string> list)
        {
            int binaryLength = 12;

            int[] zeroOccurrences = new int[binaryLength];
            int[] oneOcurrences = new int[binaryLength];
            
            foreach (string item in list)
            {
                for(int index = 0; index < binaryLength; index++)
                {
                    char bit = item[index];
                    if (bit == ZERO_BIT)
                    {
                        zeroOccurrences[index]++;
                    }
                    else if(bit == ONE_BIT)
                    {
                        oneOcurrences[index]++;
                    }
                }
            }

            StringBuilder mostCommonBitsBuilder = new();
            StringBuilder leastCommonBitsBuilder = new();

            for (int index = 0; index < binaryLength; index++)
            {
                if(zeroOccurrences[index] >= oneOcurrences[index])
                {
                    mostCommonBitsBuilder.Append(ZERO_BIT);
                    leastCommonBitsBuilder.Append(ONE_BIT);
                }
                else if(zeroOccurrences[index] < oneOcurrences[index])
                {
                    mostCommonBitsBuilder.Append(ONE_BIT);
                    leastCommonBitsBuilder.Append(ZERO_BIT);
                }
            }

            int gammaRate = Convert.ToInt32(mostCommonBitsBuilder.ToString(), 2);
            int epsilonRate = Convert.ToInt32(leastCommonBitsBuilder.ToString(), 2);

            return gammaRate * epsilonRate;
        }

        protected override long Part2(IList<string> list)
        {
            int binaryLength = 12;

            IList<string> validMostCommonBitNumbers = new List<string>(list);
            for (int index = 0; index < binaryLength && validMostCommonBitNumbers.Count >= 2; index++)
            {
                int[] zeroOccurrences = new int[binaryLength];
                int[] oneOcurrences = new int[binaryLength];

                foreach (string item in validMostCommonBitNumbers)
                {
                    char bit = item[index];
                    if (bit == ZERO_BIT)
                    {
                        zeroOccurrences[index]++;
                    }
                    else if (bit == ONE_BIT)
                    {
                        oneOcurrences[index]++;
                    }
                }

                if (zeroOccurrences[index] > oneOcurrences[index])
                {
                    validMostCommonBitNumbers = validMostCommonBitNumbers.Where<string>(item => item[index] == ZERO_BIT).ToList();
                }
                else if (zeroOccurrences[index] <= oneOcurrences[index])
                {
                    validMostCommonBitNumbers = validMostCommonBitNumbers.Where<string>(item => item[index] == ONE_BIT).ToList();
                }
            }
            int oxygenGeneratorRating = Convert.ToInt32(validMostCommonBitNumbers.FirstOrDefault("-1"), 2);
            
            IList<string> validLeastCommonBitNumbers = new List<string>(list);
            for (int index = 0; index < binaryLength && validLeastCommonBitNumbers.Count >= 2; index++)
            {
                int[] zeroOccurrences = new int[binaryLength];
                int[] oneOcurrences = new int[binaryLength];

                foreach (string item in validLeastCommonBitNumbers)
                {
                    char bit = item[index];
                    if (bit == ZERO_BIT)
                    {
                        zeroOccurrences[index]++;
                    }
                    else if (bit == ONE_BIT)
                    {
                        oneOcurrences[index]++;
                    }
                }

                if (zeroOccurrences[index] > oneOcurrences[index])
                {
                    validLeastCommonBitNumbers = validLeastCommonBitNumbers.Where<string>(item => item[index] == ONE_BIT).ToList();
                }
                else if (zeroOccurrences[index] <= oneOcurrences[index])
                {
                    validLeastCommonBitNumbers = validLeastCommonBitNumbers.Where<string>(item => item[index] == ZERO_BIT).ToList();
                }
            }
            int CO2ScrubberRating = Convert.ToInt32(validLeastCommonBitNumbers.FirstOrDefault("-1"), 2);

            return oxygenGeneratorRating * CO2ScrubberRating;
        }
    }
}