namespace AdventOfCode2021
{
    internal class Day5 : Day
    {
        private const string COORDINATES_SEPARATOR = " -> ";
        private const string NUMBERS_SEPARATOR = ",";
        private const int MAP_LENGTH = 1000;
        private const int MIN_LINES_OVERLAP = 2;

        protected override long Part1(IList<string> list)
        {
            int[,] map = new int[1000, 1000];

            for(int index = 0; index < list.Count; index++)
            {
                string[] coordinates = list[index].Split(COORDINATES_SEPARATOR);
                string[] origCoordinate = coordinates[0].Split(NUMBERS_SEPARATOR);
                string[] destCoordinate = coordinates[1].Split(NUMBERS_SEPARATOR);

                int x1 = int.Parse(origCoordinate[0]);
                int y1 = int.Parse(origCoordinate[1]);
                int x2 = int.Parse(destCoordinate[0]);
                int y2 = int.Parse(destCoordinate[1]);

                if(x1 == x2 && y1 == y2)
                {
                    map[x1, y1]++;
                }
                else if(x1 == x2)
                {
                    int x = x1;

                    for(int y = y1; (y1 < y2 && y <= y2) || (y1 > y2 && y >= y2); y = (y1 < y2)? y + 1 : y - 1)
                    {
                        map[x, y]++;
                    }
                }
                else if(y1 == y2)
                {
                    int y = y1;

                    for (int x = x1; (x1 < x2 && x <= x2) || (x1 > x2 && x >= x2); x = (x1 < x2) ? x + 1 : x - 1)
                    {
                        map[x, y]++;
                    }
                }
            }

            int minLinesOverlapSum = 0;
            for(int x = 0; x < MAP_LENGTH; x++)
            {
                for(int y = 0; y < MAP_LENGTH; y++)
                {
                    if(map[x, y] >= MIN_LINES_OVERLAP)
                    {
                        minLinesOverlapSum++;
                    }
                }
            }

            return minLinesOverlapSum;
        }

        protected override long Part2(IList<string> list)
        {
            int[,] map = new int[1000, 1000];

            for (int index = 0; index < list.Count; index++)
            {
                string[] coordinates = list[index].Split(COORDINATES_SEPARATOR);
                string[] origCoordinate = coordinates[0].Split(NUMBERS_SEPARATOR);
                string[] destCoordinate = coordinates[1].Split(NUMBERS_SEPARATOR);

                int x1 = int.Parse(origCoordinate[0]);
                int y1 = int.Parse(origCoordinate[1]);
                int x2 = int.Parse(destCoordinate[0]);
                int y2 = int.Parse(destCoordinate[1]);

                if (x1 == x2 && y1 == y2)
                {
                    map[x1, y1]++;
                }
                else if (x1 == x2)
                {
                    int x = x1;

                    for (int y = y1; (y1 < y2 && y <= y2) || (y1 > y2 && y >= y2); y = (y1 < y2) ? y + 1 : y - 1)
                    {
                        map[x, y]++;
                    }
                }
                else if (y1 == y2)
                {
                    int y = y1;

                    for (int x = x1; (x1 < x2 && x <= x2) || (x1 > x2 && x >= x2); x = (x1 < x2) ? x + 1 : x - 1)
                    {
                        map[x, y]++;
                    }
                }
                else
                {
                    for (int x = x1, y = y1; ((x1 < x2 && x <= x2) || (x1 > x2 && x >= x2)) && ((y1 < y2 && y <= y2) || (y1 > y2 && y >= y2)); x = (x1 < x2) ? x + 1 : x - 1, y = (y1 < y2) ? y + 1 : y - 1)
                    {
                        map[x, y]++;
                    }
                }
            }

            int minLinesOverlapSum = 0;
            for (int x = 0; x < MAP_LENGTH; x++)
            {
                for (int y = 0; y < MAP_LENGTH; y++)
                {
                    if (map[x, y] >= MIN_LINES_OVERLAP)
                    {
                        minLinesOverlapSum++;
                    }
                }
            }

            return minLinesOverlapSum;
        }
    }
}