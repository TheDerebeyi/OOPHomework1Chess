using System;

namespace OOPHomework1Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board myBoard = new Board();
            int counter = 0;
            bool bcache;
            myBoard.PrintBoard();
            Console.Write("Press ENTER to insert next piece...");
            Console.ReadKey();
            while (counter < 8)
            {
                do { } while (!Board.InsertPiece(RandomInt(8), RandomInt(8)));
                Console.Clear();
                myBoard.PrintBoard();
                Console.Write("Press ENTER to insert next piece...");
                Console.ReadKey();
                counter++;
            }
        }

        static int RandomInt(int MAX)
        {
            var random = new Random();
            return random.Next(MAX);
        }

        public class Board
        {
            public Board()
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        ArrBoard[i, j] = 0;
                    }
                }
            }

            public static int[,] ArrBoard = new int[8,8];

            public void PrintBoard()
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write(ArrBoard[i,j]);
                    }
                    Console.WriteLine();
                }
            }

            public static bool CheckAvailability(int row, int column)
            {
                if (ArrBoard[row, column] == 0)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (ArrBoard[row, i] != 0 || ArrBoard[i, column] != 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }

                return false;
            }

            public static bool InsertPiece(int row, int column)
            {
                if (CheckAvailability(row, column))
                {
                    ArrBoard[row, column] = 1;
                    return true;
                }

                return false;
            }
        }
    }
}
