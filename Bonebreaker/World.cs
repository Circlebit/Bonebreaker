using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bonebreaker
{
    class World
    {
        //TODO: store Spawnpoint for Player in World, not in Player
        public Map Map { get; }
        public Player Player { get; set; }
        public List<Enemy> Enemies { get; set; }

        public World(int mapWidth, int mapHeight, Player player)
        {
            Map = new Map(mapWidth, mapHeight);
            Enemies = new List<Enemy>();
            Player = player;
            Player.World = this;
        }

        public void PrintMap()
        {
            for (int y = 0; y < Map.Height; y++)
            {
                for (int x = 0; x < Map.Width; x++)
                {
                    Framework.SetCursorToMap(x, y);
                    Console.ForegroundColor = Map.Tile[x, y].Terrain.ForegroundColor;
                    Console.BackgroundColor = Map.Tile[x, y].Terrain.BackgroundColor;
                    Console.Write(Map.Tile[x, y].Terrain.Symbol);
                }
                DrawActors();
            }
        }

        public void DrawActors()
        {
            Player.Print();
            foreach (Enemy enemy in Enemies)
            {
                enemy.Print();
            }
            //TODO: Print Items
        }

        public void Win()
        {
            Console.SetCursorPosition(60,15);
            Console.Write("WIN WIN WIN");
        }

        public void SpawnPlayer()
        {
            Player.Spawn(4, 2);
        }

        /// <summary>
        /// Spawn all Enemies from Enemies List (use this to set up the Enemies loaded from Map file)
        /// </summary>
        public void SpawnEnemies()
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.World = this;
            }
        }

        /// <summary>
        /// Spawn new Enemie
        /// </summary>
        public void SpawnEnemy(Enemy enemy, int x, int y)
        {
            enemy.World = this;
            Enemies.Add(enemy);
            enemy.Spawn(x, y);
        }

        public void AddEnemyToList(Enemy enemy)
        {
            Enemies.Add(enemy);
        }

        //TODO: Load Map from File - Just draw Terrains with texteditor. Define Enemy Type and Position
        public void LoadMapFromFile(string fileName)
        {
            var lines = File.ReadLines(fileName);
            int y = 0;
            foreach (var line in lines)
            {
                // Parse the Map part of the map file
                if (y < Map.Height)
                {
                    for (int x = 0; x < Map.Width; x++)
                    {
                        Map.Tile[x, y].Terrain = MapFileCharToTerrain(line[x]);
                        if (Char.IsDigit(line[x]))
                        {
                            Enemies.Add(new Enemy(x, y, int.Parse(line[x].ToString()), this));
                        }
                    }
                }
                y++;
            }
        }


        private TerrainObject MapFileCharToTerrain(char fileChar)
        {
            switch (fileChar)
            {
                case ' ': return Map.TerrainLibrary.Empty;

                case '▓': return Map.TerrainLibrary.Wall;

                case '▲': return Map.TerrainLibrary.Goal;

                case '▒': return Map.TerrainLibrary.Water;

                default: return Map.TerrainLibrary.Empty;
            }
        }
    }
}
