using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace BattleShip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             0 0 0 0 0
             0 0 0 0 0
             0 1 0 0 0
             0 0 0 0 0
             0 0 0 0 1
             */

            // make a game of battleship
            // the computer places some ships
            // the user is asked to guess row / column
            // the computer says whether they've hit / missed
            // when the user has found all the ships, the computer says they've won!
            // Find new goals / have fun!

            // make the grid
            int[,] grid = new int[5, 5];
            int[,] shipLocation = new int[5, 5];
            int ships = 0;
            int misses = 0;

            // place some ships
            // TODO - have the computer randomly place ships

            //shipLocation[1, 1] = 1;
            //shipLocation[3, 4] = 1;
            //shipLocation[2, 2] = 1;
            //shipLocation[4, 0] = 1;
            //shipLocation[0, 3] = 1;

            //Generates a random coordinate for the grid
            int shipsGenerated = 0;
            Random coordinate = new Random();
            int randomNumberx = coordinate.Next(0, 5);
            int randomNumbery = coordinate.Next(0, 5);

            while (shipsGenerated <= 5)
            {

                randomNumberx = coordinate.Next(0, 5);
                randomNumbery = coordinate.Next(0, 5);
                if (shipLocation[randomNumberx, randomNumbery] != 1)
                {
                    shipLocation[randomNumberx, randomNumbery] = 1;
                    //Console.Write($"\n{randomNumberx},{randomNumbery}");
                    shipsGenerated++;
                }

            }





            while (ships < 5 && misses < 5)
            {
            Prompt:
                // print the grid
                for (int row = 0; row < 5; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        Console.Write(grid[row, col]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }

                //prompts user to unput the coordinates
                Console.WriteLine("input x coordinate from 0-4");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("input y coordinate from 0-4");
                int y = Convert.ToInt32(Console.ReadLine());

                //checks to see if user input is within the bounds of the playing field
                if (x > 4 || y > 4)
                {
                    Console.WriteLine("out of bounds! try inputting a number between 0 and 4");
                    goto Prompt;
                }

                //checks to see if the location has been guessed before
                if (grid[x, y] == 2 || grid[x, y] == 3)
                {
                    Console.WriteLine("Already entered that position");
                    goto Prompt;
                }

                //checks to see if the location has a ship and marks it on a grid
                if (shipLocation[x, y] == 1)
                {
                    Console.WriteLine("Hit!");
                    grid[x, y] = 3;
                    ships++;
                }

                //checks to see if the location contains a ships, marks the location if not
                if (shipLocation[x, y] == 0)
                {
                    Console.WriteLine("Miss! Try again");
                    grid[x, y] = 2;
                    misses++;
                }

                // ask the user for input
                Console.WriteLine("Please press 'enter' to continue");
                Console.ReadLine();
                Console.Clear();

                // do calculation & print result
                // check for win condition

                //when ships counter reaches 5, all of the ships have been destroyed, user wins
                if (ships == 5)
                {
                    Console.WriteLine("You Win");
                    Console.ReadLine();
                }

                //when misses counter reaches 5, all of the ships have been destroyed, user loses
                if (misses == 10)
                {
                    Console.WriteLine("You Lose");
                    Console.ReadLine();
                }
            }
        }
    }
}
