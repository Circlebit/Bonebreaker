﻿using System;

namespace Bonebreaker
{
    abstract class Actor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public World World { get; set; }
        public char Symbol { get; set; }

        protected Actor(int x, int y)
        {
            X = x;
            Y = y;
        }


        #region Public Methods

        public void StepIntoDirection(Direction direction, int steps = 1)
        {
            switch (direction)
            {
                case Direction.South:
                    if (Y < World.Map.Height - 1)
                    {
                        Clear(); //TODO: Flackern bei Bewegung - Erst Print dann Clear?
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

        public void Spawn(int x, int y)
        {
            X = x;
            Y = y;
            Print();
        }

        #endregion


        #region Private Methods

        protected internal void Print()
        {
            Framework.SetCursorToMap(X, Y);
            Console.Write(Symbol);
        }

        protected internal void Clear()
        {
            Framework.SetCursorToMap(X, Y);
            Console.Write(' ');
            //TODO: print terrain instead blank space
        }

        #endregion

    }

    class Player : Actor
    {
        public Player(int x, int y) : base (x, y)
        {
            X = x;
            Y = y;
            Symbol = '☻';
        }
    }

    class Enemy : Actor
    {
        public bool CanCrossObstacles { get; set; }  // "flying"
        
        public Enemy(int x = 0, int y = 0) : base(x, y)
        {
            X = x;
            Y = y;
            Symbol = '¥';
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