using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace SnakeGame
{
    class Program
    {
        public const int MAX_SNAKE_SIZE = 50;
        public const int START_POINT_X = 35;
        public const int START_POINT_Y = 20;

        static void Main(string[] args)
        {                     
            int[] xPosition = new int[50];
            xPosition[0] = START_POINT_X;
            int[] yPosition = new int[50];
            yPosition[0] = START_POINT_Y;

            Coord[] positions = new Coord[MAX_SNAKE_SIZE];
            positions[0] = new Coord() { posX = START_POINT_X, posY = START_POINT_Y };

            int appleXDim = 10;
            int appleYDim = 10;
            int applesEaten = 0;
 
            int gameSpeed = 800;

            bool isGameOn = true;
            bool isWallHit = false;
            bool isAppleEatem = false;
            bool isStayInMenu = true;
            Console.CursorVisible = false;

            // Отоброжение курсора
            Console.CursorVisible = false;
              
            RunGameEngine(START_POINT_X, START_POINT_Y, ref xPosition, ref yPosition, ref appleXDim, ref appleYDim, ref applesEaten, ref gameSpeed, ref isGameOn, ref isWallHit, ref isAppleEatem, ref isStayInMenu);

            Console.ReadKey();
        }

        private static void RunGameEngine(int startPointX, int startPointY, ref int[] xPosition, ref int[] yPosition, ref int appleXDim, ref int appleYDim, ref int applesEaten, ref int gameSpeed, ref bool isGameOn, ref bool isWallHit, ref bool isAppleEatem, ref bool isStayInMenu)
        {
            string[] menuItems = new string[] { "1) Directions", "2) Play", "3) Exit" };

            do
            {
                switch (UI.ShowMenu(menuItems))
                {
                    // Описание правил
                    case MenuItem.Directions:
                        Console.Clear();
                        UI.BuildWall();
                        UI.PlayGuide();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case MenuItem.Play:

                        Console.Clear();
                        // Построение границ
                        UI.BuildWall();
                        Snake sn = new Snake(startPointX, startPointY);
                        // Полученик змейки и отображение
                        UI.PaintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);

                        // Вывод фрукта на экран
                        RandomEat.setApplePositionOnScreen(out appleXDim, out appleYDim);
                        UI.PaintApple(appleXDim, appleYDim);

                        ConsoleKey command = ConsoleKey.Spacebar;
                        
                        do     // Получение змейки и движение          
                        {
                            Snake.Move(xPosition, yPosition, command);
                            // Отрисовка змейки. Увеличение змейки
                            UI.PaintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);

                            isWallHit = Field.DidSnakeHitWall(xPosition[0], yPosition[0]);

                            // Отслеживаем когда змейка попадает в граници
                            if (isWallHit)
                            {
                                isGameOn = false;
                                UI.GameOver(applesEaten);
                                applesEaten = 0;
                            }

                            // Отслеживаем когда яблоко было сьедено
                            isAppleEatem = Snake.determineIfAppleWasEaten(xPosition[0], yPosition[0], appleXDim, appleYDim);

                            // Помещение фруктов (рандом)
                            if (isAppleEatem)
                            {
                                RandomEat.setApplePositionOnScreen(out appleXDim, out appleYDim);
                                UI.PaintApple(appleXDim, appleYDim);
                                // Следим сколько было сьедено фруктов
                                // Увеличение змейки
                                applesEaten++;
                                // Быстрое движение змейки
                                gameSpeed -= 95;
                            }

                            //Преобразовываем движение змейки(проверка)
                            if (Console.KeyAvailable)
                            {
                                command = Console.ReadKey().Key;
                            }
                            // скорость змейки
                            System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));
                        } while (isGameOn);

                        UI.ShowMenu(menuItems);
                        break;

                    case MenuItem.Exit:
                        isStayInMenu = false;
                        Console.Clear();
                        break;
                }

            } while (isStayInMenu);
        }
    }
}
