using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public enum GameObject : ushort
    {
        def = ' ',
        snakeHead = '☺',
        snakeTail = '*',
        apple = '$',
        walls = '#'
    }
}
