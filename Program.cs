using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp__TicTacToe_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] grid = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool isPlayer1Turn = true;
            int numTurns = 0;

            while (!Victory() && numTurns != 9)
            {
                PrintGrid();
                if (isPlayer1Turn)
                {
                    Console.WriteLine("Player 1 turn!");
                }
                else
                {
                    Console.WriteLine("Player 2 turn!");
                }
                string choice = Console.ReadLine();

                if(grid.Contains(choice) && choice != "X" && choice != "O")
                {
                    int gridIndex = Convert.ToInt32(choice) - 1;

                    if (isPlayer1Turn)
                    {
                        grid[gridIndex] = "X";
                    }
                    else
                    {
                        grid[gridIndex] = "O";
                    }
                    numTurns++;
                }
                isPlayer1Turn = !isPlayer1Turn;
            }

            if (Victory())
            {
                Console.WriteLine("You win!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Tie!");
                Console.ReadLine();
            }

            bool Victory()
            {
                bool row1 = grid[0] == grid[1] && grid[1] == grid[2];
                bool row2 = grid[3] == grid[4] && grid[4] == grid[5];
                bool row3 = grid[6] == grid[7] && grid[7] == grid[8];
                bool col1 = grid[8] == grid[3] && grid[3] == grid[6];
                bool col2 = grid[1] == grid[4] && grid[4] == grid[7];
                bool col3 = grid[2] == grid[5] && grid[5] == grid[8];
                bool diagonalDown = grid[0] == grid[4] && grid[4] == grid[8];
                bool diagonalUp = grid[6] == grid[4] && grid[4] == grid[2];

                return row1 || row2 || row3 || col1 || col2 || col3 || diagonalDown || diagonalUp;
            }

            void PrintGrid()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(grid[i * 3 + j] + "|");
                    }
                    Console.WriteLine();
                    Console.WriteLine("------");
                }
            }
        }
    }
}
