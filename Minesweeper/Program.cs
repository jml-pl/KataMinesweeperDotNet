using System;
using System.IO;

namespace Minesweeper
{
    public class Program
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
            GenerateBoard(boardsFile);
            return 0;
        }

        public static void GenerateBoard(string boards)
        {
            int offset = 0;
            int boardNo = 1;

            string[] boardsLines = boards.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            while (offset < boardsLines.Length)
            {
                int[,] board = new int[Int32.Parse(boardsLines[0 + offset][0].ToString()), Int32.Parse(boardsLines[0 + offset][2].ToString())];
                if (board.GetLength(0) > 0) {
                    if (offset > 0)
                    {
                        Console.WriteLine();
                    }
                    Console.WriteLine("Field #{0}:", boardNo);
                }
                

                //for each field
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        //check if field is a mine
                        if (boardsLines[i + 1 + offset][j] == '*')
                        {
                            board[i, j] = 9;

                            //we add our mine to neighbour counters
                            for (int iNeighbour = i - 1; iNeighbour <= i + 1; iNeighbour++)
                            {
                                for (int jNeighbour = j - 1; jNeighbour <= j + 1; jNeighbour++)
                                {
                                    //if we are still on board
                                    if (iNeighbour >= 0 && iNeighbour < board.GetLength(0) && jNeighbour >= 0 && jNeighbour < board.GetLength(1) && (iNeighbour != i || jNeighbour != j))
                                    {
                                        board[iNeighbour, jNeighbour]++;
                                    }

                                }
                            }
                        }
                    }
                }
                PrintBoard(board);
                offset += board.GetLength(0) + 1;
                boardNo++;
            }

        }

        static void PrintBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] >= 9)
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
