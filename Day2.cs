namespace AdventOfCode2021
{
    internal sealed class Day2 : Day
    {
        private const string FORWARD = "forward";
        private const string DOWN = "down";
        private const string UP = "up";
        private const string SEPARATOR = " ";

        protected override long Part1(IList<string> list)
        {
            int horizontal = 0;
            int depth = 0;

            foreach (string item in list)
            {
                string[] itemSplit = item.Split(SEPARATOR);
                string direction = itemSplit[0];
                
                if(int.TryParse(itemSplit[1], out int value))
                {
                    if (string.Equals(direction, FORWARD))
                    {
                        horizontal += value;
                    }
                    else if(string.Equals(direction, DOWN))
                    {
                        depth += value;
                    }
                    else if(string.Equals(direction, UP))
                    {
                        depth -= value;
                    }
                }
            }

            return horizontal * depth;
        }

        protected override long Part2(IList<string> list)
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach (string item in list)
            {
                string[] itemSplit = item.Split(SEPARATOR);
                string direction = itemSplit[0];

                if (int.TryParse(itemSplit[1], out int value))
                {
                    if (string.Equals(direction, FORWARD))
                    {
                        horizontal += value;
                        depth += aim * value;
                    }
                    else if (string.Equals(direction, DOWN))
                    {
                        aim += value;
                    }
                    else if (string.Equals(direction, UP))
                    {
                        aim -= value;
                    }
                }
            }

            return horizontal * depth;
        }
    }
}