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

            World World_1 = new World(90, 30, Player);

            Framework.PrintMapFrame(World_1.Map);
            World_1.SpawnPlayer();

            Enemy e1 = new Enemy();
            World_1.SpawnEnemy(e1);


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
                        Player.StepIntoDirection(Direction.South);
                        break;
                    case ConsoleKey.UpArrow:
                        Player.StepIntoDirection(Direction.North);
                        break;
                    case ConsoleKey.LeftArrow:
                        Player.StepIntoDirection(Direction.West);
                        break;
                    case ConsoleKey.RightArrow:
                        Player.StepIntoDirection(Direction.East);
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
