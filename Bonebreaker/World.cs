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
        public List<Enemy> Enemies { get; set; }

        public World(int mapWidth, int mapHeight, Player player)
        {
            Map = new Map(mapWidth, mapHeight);
            Enemies = new List<Enemy>();
            Player = player;
            Player.World = this;
        }

        public void SpawnPlayer()
        {
            Player.Spawn(4, 2);
        }

        public void SpawnEnemy(Enemy enemy, int x, int y)
        {
            enemy.World = this;
            Enemies.Add(enemy);
            enemy.Spawn(x, y);
        }
    }
}
