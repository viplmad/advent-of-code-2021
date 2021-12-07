namespace AdventOfCode2021
{
    internal class Day6 : Day
    {
        private const string AGES_SEPARATOR = ",";
        private const int AGE_TIRED_LANTERNFISH = 6;
        private const int AGE_NEW_LANTERNFISH = 8;

        protected override long Part1(IList<string> list)
        {
            int maxDays = 80;

            string[] ages = list.FirstOrDefault(string.Empty).Split(AGES_SEPARATOR);
            IList<int> lanternFishes = ages.Select<string, int>(age => int.Parse(age)).ToList();

            for (int day = 0; day < maxDays; day++)
            {
                int originalCount = lanternFishes.Count;
                for (int index = 0; index < originalCount; index++)
                {
                    int lanternAge = lanternFishes[index];

                    int newAge;
                    if (lanternAge == 0)
                    {
                        lanternFishes.Add(AGE_NEW_LANTERNFISH);
                        newAge = AGE_TIRED_LANTERNFISH;
                    }
                    else
                    {
                        newAge = lanternAge - 1;
                    }

                    lanternFishes[index] = newAge;
                }
            }

            return lanternFishes.Count;
        }

        protected override long Part2(IList<string> list)
        {
            int maxDays = 256;

            string[] ages = list.FirstOrDefault(string.Empty).Split(AGES_SEPARATOR);

            long[] lanternAgesCount = new long[AGE_NEW_LANTERNFISH + 1];
            ages.ToList().ForEach(age => lanternAgesCount[int.Parse(age)]++);

            for (int day = 0; day < maxDays; day++)
            {
                long zeroCount = lanternAgesCount[0];

                for(int age = 1; age < lanternAgesCount.Length; age++)
                {
                    long ageCount = lanternAgesCount[age];
                    lanternAgesCount[age - 1] = ageCount;
                }

                // Add tired
                lanternAgesCount[AGE_TIRED_LANTERNFISH] += zeroCount;
                // Add newborn
                lanternAgesCount[AGE_NEW_LANTERNFISH] = zeroCount;
            }

            return lanternAgesCount.Sum(age => age);
        }
    }
}