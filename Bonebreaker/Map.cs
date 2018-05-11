using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bonebreaker
{
    class Map
    {
        public Tile[,] Tile { get; set; }

        public int Width { get; }
        public int Height { get; }

        public TerrainLibrary TerrainLibrary { get; }
        public TerrainObject Terrain { get; set; }


        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            TerrainLibrary = new TerrainLibrary();
            
            Tile = new Tile[Width,Height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Tile[x,y] = new Tile(x,y);
                }
            }
        }
    }

    class Tile
    {
        public int X { get; }
        public int Y { get; }
        public TerrainObject Terrain { get; set; }
        public bool IsOccupied { get; set; }
        
        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    /// <summary>
    /// Represents a kind of object including its look and gameplay options
    /// </summary>
    class TerrainObject
    {
        public char Symbol { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public string Name { get; set; }
        public bool UnitsCanEnter { get; set; }

        public TerrainObject(char symbol, string name,
                             ConsoleColor foregroundColor, ConsoleColor backgroundColor,
                             bool unitsCanEnter)
        {
            Symbol = symbol;
            UnitsCanEnter = unitsCanEnter;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            Name = name;
            //TODO: mehr Eigenschaften von Geländearten
            //TODO: bool Occupied if Actor there
        }
    }

    /// <summary>
    /// Contains different kinds of Terrain (and a list of all of them) as properties
    /// </summary>
    class TerrainLibrary
    {
        //TODO: mehr Geländearten (Wände, Gewässer und mehr)

        public TerrainObject Empty { get; }
        public TerrainObject Wall { get; }

        public List<TerrainObject> TerrainObjectList { get; }

        public TerrainLibrary()
        {
            TerrainObjectList = new List<TerrainObject>();

            Empty = new TerrainObject(
                symbol: ' ',
                name: "Rasen",
                foregroundColor: ConsoleColor.Black,
                backgroundColor: ConsoleColor.DarkGreen,
                unitsCanEnter: true);
            TerrainObjectList.Add(Empty);

            Wall = new TerrainObject(
                symbol: '▓',
                name: "Mauer",
                foregroundColor: ConsoleColor.Black,
                backgroundColor: ConsoleColor.DarkGreen,
                unitsCanEnter: false);
            TerrainObjectList.Add(Wall);
        }
    }
}