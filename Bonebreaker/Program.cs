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
            
            Player Player = new Player(15, 7);

            World World_1 = new World(30, 15, Player);

            Framework.PrintMapFrame(World_1.Map);
            World_1.SpawPlayer();

            //TODO: Start a World

            //TODO: Player Movement

            //TODO: Mainloop (per World)
            bool runMainloop = true;
            while (runMainloop == true)
            {
                ConsoleKey inputKey = Console.ReadKey(true).Key;
                switch (inputKey)
                {
                    case ConsoleKey.DownArrow:
                        Player.MoveTo(Direction.South);
                        break;
                    case ConsoleKey.UpArrow:
                        Player.MoveTo(Direction.North);
                        break;
                    case ConsoleKey.LeftArrow:
                        Player.MoveTo(Direction.West);
                        break;
                    case ConsoleKey.RightArrow:
                        Player.MoveTo(Direction.East);
                        break;
                    case ConsoleKey.Escape:
                        runMainloop = false;
                        break;
                }
                //Player.Print();
            }
        }
    }
}
