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
        }
    }


    //TODO: auslagern in eigene Datei
    class Player
    {
        //TODO: wohin mit dem Player? Trennung von "Charakter" und Spielerfigur in der WOrld?
        public int X { get; set; }
        public int Y { get; set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }
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
