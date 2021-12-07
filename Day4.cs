namespace AdventOfCode2021
{
    internal class Day4 : Day
    {
        private const string BINGO_NUMBER_SEPARATOR = ",";
        private const string BOARD_NUMBER_SEPARATOR = " ";
        private const int START_BOARDS_INDEX = 2;
        private const int BOARD_ROWS_COLUMNS = 5;

        protected override long Part1(IList<string> list)
        {
            string[] bingoNumbers = list.FirstOrDefault(string.Empty).Split(BINGO_NUMBER_SEPARATOR);

            int[,] takenNumbers = new int[list.Count, BOARD_ROWS_COLUMNS];
            bool winnerFound = false;
            // Iterate through bingo numbers and check if it exists in any board
            foreach(string bingoNumber in bingoNumbers)
            {
                for (int listIndex = START_BOARDS_INDEX; listIndex + BOARD_ROWS_COLUMNS < list.Count && !winnerFound; listIndex += BOARD_ROWS_COLUMNS + 1)
                {
                    IList<string> board = list.Take(new Range(listIndex, listIndex + BOARD_ROWS_COLUMNS)).ToList();
                    for (int rowIndex = 0; rowIndex < board.Count && !winnerFound; rowIndex++)
                    {
                        int listRowIndex = listIndex + rowIndex;
                        
                        string[] boardRow = board[rowIndex].Split(BOARD_NUMBER_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
                        for (int columnIndex = 0; columnIndex < boardRow.Length && !winnerFound; columnIndex++)
                        {
                            if (string.Equals(bingoNumber, boardRow[columnIndex]))
                            {
                                takenNumbers[listRowIndex, columnIndex]++;

                                // Check winner
                                // Row
                                int[] row = new int[BOARD_ROWS_COLUMNS];
                                for (int cIndex = 0; cIndex < row.Length; cIndex++)
                                {
                                    row[cIndex] = takenNumbers[listRowIndex, cIndex];
                                }

                                if (row.All(boardNum => boardNum > 0))
                                {
                                    winnerFound = true;
                                }

                                // Column
                                int[] column = new int[BOARD_ROWS_COLUMNS];
                                for(int rIndex = 0; rIndex < column.Length; rIndex++)
                                {
                                    column[rIndex] = takenNumbers[listIndex + rIndex, columnIndex];
                                }

                                if (row.All(boardNum => boardNum > 0) || column.All(boardNum => boardNum > 0))
                                {
                                    winnerFound = true;
                                }
                            }
                        }
                    }

                    if (winnerFound)
                    {
                        int notTakenSum = 0;

                        for (int rowIndex = 0; rowIndex < board.Count; rowIndex++)
                        {
                            int listRowIndex = listIndex + rowIndex;

                            string[] boardRow = board[rowIndex].Split(BOARD_NUMBER_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
                            for (int columnIndex = 0; columnIndex < boardRow.Length; columnIndex++)
                            {
                                if (takenNumbers[listRowIndex, columnIndex] == 0)
                                {
                                    notTakenSum += int.Parse(boardRow[columnIndex]);
                                }
                            }
                        }

                        return notTakenSum * int.Parse(bingoNumber);
                    }
                }
            }

            return -1;
        }

        protected override long Part2(IList<string> list)
        {
            string[] bingoNumbers = list.FirstOrDefault(string.Empty).Split(BINGO_NUMBER_SEPARATOR);
            
            int[,] takenNumbers = new int[list.Count, BOARD_ROWS_COLUMNS];
            bool[] wonBoards = new bool[list.Count / BOARD_ROWS_COLUMNS];
            int lastWinnerListIndex = -1;
            string lastWinnerBingoNumber = "-1";
            // Iterate through bingo numbers and check if it exists in any board
            foreach (string bingoNumber in bingoNumbers)
            {
                int boardIndex = 0;
                for (int listIndex = START_BOARDS_INDEX; listIndex + BOARD_ROWS_COLUMNS < list.Count; listIndex += BOARD_ROWS_COLUMNS + 1, boardIndex++)
                {
                    IList<string> board = list.Take(new Range(listIndex, listIndex + BOARD_ROWS_COLUMNS)).ToList();
                    for (int rowIndex = 0; rowIndex < board.Count && !wonBoards[boardIndex]; rowIndex++)
                    {
                        int listRowIndex = listIndex + rowIndex;

                        string[] boardRow = board[rowIndex].Split(BOARD_NUMBER_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
                        for (int columnIndex = 0; columnIndex < boardRow.Length && !wonBoards[boardIndex]; columnIndex++)
                        {
                            if (string.Equals(bingoNumber, boardRow[columnIndex]))
                            {
                                takenNumbers[listRowIndex, columnIndex]++;

                                // Check winner
                                // Row
                                int[] row = new int[BOARD_ROWS_COLUMNS];
                                for (int cIndex = 0; cIndex < row.Length; cIndex++)
                                {
                                    row[cIndex] = takenNumbers[listRowIndex, cIndex];
                                }

                                // Column
                                int[] column = new int[BOARD_ROWS_COLUMNS];
                                for (int rIndex = 0; rIndex < column.Length; rIndex++)
                                {
                                    column[rIndex] = takenNumbers[listIndex + rIndex, columnIndex];
                                }


                                if (row.All(boardNum => boardNum > 0) || column.All(boardNum => boardNum > 0))
                                {
                                    wonBoards[boardIndex] = true;
                                    lastWinnerListIndex = listIndex;
                                    lastWinnerBingoNumber = bingoNumber;
                                }
                            }
                        }
                    }
                }
            }

            int notTakenSum = 0;

            IList<string> winnerBoard = list.Take(new Range(lastWinnerListIndex, lastWinnerListIndex + BOARD_ROWS_COLUMNS)).ToList();
            for (int rowIndex = 0; rowIndex < winnerBoard.Count; rowIndex++)
            {
                int listRowIndex = lastWinnerListIndex + rowIndex;

                string[] boardRow = winnerBoard[rowIndex].Split(BOARD_NUMBER_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
                for (int columnIndex = 0; columnIndex < boardRow.Length; columnIndex++)
                {
                    if (takenNumbers[listRowIndex, columnIndex] == 0)
                    {
                        notTakenSum += int.Parse(boardRow[columnIndex]);
                    }
                }
            }

            return notTakenSum * int.Parse(lastWinnerBingoNumber);
        }
    }
}