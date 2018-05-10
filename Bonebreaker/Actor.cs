using System;

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
                    if (Y < World.Map.Height - 1 && World.Map.Tile[X, Y + 1].Terrain.UnitsCanEnter)
                    {
                        Clear();
                        Y++;
                        Print();
                    }
                    break;
                case Direction.North:
                    if (Y > 0 && World.Map.Tile[X, Y - 1].Terrain.UnitsCanEnter)
                    {
                        Clear(); //TODO: Flackern bei Bewegung - Erst Print dann Clear?
                        Y--;
                        Print();

                    }
                    break;
                case Direction.East:
                    if (X < World.Map.Width - 1 && World.Map.Tile[X + 1, Y].Terrain.UnitsCanEnter)
                    {
                        Clear();
                        X++;
                        Print();
                    }
                    break;
                case Direction.West:
                    if (X > 0 && World.Map.Tile[X - 1, Y].Terrain.UnitsCanEnter)
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
        public void MoveTowards(int targetX, int targetY)
        {
            //TODO: implement more interesting algorithm, maybe some variations
            if ( X > targetX )
                StepIntoDirection(Direction.West);
            else if ( X < targetX)
                StepIntoDirection(Direction.East);
            else if ( Y > targetY)
                StepIntoDirection(Direction.North);
            else if (Y < targetY)
                StepIntoDirection(Direction.South);
        }
    }
}
