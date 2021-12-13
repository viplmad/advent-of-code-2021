namespace AdventOfCode2021
{
    internal class Day9 : Day
    {
        private const int MAX_NUMBER = 9;

        protected override long Part1(IList<string> list)
        {
            int lowPoints = 0;

            for (int rowIndex = 0; rowIndex < list.Count; rowIndex++)
            {
                int columnCount = list[rowIndex].Length;
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    int centerNumber = GetIntChar(list, rowIndex, columnIndex);

                    int leftNumber = GetIntChar(list, rowIndex, columnIndex - 1);
                    int rightNumber = GetIntChar(list, rowIndex, columnIndex + 1);
                    int upNumber = GetIntChar(list, rowIndex - 1, columnIndex);
                    int downNumber = GetIntChar(list, rowIndex + 1, columnIndex);

                    if (leftNumber > centerNumber && rightNumber > centerNumber && upNumber > centerNumber && downNumber > centerNumber)
                    {
                        lowPoints += centerNumber + 1;
                    }
                }
            }

            return lowPoints;
        }

        protected override long Part2(IList<string> list)
        {
            int[] largestBasins = new int[3];

            for (int rowIndex = 0; rowIndex < list.Count; rowIndex++)
            {
                int columnCount = list[rowIndex].Length;
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    int centerNumber = GetIntChar(list, rowIndex, columnIndex);

                    int leftNumber = GetIntChar(list, rowIndex, columnIndex - 1);
                    int rightNumber = GetIntChar(list, rowIndex, columnIndex + 1);
                    int upNumber = GetIntChar(list, rowIndex - 1, columnIndex);
                    int downNumber = GetIntChar(list, rowIndex + 1, columnIndex);

                    if (leftNumber > centerNumber && rightNumber > centerNumber && upNumber > centerNumber && downNumber > centerNumber)
                    {
                        int basinSize = 1;
                        
                        // Up
                        for(int basinRowIndex = rowIndex - 1; basinRowIndex >= 0; basinRowIndex--)
                        {
                            if(GetIntChar(list, basinRowIndex, columnIndex) < MAX_NUMBER)
                            {
                                basinSize++;

                                // Up Left
                                for(int basinColumnIndex = columnIndex - 1; basinColumnIndex >= 0; basinColumnIndex--)
                                {
                                    if(GetIntChar(list, basinRowIndex, basinColumnIndex) < MAX_NUMBER)
                                    {
                                        basinSize++;
                                    }
                                }

                                // Up Right
                                for (int basinColumnIndex = columnIndex + 1; basinColumnIndex < columnCount; basinColumnIndex++)
                                {
                                    if (GetIntChar(list, basinRowIndex, basinColumnIndex) < MAX_NUMBER)
                                    {
                                        basinSize++;
                                    }
                                }
                            }
                        }

                        // Down
                        for (int basinRowIndex = rowIndex + 1; basinRowIndex < list.Count; basinRowIndex++)
                        {
                            if (GetIntChar(list, basinRowIndex, columnIndex) < MAX_NUMBER)
                            {
                                basinSize++;

                                // Down Left
                                for (int basinColumnIndex = columnIndex - 1; basinColumnIndex >= 0; basinColumnIndex--)
                                {
                                    if (GetIntChar(list, basinRowIndex, basinColumnIndex) < MAX_NUMBER)
                                    {
                                        basinSize++;
                                    }
                                }

                                // Down Right
                                for (int basinColumnIndex = columnIndex + 1; basinColumnIndex < columnCount; basinColumnIndex++)
                                {
                                    if (GetIntChar(list, basinRowIndex, basinColumnIndex) < MAX_NUMBER)
                                    {
                                        basinSize++;
                                    }
                                }
                            }
                        }

                        // Left
                        for (int basinColumnIndex = columnIndex - 1; basinColumnIndex >= 0; basinColumnIndex--)
                        {
                            if (GetIntChar(list, rowIndex, basinColumnIndex) < MAX_NUMBER)
                            {
                                basinSize++;
                            }
                        }

                        // Right
                        for (int basinColumnIndex = columnIndex + 1; basinColumnIndex < columnCount; basinColumnIndex++)
                        {
                            if (GetIntChar(list, rowIndex, basinColumnIndex) < MAX_NUMBER)
                            {
                                basinSize++;
                            }
                        }

                        int lowerBasinIndex = Array.FindIndex(largestBasins, size => size < basinSize);
                        if (lowerBasinIndex >= 0)
                        {
                            largestBasins[lowerBasinIndex] = basinSize;
                        }
                    }
                }
            }

            return largestBasins[0] * largestBasins[1] * largestBasins[2];
        }

        private static int GetIntChar (IList<string> list, int rowIndex, int columnIndex) {
            if(rowIndex >= list.Count || rowIndex < 0
                || columnIndex >= list.ElementAt(rowIndex).Length || columnIndex < 0)
            {
                return MAX_NUMBER;
            }

            return int.Parse(list.ElementAt(rowIndex).ElementAt(columnIndex).ToString());
        }
    }
}