using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonebreaker
{
    static class Framework
    {
        public static void SetupConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Bonebreaker";
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 50);
            Console.BufferWidth = 120;
            Console.BufferHeight = 50;
            Console.Clear();
        }

        public static void PrintMapFrame(Map map)
        {
            const int TopMargin = 2;
            const int LeftMargin = 2;
            Console.SetCursorPosition(LeftMargin, TopMargin - 1);
            Console.Write(" Map ");
            Console.SetCursorPosition(LeftMargin, TopMargin);
            Console.Write("╔");
            for (int x = 0; x < map.Width; x++)
            {
                Console.Write("═");
            }
            Console.Write("╗");

            //Console.SetCursorPosition(LeftMargin+1, TopMargin);
            //Console.Write("╡Map╞");

            for (int y = TopMargin + 1; y < map.Height + TopMargin; y++)
            {
                Console.SetCursorPosition(LeftMargin, y);
                Console.Write("║");
                Console.SetCursorPosition(map.Width + LeftMargin + 1, y);
                Console.Write("║");
            }

            Console.SetCursorPosition(LeftMargin, map.Height + TopMargin);
            Console.Write("╚");
            for (int x = 0; x < map.Width; x++)
            {
                Console.Write("═");
            }
            Console.Write("╝");
        }


        public static Map LoadMapFromFile(string pathToFile)
        {
            //TODO: Load Map from File - Just draw Terrains with texteditor. Define Enemy Type and Position
            return new Map(12, 34);
        }
    }
}
