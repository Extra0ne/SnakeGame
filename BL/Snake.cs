using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
  
    public struct Snake
    {
        public Snake(int posx, int posy)
        {
            Coordinates = new Coord();
            Coordinates.posX = posx;
            Coordinates.posY = posy;
        }
        public Coord Coordinates;
        public static void Move(int[] xPosition, int[] yPosition, ConsoleKey command)
        {   
                // считываем нажатую клавишу
                if (Console.KeyAvailable)
                {
                    command = Console.ReadKey().Key;
                }

                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                       Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        //Console.Write(" ");
                        xPosition[0]--;
                    Console.ReadKey();
                    break;

                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        //Console.Write(" ");
                        yPosition[0]--;
                    Console.ReadKey();
                    break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        //Console.Write(" ");
                        xPosition[0]++;
                    Console.ReadKey();
                    break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        //Console.Write(" ");
                        yPosition[0]++;
                    Console.ReadKey();
                    break;
                }
        }

            public static bool determineIfAppleWasEaten(int xPosition, int yPosition, int appleXDim, int appleYDim)
        {
            return (xPosition == appleXDim) && (yPosition == appleYDim);
        }
    }  
}
