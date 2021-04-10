using System;

namespace OOPHomework1Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board myBoard = new Board();
            int counter = 0;
            myBoard.PrintBoard();
            Console.Write("Press ENTER to insert the first piece...");
            Console.ReadKey();
            while (counter < 8)
            {
                do { } while (!myBoard.InsertPiece(RandomInt(8), RandomInt(8)));
                Console.Clear();
                myBoard.PrintBoard();
                if (counter != 7)
                {
                    Console.Write((counter + 1) + "/" + (8) + ". Press ENTER to insert next piece...");
                }
                else
                {
                    Console.Write("All pieces are inserted, Press ENTER to terminate...");
                }
                Console.ReadKey();
                counter++;
            }
        }

        static int RandomInt(int max)
        {
            var random = new Random();
            return random.Next(max);
        }
    }

    class Board
    {
        public Board()
        {
            ArrBoard = new int[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ArrBoard[i, j] = 0;
                }
            }
        }

        private int[,] ArrBoard;

        public void PrintBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(ArrBoard[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool CheckAvailability(int row, int column)
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

        public bool InsertPiece(int row, int column)
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
