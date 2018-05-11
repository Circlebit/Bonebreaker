﻿using System;
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

            //TODO: Game Starten
            //TODO: World Starten

            Player Player = new Player(15, 7);

            World World_1 = new World(90, 30, Player);
            Player.World = World_1;
            World_1.LoadMapFromFile(@"..\..\Maps\World_1.txt");

            Framework.PrintMapFrame(World_1.Map);
            World_1.SpawnPlayer();
            World_1.SpawnEnemies();

            World_1.PrintMap();

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

                foreach (Enemy enemy in World_1.Enemies)
                {
                    enemy.MoveTowards(Player.X, Player.Y);
                }
            }
        }
    }
}
