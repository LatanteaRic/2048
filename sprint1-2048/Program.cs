using System;

namespace Console2048
{
    class Program
    {
        static int[,] grid = new int[4, 4];
        static Random random = new Random();

        static void Main()
        {
            InitializeGame();
            PrintGrid();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                HandleInput(keyInfo);
                PrintGrid();
            }
        }

        static void InitializeGame()
        {
            GenerateRandomTile();
            GenerateRandomTile();
        }

        static void PrintGrid()
        {
            Console.Clear();
            Console.WriteLine("2048 Game");
            Console.WriteLine();

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.Write($"{grid[row, col],-6}");
                }
                Console.WriteLine();
            }
        }

        static void HandleInput(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Move(Direction.Right);
                    break;
            }
        }

        static void Move(Direction direction)
        {
            bool moved = false;

            switch (direction)
            {
                case Direction.Up:
                    for (int col = 0; col < 4; col++)
                        moved |= MoveColumnUp(col);
                    break;
                case Direction.Down:
                    for (int col = 0; col < 4; col++)
                        moved |= MoveColumnDown(col);
                    break;
                case Direction.Left:
                    for (int row = 0; row < 4; row++)
                        moved |= MoveRowLeft(row);
                    break;
                case Direction.Right:
                    for (int row = 0; row < 4; row++)
                        moved |= MoveRowRight(row);
                    break;
            }

            if (moved)
                GenerateRandomTile();
        }

        static bool MoveColumnUp(int col)
        {
            bool moved = false;

            for (int row = 1; row < 4; row++)
            {
                if (grid[row, col] != 0)
                {
                    int currentRow = row;
                    while (currentRow > 0 && grid[currentRow - 1, col] == 0)
                    {
                        grid[currentRow - 1, col] = grid[currentRow, col];
                        grid[currentRow, col] = 0;
                        currentRow--;
                        moved = true;
                    }

                    if (currentRow > 0 && grid[currentRow - 1, col] == grid[currentRow, col])
                    {
                        grid[currentRow - 1, col] *= 2;
                        grid[currentRow, col] = 0;
                        moved = true;
                    }
                }
            }

            return moved;
        }

        static bool MoveColumnDown(int col)
        {
            bool moved = false;

            for (int row = 2; row >= 0; row--)
            {
                if (grid[row, col] != 0)
                {
                    int currentRow = row;
                    while (currentRow < 3 && grid[currentRow + 1, col] == 0)
                    {
                        grid[currentRow + 1, col] = grid[currentRow, col];
                        grid[currentRow, col] = 0;
                        currentRow++;
                        moved = true;
                    }

                    if (currentRow < 3 && grid[currentRow + 1, col] == grid[currentRow, col])
                    {
                        grid[currentRow + 1, col] *= 2;
                        grid[currentRow, col] = 0;
                        moved = true;
                    }
                }
            }

            return moved;
        }

        static bool MoveRowLeft(int row)
        {
            bool moved = false;

            for (int col = 1; col < 4; col++)
            {
                if (grid[row, col] != 0)
                {
                    int currentCol = col;
                    while (currentCol > 0 && grid[row, currentCol - 1] == 0)
                    {
                        grid[row, currentCol - 1] = grid[row, currentCol];
                        grid[row, currentCol] = 0;
                        currentCol--;
                        moved = true;
                    }

                    if (currentCol > 0 && grid[row, currentCol - 1] == grid[row, currentCol])
                    {
                        grid[row, currentCol - 1] *= 2;
                        grid[row, currentCol] = 0;
                        moved = true;
                    }
                }
            }

            return moved;
        }

        static bool MoveRowRight(int row)
        {
            bool moved = false;

            for (int col = 2; col >= 0; col--)
            {
                if (grid[row, col] != 0)
                {
                    int currentCol = col;
                    while (currentCol < 3 && grid[row, currentCol + 1] == 0)
                    {
                        grid[row, currentCol + 1] = grid[row, currentCol];
                        grid[row, currentCol] = 0;
                        currentCol++;
                        moved = true;
                    }

                    if (currentCol < 3 && grid[row, currentCol + 1] == grid[row, currentCol])
                    {
                        grid[row, currentCol + 1] *= 2;
                        grid[row, currentCol] = 0;
                        moved = true;
                    }
                }
            }

            return moved;
        }

        static void GenerateRandomTile()
        {
            int emptyCells = CountEmptyCells();

            if (emptyCells == 0)
                return;

            int randomIndex = random.Next(emptyCells);
            int count = 0;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (grid[row, col] == 0)
                    {
                        if (count == randomIndex)
                        {
                            grid[row, col] = (random.Next(1, 3) == 1) ? 2 : 4;
                            return;
                        }
                        count++;
                    }
                }
            }
        }

        static int CountEmptyCells()
        {
            int count = 0;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (grid[row, col] == 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
