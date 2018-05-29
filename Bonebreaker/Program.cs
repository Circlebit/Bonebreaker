using System;

namespace Bonebreaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Framework.SetupConsole();

            //TODO: Game Starten
            //TODO: World Starten
            //TODO: Schleife zurück ins Menü
            //TODO: Levels laden
            //TODO: mehrere Levels ncheinander spielen

            Framework.PrintStartMenu();

            Player Player = new Player(15, 7);

            World World_1 = new World(90, 30, Player);
            Player.World = World_1;
            World_1.LoadMapFromFile(@"..\..\Maps\World_1.txt");

            Framework.PrintFrames(World_1.Map);
            World_1.SpawnPlayer();
            World_1.SpawnEnemies();

            World_1.PrintMap();
            Framework.PrintInfo(World_1);

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

                World_1.Enemies.RemoveAll(x => x.Alive == false);

            }
        }
    }
}
