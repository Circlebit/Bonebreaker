using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonebreaker
{
    class World
    {
        //TODO: store Spawnpoint for Player in World, not in Player
        public Map Map { get; }
        public Player Player { get; set; }

        public World(int mapHeight, int mapWidth, Player player)
        {
            Map = new Map(mapHeight, mapWidth);
            Player = player;
            Player.World = this;
        }

        public void SpawPlayer()
        {
            Player.Print();
        }
    }


    //TODO: auslagern in eigene Datei
    class Player
    {
        //TODO: wohin mit dem Player? Trennung von "Charakter" und Spielerfigur in der WOrld?
        public int X { get; set; }
        public int Y { get; set; }
        public World World { get; set; }
        public char Symbol { get; set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
            Symbol = '☻';
        }

        public void MoveTo(Direction direction, int steps = 1)
        {
            switch (direction)
            {
                case Direction.South:
                    if (Y < World.Map.Height - 1)
                    {
                        Clear();
                        Y++;
                        Print();
                    }
                    break;
                case Direction.North:
                    if (Y > 0)
                    {
                        Clear();
                        Y--;
                        Print();
                    }
                    break;
                case Direction.East:
                    if (X < World.Map.Width - 1)
                    {
                        Clear();
                        X++;
                        Print();
                    }
                    break;
                case Direction.West:
                    if (X > 0)
                    {
                        Clear();
                        X--;
                        Print();
                    }
                    break;
            }

        }

        #region Private Methods
        public void Print()
        {
            Framework.SetCursorToMap(X, Y);
            Console.Write(Symbol);
        }

        public void Clear()
        {
            Framework.SetCursorToMap(X, Y);
            Console.Write(' ');
            //TODO: print terrain instead blank space
        }
        #endregion




    }

    class Enemy
    {

        public int X { get; set; }
        public int Y { get; set; }
        public bool CanCrossObstacles {get; set;}  // "flying"

        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Moves the Enemy towards given coordinates
        /// </summary>
        public void MoveTowards(int x, int y)
        {
            //TODO: Implement Movement towards Coordinates
        }
    }
}
