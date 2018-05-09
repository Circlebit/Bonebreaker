using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonebreaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Framework.SetupConsole();
            
            Player Player = new Player(1, 1);

            World World_1 = new World(32, 100, Player);

            Framework.PrintMapFrame(World_1.Map);

            Player.Print();

            //TODO: Start a World

            //TODO: Player Movement

            //TODO: Mainloop (per World)
            bool runMainloop = true;
            while (runMainloop == true)
            {
                ConsoleKey inputKey = Console.ReadKey(true).Key;
            }
        }
    }
}
