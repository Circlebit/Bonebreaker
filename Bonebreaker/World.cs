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

        //TODO: World.Run() - start a main loop and runs a game of this World
    }

}
