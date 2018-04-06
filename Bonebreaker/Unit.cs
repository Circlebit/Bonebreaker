using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonebreaker
{
    class Unit
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Active { get; set; }

        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        //public bool Visible { get; set; }

        public bool CanFly { get; set; }
        //public bool CanSwim { get; set; }
        public int MovementPoints { get; set; }

        public string Name { get; set; }

        public Unit(int x, int y, string name, char symbol, ConsoleColor color = ConsoleColor.White)
        {
            X = x;
            Y = y;

            Active = true;

            Symbol = symbol;
            Color = color;

            CanFly = false;
            MovementPoints = 1;

            Name = name;
        }


        /// <summary>
        /// Moves the Enemy towards given coordinates
        /// </summary>
        public void MoveTowards(int x, int y)
        {
            //TODO: Implement Movement towards Coordinates
            //TODO: Implement different kinds of pathfinding (and path not-finding!)
        }

    }


    class Player : Unit
    {
        public Player(int x, int y) : base(x, y, "Player", '☻', ConsoleColor.Yellow)
        {
            
        }

    }


    class Enemy : Unit
    {
        public bool FollowsPlayer { get; set; }


        public Enemy(int x, int y, string name, char symbol, ConsoleColor color = ConsoleColor.White) : base(x, y, name, symbol, color)
        {
            FollowsPlayer = true;
        }

    }

    class Item : Unit
    {
        public Item(int x, int y, string name, char symbol, ConsoleColor color = ConsoleColor.White) : base(x, y, name, symbol, color)
        {
            MovementPoints = 0;
        }
    }
}
