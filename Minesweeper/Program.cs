using System;
using System.IO;

namespace Minesweeper
{
    class Program
    {
        static int Main(string[] args)
        {
            
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a path to file with boards.");
                return 1;
            }
            string boardsFile = File.ReadAllText(args[0]);
            /*string boardsFile = String.Join(
                    Environment.NewLine,
                    "5 5",
                    ".....",
                    "..*..",
                    "..*..",
                    "..*..",
                    ".....");
                */
            int offset = 0;
            int boardNo = 1;
           
            string[] boardsLines = boardsFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            while (offset < boardsLines.Length)
            {
                Console.WriteLine("Field #{0}:",boardNo);

                int[,] board = new int[Int32.Parse(boardsLines[0+offset][0].ToString()), Int32.Parse(boardsLines[0 + offset][2].ToString())];

                //for each field
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        //check if field is not a mine
                        if (boardsLines[i + 1 + offset][j] == '*')
                        {
                            board[i, j] = 9;
                        }
                        else
                        {
                            int mines = 0;
                            //we count mines around
                            for (int iNeighbour = i - 1; iNeighbour <= i + 1; iNeighbour++)
                            {
                                for (int jNeighbour = j - 1; jNeighbour <= j + 1; jNeighbour++)
                                {
                                    //if we are still on board
                                    if (iNeighbour >= 0 && iNeighbour < board.GetLength(0) && jNeighbour >= 0 && jNeighbour < board.GetLength(1) && (iNeighbour != i || jNeighbour != j))
                                    {
                                        //we check if there is a mine
                                        if (boardsLines[iNeighbour + 1 + offset][jNeighbour] == '*')
                                        {
                                            mines++;
                                        }
                                    }

                                }
                            }
                            //we save the result for one field
                            board[i, j] = mines;
                        }
                    }
                }
                PrintBoard(board);
                offset += board.GetLength(0) + 1;
                boardNo++;
            }
            return 0;
        }

        static void PrintBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 9)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(board[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
