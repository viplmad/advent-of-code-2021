namespace AdventOfCode2021
{
    internal abstract class Day
    {
        public long Action(int part, string filePath)
        {
            IList<string> list = ReadFile(filePath);

            if (part == 1)
            {
                return Part1(list);
            }
            else if (part == 2)
            {
                return Part2(list);
            }

            return -1;
        }

        private static IList<string> ReadFile(string filePath)
        {
            IList<string> list = new List<string>();

            // Read the file and display it line by line.  
            foreach (string line in File.ReadLines(filePath))
            {
                list.Add(line);
            }

            return list;
        }

        protected abstract long Part1(IList<string> list);
        protected abstract long Part2(IList<string> list);
    }
}