using System;
using System.Media;

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
                //TODO: Cleaner Code! (maybe targetTile (aber was ist mit index, gibts ne clamp?) or whatever)
                //TODO: React on Goal (does this even belong here?)
                case Direction.South:
                    if (Y < World.Map.Height - 1 &&
                        World.Map.Tile[X, Y + 1].Terrain.UnitsCanEnter) // && 
                        //!World.Map.Tile[X, Y + 1].IsOccupied)
                    {
                        Clear();
                        Y++;
                        //if (World.Map.Tile[X, Y + 1].Terrain == World.Map.TerrainLibrary.Goal)
                        //{
                        //    World.Win();
                        //}
                        Print();
                    }
                    break;

                case Direction.North:
                    if (Y > 0 &&
                        World.Map.Tile[X, Y - 1].Terrain.UnitsCanEnter) // && 
                        // !World.Map.Tile[X, Y - 1].IsOccupied)
                    {
                        Clear();
                        Y--;
                        Print();
                    }
                    break;

                case Direction.East:
                    if (X < World.Map.Width - 1 && 
                        World.Map.Tile[X + 1, Y].Terrain.UnitsCanEnter) // && 
                        //!World.Map.Tile[X + 1, Y].IsOccupied)
                    {
                        Clear();
                        X++;
                        Print();
                    }
                    break;

                case Direction.West:
                    if (X > 0 && 
                        World.Map.Tile[X - 1, Y].Terrain.UnitsCanEnter) // && 
                        //!World.Map.Tile[X - 1, Y].IsOccupied)
                    {
                        Clear();
                        X--;
                        Print();
                    }
                    break;
            }

            if (World.Map.Tile[X, Y].Terrain == World.Map.TerrainLibrary.Goal)
            {
                World.Win();
            }

        }

        /// <summary>
        /// True if the Actor is on the same Tile as the Player
        /// </summary>
        public bool CollisionWithPlayer()
        {
            return X == World.Player.X && Y == World.Player.Y;
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
            World.Map.Tile[X, Y].Terrain.Print();
            World.Map.Tile[X, Y].IsOccupied = false;
        }

        #endregion

    }

    class Player : Actor
    {
        private int _health;
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                if (_health <= 0)
                    World.Loose();
            }
        } //TODO: end game when 0

        public SoundPlayer Wilhelmscream { get; set; }

        public Player(int x, int y, World world = null) : base (x, y, world)
        {
            X = x;
            Y = y;
            Symbol = '☻';
            Color = ConsoleColor.Yellow;
            Health = 3;
            Wilhelmscream = new SoundPlayer();
            Wilhelmscream.SoundLocation = @"..\..\Sounds\wilhelm.wav";
        }

    }

    class Enemy : Actor
    {
        public bool CanCrossObstacles { get; set; }  // "flying"
        public int Id { get; set; }
        public bool Alive { get; set; }
        
        public Enemy(int x, int y, int id, World world) : base(x, y, world)
        {
            X = x;
            Y = y;
            World = world;
            Id = id;
            Symbol = '¥';
            Color = ConsoleColor.White;
            Alive = true;
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
                Alive = false;
                //TODO: delete enemy
                //TODO: play sound
                Framework.PrintInfo(World);
                World.Player.Wilhelmscream.Play();
            }
        }

        //public void Kill()
        //{
        //    //foreach (Enemy enemy in World.Enemies)
        //    //{
        //    //    if (this.Id == enemy.Id)
        //    //    {
        //    //        World.Enemies.Remove(enemy);
        //    //    }
        //    //}
        //    World.Enemies.RemoveAll(x => x.Id == this.Id);
        //    Clear();
        //}
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
