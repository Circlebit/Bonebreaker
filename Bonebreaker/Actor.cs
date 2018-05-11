using System;

namespace Bonebreaker
{
    /// <summary>
    /// abstract class to derive Player, Enemy and Item from
    /// </summary>
    abstract class Actor
    {
        //TODO: Colors
        public int X { get; set; }
        public int Y { get; set; }
        public World World { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        protected Actor(int x, int y, World world)
        {
            X = x;
            Y = y;
            Color = ConsoleColor.Black;
            World = world;
        }


        #region Public Methods

        /// <summary>
        /// move this Actor into a direction
        /// </summary>
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


        #region Internal Methods

        protected internal void Print()
        {
            Framework.SetCursorToMap(X, Y);
            Console.ForegroundColor = Color;
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
        public Player(int x, int y, World world = null) : base (x, y, world)
        {
            X = x;
            Y = y;
            Symbol = '☻';
            Color = ConsoleColor.Yellow;
        }
    }

    class Enemy : Actor
    {
        public bool CanCrossObstacles { get; set; }  // "flying"
        public int Id { get; set; }
        
        public Enemy(int x, int y, int id, World world) : base(x, y, world)
        {
            X = x;
            Y = y;
            World = world;
            Id = id;
            Symbol = '¥';
            Color = ConsoleColor.White;
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

    class Item : Actor
    {
        public Item(int x, int y, World world) : base(x, y, world)
        {
            X = x;
            Y = y;
            World = world;
            Symbol = '☼';
        }
    }
}
