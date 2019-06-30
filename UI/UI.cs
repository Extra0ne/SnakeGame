using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace SnakeGame
{
    public class UI
    {   
        public static MenuItem ShowMenu(string[] menuItems)
        {
           // string menu1 = "1) Directions\n 2) Play\n 3) Exit \n\n\n";

            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine(menuItems[i]);    
            }            

            //string chosenAction = "";  // "" ---> string.Empty
            string chosenAction = Console.ReadLine();

            MenuItem userAction = MenuItem.Default;

            switch (chosenAction)
            {
                case "1":
                    userAction = MenuItem.Directions;
                    break;
                case "2":
                    userAction = MenuItem.Play;
                    break;
                case "3":
                    userAction = MenuItem.Exit;
                    break;
            }

            return userAction;
        }
        public static void PlayGuide()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("1) Измените размер окна консолию, чтобы Вы могли");
            Console.SetCursorPosition(5, 6);
            Console.WriteLine("   видеть все 4 стороны игрового поля.");
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("2) используйте клавиши со стрелками для перемещения ");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("   змеи вокруг поля.");
            Console.SetCursorPosition(5, 9);
            Console.WriteLine("3) Змея умерает если она врезается в стену.");
            Console.SetCursorPosition(5, 10);
            Console.WriteLine("4) Вы получаете очки употребляя яблоки");
            Console.SetCursorPosition(5, 11);
            Console.WriteLine("   но Ваша змея также будет быстрее.");
            Console.SetCursorPosition(5, 12);
            Console.WriteLine("   Нажмите enter чтобы вернуться в главное меню.");
        }
       
        public static void BuildWall()// Отрисовка текстур
        {
            for (int i = 0; i < 40; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, i);
                Console.Write((char)GameObject.walls);
                Console.SetCursorPosition(70, i);
                Console.Write((char)GameObject.walls);
            }

            for (int i = 0; i < 70; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(i, 0);
                Console.Write((char)GameObject.walls);
                Console.SetCursorPosition(i, 40);
                Console.Write((char)GameObject.walls);
            }
        }
        public static void PaintSnake(int applesEaten, int[] xPositionIn, int[] yPositionIn, out int[] xPositionOut, out int[] yPositionOut)
        {
            // Отрисовка головы
            Console.SetCursorPosition(xPositionIn[0], yPositionIn[0]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine((char)GameObject.snakeHead);

            // Покраска тела
            for (int i = 1; i < applesEaten + 1; i++)
            {
                Console.SetCursorPosition(xPositionIn[i], yPositionIn[i]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine((char)GameObject.snakeTail);
            }

            // Удаление последней части змейки
            Console.SetCursorPosition(xPositionIn[applesEaten + 1], yPositionIn[applesEaten + 1]);
            Console.WriteLine(" ");

            //Место где записывается каждая чать тела
            for (int i = applesEaten + 1; i > 0; i--)
            {
                xPositionIn[i] = xPositionIn[i - 1];
                yPositionIn[i] = yPositionIn[i - 1];
            }

            // Возвращаем новый массив
            xPositionOut = xPositionIn;
            yPositionOut = yPositionIn;
        } // Раскраска змеи

        public static void PaintApple(int appleXDim, int appleYDim)
        {
            Console.SetCursorPosition(appleXDim, appleYDim);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine((char)GameObject.apple);
        }
     
        public static void GameOver(int applesEaten)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(20, 20);
            Console.WriteLine("Game Over. ");
            // Отоброжение результатов
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(15, 21);
            Console.Write("Ваш счёт " + applesEaten * 100 + "!");
            Console.SetCursorPosition(15, 22);
            Console.Write("Нажмите Enter для продолжения.");
            Console.ReadLine();
            Console.Clear();
           // UI.ShowMenu();
        }
    }
}
