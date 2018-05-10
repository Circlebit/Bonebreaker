using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonebreaker
{
    #region Public Enums

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
        public const int WindowWidth = 120;
        public const int MapTopMargin = 2;
        public const int MapLeftMargin = 2;

        public static void SetupConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Bonebreaker";
            Console.CursorVisible = false;
            Console.SetWindowSize(WindowWidth, WindowHeight);
            Console.BufferHeight = WindowHeight;
            Console.BufferWidth = WindowWidth;
            Console.Clear();
        }

        public static void PrintMapFrame(Map map)
        {
            Console.SetCursorPosition(MapLeftMargin, MapTopMargin - 1);
            Console.Write(" Map ");
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
            Console.Write("╚═");
            for (int x = 0; x < map.Width; x++)
            {
                Console.Write("═");
            }
            Console.Write("═╝");
        }

        /// <summary>
        /// Sets the cursor to a coordinate relative to the topleft of the map
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public static void SetCursorToMap(int X, int Y)
        {
            Console.SetCursorPosition(X + MapLeftMargin + 2, Y + MapTopMargin + 1);
        }
    }
}
