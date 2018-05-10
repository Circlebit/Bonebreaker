using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bonebreaker
{
    class Map
    {
        public Tile[,] Tile { get; }

        public int Width { get; }
        public int Height { get; }


        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            
            Tile = new Tile[Width,Height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Tile[x,y] = new Tile(x,y);
                }
            }
        }

        //TODO: Load Map from File - Just draw Terrains with texteditor. Define Enemy Type and Position
    }

    class Tile
    {
        public int X { get; }
        public int Y { get; }

        //TODO: enum für Geländearten

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class TerrainObject
    {
        public char Symbol { get; set; }
        public bool UnitsCanEnter { get; set; }

        public TerrainObject(char symbol, bool unitsCanEnter)
        {
            Symbol = symbol;
            UnitsCanEnter = unitsCanEnter;
            //TODO: mehr Eigenschaften von Geländearten
        }
    }

    class Terrain
    {
        //TODO: mehr Geländearten (Wände, Gewässer und mehr)
        public TerrainObject Empty = new TerrainObject(' ', true);
    }
}
