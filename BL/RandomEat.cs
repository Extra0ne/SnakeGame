using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class RandomEat
    {
        public static void setApplePositionOnScreen(out int appleXDim, out int appleYDim)
        {
            Random random = new Random();
            appleXDim = random.Next(1 + 2, 71 - 2);
            appleYDim = random.Next(1 + 2, 41 - 2);
    
        }

    }
}
