using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public struct Field
    { 
        // TODO: перенести координаты змеи + текущую позицию + позицию бонуса

        public static bool DidSnakeHitWall(int xPosition, int yPosition)
        {
            return (xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 40);
        }
    }
}
