using System;
using System.Text;

namespace Bonebreaker
{
    #region Public Enums
    //TODO: Woanders hin, evt. World oder Map?
    public enum Direction
    {
        North,
        South,
        East,
        West
    };

    #endregion

    static class Framework
    {
        public const int WindowHeight = 39;
        public const int WindowWidth = 122;
        public const int MapTopMargin = 2;
        public const int MapLeftMargin = 2;
        public const ConsoleColor DefaultForeColor = ConsoleColor.Black;
        public const ConsoleColor DefaultBackColor = ConsoleColor.DarkGray;


        public static void SetupConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Bonebreaker";
            Console.CursorVisible = false;
            Console.SetWindowSize(WindowWidth, WindowHeight);
            Console.BufferHeight = WindowHeight;
            Console.BufferWidth = WindowWidth;
            Console.BackgroundColor = DefaultBackColor;
            Console.ForegroundColor = DefaultForeColor;
            Console.Clear();
        }

        public static void PrintFrames(Map map)
        {
            PrintMapFrame(map);
            PrintRightFrame(map);
        }

        public static void PrintMapFrame(Map map)
        {
            Console.Clear();
            Console.SetCursorPosition(MapLeftMargin, MapTopMargin - 1);
            Console.Write(" Karte ");
            Console.SetCursorPosition(MapLeftMargin, MapTopMargin);
            Console.Write("╔═");
            for (int x = 0; x < map.Width; x++)
            {
                Console.Write("═");
            }
            Console.Write("═╗");

            //Console.SetCursorPosition(MapLeftMargin+1, MapTopMargin);
            //Console.Write("╡Map╞");

            for (int y = MapTopMargin + 1; y < map.Height + MapTopMargin + 1; y++)
            {
                Console.SetCursorPosition(MapLeftMargin, y);
                Console.Write("║ ");
                Console.SetCursorPosition(map.Width + MapLeftMargin + 2, y);
                Console.Write(" ║");
            }

            Console.SetCursorPosition(MapLeftMargin, map.Height + MapTopMargin + 1);
            Console.Write("╠═");
            for (int x = 0; x < map.Width; x++)
            {
                Console.Write("═");
            }
            Console.Write("═╣");

            // Print Lower Map Frame
            for (int y = map.Height + MapTopMargin + 2; y < map.Height + MapTopMargin + 5; y++)
            {
                Console.SetCursorPosition(MapLeftMargin, y);
                Console.Write("║ ");
                Console.SetCursorPosition(map.Width + MapLeftMargin + 2, y);
                Console.Write(" ║");
            }

            Console.SetCursorPosition(MapLeftMargin, map.Height + MapTopMargin + 5);
            Console.Write("╚═");
            for (int x = 0; x < map.Width; x++)
            {
                Console.Write("═");
            }
            Console.Write("═╝");

            // Print Legend
            //TODO: Legend for Items
            Console.SetCursorPosition(MapLeftMargin + 2, map.Height + MapTopMargin + 2);
            foreach (TerrainObject terrain in map.TerrainLibrary.TerrainObjectList)
            {
                terrain.Print();
                Console.Write(" " + terrain.Name + "   ");
            }

        }

        private static int GetRightFrameTopLeftX(Map map)
        {
            return map.Width + 3 * MapLeftMargin + 1;
        }

        private static int GetRightFrameWidth(Map map)
        {
            return WindowWidth - GetRightFrameTopLeftX(map) - 3 * MapLeftMargin;
        }

        public static void PrintRightFrame(Map map)
        {
            int frameTopLeftX = GetRightFrameTopLeftX(map);
            int frameWidth = GetRightFrameWidth(map);

            Console.SetCursorPosition(frameTopLeftX, MapTopMargin - 1);
            Console.Write(" Info ");
            Console.SetCursorPosition(frameTopLeftX, MapTopMargin);
            Console.Write("╔═");
            for (int x = 0; x < frameWidth; x++)
            {
                Console.Write("═");
            }
            Console.Write("═╗");

            //Console.SetCursorPosition(frameTopLeftX + 1, MapTopMargin);
            //Console.Write("╡Charakter╞");

            for (int y = MapTopMargin + 1; y < WindowHeight - MapTopMargin + 1; y++)
            {
                Console.SetCursorPosition(frameTopLeftX, y);
                Console.Write("║");
                Console.SetCursorPosition(frameWidth + frameTopLeftX + 3, y);
                Console.Write("║");
            }

            Console.SetCursorPosition(frameTopLeftX, WindowHeight - MapTopMargin);
            Console.Write("╚═");
            for (int x = 0; x < frameWidth; x++)
            {
                Console.Write("═");
            }
            Console.Write("═╝");
        }


        public static void PrintInfo(World world)
        {
            int frameTopLeftX = GetRightFrameTopLeftX(world.Map);
            int frameWidth = GetRightFrameWidth(world.Map);

            Console.SetCursorPosition(frameTopLeftX + 1, MapTopMargin + 1);
            Console.BackgroundColor = DefaultBackColor;
            Console.ForegroundColor = DefaultForeColor;
            Console.Write(" Health:");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            StringBuilder healthbar = new StringBuilder();
            int h = world.Player.Health;
            for (int i = 0; i < 6; i++)
            {
                if (h > 0)
                {
                    healthbar.Append(" ♥");
                }
                else
                {
                    healthbar.Append("  ");
                }
                h--;
            }
            Console.Write(healthbar);
        }

        public static void PrintStartMenu()
        {
            Console.Clear();
            Console.WriteLine("\n Willkommen bei Bonebreaker! \n");
            Console.WriteLine("\n Enter zum Starten!");
            Console.ReadKey();
        }

        /// <summary>
        /// Sets the cursor to a coordinate relative to the topleft of the map
        /// </summary>
        public static void SetCursorToMap(int X, int Y)
        {
            Console.SetCursorPosition(X + MapLeftMargin + 2, Y + MapTopMargin + 1);
        }
    }
}
