namespace AdventOfCode2021
{
    internal sealed class Day1 : Day
    {
        protected override int Part1(IList<string> list)
        {
            int result = 0;

            int previousValue = int.Parse(list.FirstOrDefault("-1"));
            foreach (string item in list)
            {
                int value = int.Parse(item);

                if(value > previousValue)
                {
                    result++;

                }
                previousValue = value;
            }

            return result;
        }

        protected override int Part2(IList<string> list)
        {
            int result = 0;

            int windowLength = 3;

            Range startingWindowRange = new(0, windowLength);
            int previousValue = list.Take(startingWindowRange).Sum(item => int.Parse(item));
            for (int index = 0; index < list.Count; index++)
            {
                Range windowRange = new(index, index + windowLength);
                int value = list.Take(windowRange).Sum(item => int.Parse(item));
                if (value > previousValue)
                {
                    result++;
                }

                previousValue = value;
            }

            return result;
        }
    }
}
