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
            Tile targetTile;
            switch (direction)
            {
                case Direction.South:
                    if (Y < World.Map.Height - 1 &&
                        World.Map.Tile[X, Y + 1].Terrain.UnitsCanEnter && 
                        !World.Map.Tile[X, Y + 1].IsOccupied)
                    {
                        Clear();
                        Y++;
                        Print();
                    }
                    break;

                case Direction.North:
                    if (Y > 0 &&
                        World.Map.Tile[X, Y - 1].Terrain.UnitsCanEnter && 
                        !World.Map.Tile[X, Y - 1].IsOccupied)
                    {
                        Clear();
                        Y--;
                        Print();
                    }
                    break;

                case Direction.East:
                    if (X < World.Map.Width - 1 && 
                        World.Map.Tile[X + 1, Y].Terrain.UnitsCanEnter && 
                        !World.Map.Tile[X + 1, Y].IsOccupied)
                    {
                        Clear();
                        X++;
                        Print();
                    }
                    break;

                case Direction.West:
                    if (X > 0 && 
                        World.Map.Tile[X - 1, Y].Terrain.UnitsCanEnter && 
                        !World.Map.Tile[X - 1, Y].IsOccupied)
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
            Console.BackgroundColor = World.Map.Tile[X, Y].Terrain.BackgroundColor;
            Console.Write(Symbol);
            World.Map.Tile[X, Y].IsOccupied = true;
        }

        protected internal void Clear()
        {
            Framework.SetCursorToMap(X, Y);
            Console.ForegroundColor = World.Map.Tile[X, Y].Terrain.ForegroundColor;
            Console.BackgroundColor = World.Map.Tile[X, Y].Terrain.BackgroundColor;
            Console.Write(' ');
            World.Map.Tile[X, Y].IsOccupied = false;
        }

        #endregion

    }

    class Player : Actor
    {
        public int Health { get; set; } //TODO: end game when 0

        public Player(int x, int y, World world = null) : base (x, y, world)
        {
            X = x;
            Y = y;
            Symbol = '☻';
            Color = ConsoleColor.Yellow;
            Health = 3;
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
            if (X > targetX)
            {
                StepIntoDirection(Direction.West);
            }
            else if (X < targetX)
            {
                StepIntoDirection(Direction.East);
            }
            else if (Y > targetY)
            {
                StepIntoDirection(Direction.North);
            }
            else if (Y < targetY)
            {
                StepIntoDirection(Direction.South);
            }

            if (CollisionWithPlayer())
            {
                World.Player.Health--;
                //TODO: delete enemy
                //TODO: play sound
                Framework.PrintInfo(World);
            }
        }

        public bool CollisionWithPlayer() //TODO: Use this before the IsOccupied so there is an actual collision between player and enemy
        {
            return X == World.Player.X && Y == World.Player.Y;
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
