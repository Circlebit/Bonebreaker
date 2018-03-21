using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonebreaker
{
    class Unit
    {
        int X { get; set; }
        int Y { get; set; }

        string Name { get; set; }

        public Unit(int x, int y, string name)
        {
            X = x;
            Y = y;

            Name = name;
        }
    }

    class Player : Unit
    {
        
    }
}
