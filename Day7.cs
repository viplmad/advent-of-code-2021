namespace AdventOfCode2021
{
    internal class Day7 : Day
    {
        private const string NUMBERS_SEPARATOR = ",";

        protected override long Part1(IList<string> list)
        {
            string[] positions = list.FirstOrDefault(string.Empty).Split(NUMBERS_SEPARATOR);

            // Make sure the list is sorted
            List<int> sortedPositions = positions.Select<string, int>(pos => int.Parse(pos)).ToList();
            sortedPositions.Sort();

            //get the median
            int count = sortedPositions.Count;
            int mid = count / 2;
            int median = (count % 2 != 0) ? sortedPositions[mid] : (sortedPositions[mid] + sortedPositions[mid - 1]) / 2;

            int fuel = 0;
            foreach(int position in sortedPositions)
            {
                fuel += Math.Abs(median - position);
            }

            return fuel;
        }

        protected override long Part2(IList<string> list)
        {
            string[] numbers = list.FirstOrDefault(string.Empty).Split(NUMBERS_SEPARATOR);

            // Make sure the list is sorted
            List<int> positions = numbers.Select<string, int>(pos => int.Parse(pos)).ToList();

            //get the median
            int count = positions.Count;
            int sum = positions.Sum(pos => pos);
            long mean = sum / count;

            return CalculateFuel(positions, mean);
        }

        private static long CalculateFuel(IList<int> positions, long finalPos)
        {
            long fuel = 0;

            foreach (int position in positions)
            {
                long diff = Math.Abs(finalPos - position);

                // https://www.reddit.com/r/adventofcode/comments/rawxad/2021_day_7_part_2_i_wrote_a_paper_on_todays/
                long diffSum = (long)((Math.Pow(diff, 2) + diff) / 2);
                fuel += diffSum;
            }

            return fuel;
        }
    }
}