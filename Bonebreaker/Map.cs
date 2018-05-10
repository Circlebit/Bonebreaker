﻿using System;
using System.Collections.Generic;
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



        public void DrawMap()
        {
            //TODO irgendwo Daten herholen statt alles mit Empty
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Tile[x, y].Terrain = TerrainLibrary.Empty;
                }
            }

            LoadMapFromFile(@"Maps\World_1.txt");
        }

        //TODO: Load Map from File - Just draw Terrains with texteditor. Define Enemy Type and Position
        public void LoadMapFromFile(string fileName)
        {
            var lines = File.ReadLines(fileName);
            int y = 0;
            foreach (var line in lines)
            {
                for (int x = 0; x < Width; x++)
                {
                    Tile[x, y].Terrain = ParseMapFileChar(line[x]);
                }

                y++;
            }
        }

        private TerrainObject ParseMapFileChar(char fileChar)
        {
            switch (fileChar)
            {
                case ' ': return TerrainLibrary.Empty;

                case '▓': return TerrainLibrary.Wall;

                default: return TerrainLibrary.Empty;
            }
        }
    }

    class Tile
    {
        public int X { get; }
        public int Y { get; }
        public TerrainObject Terrain { get; set; }
        
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

    class TerrainLibrary
    {
        //TODO: mehr Geländearten (Wände, Gewässer und mehr)

        public TerrainObject Empty { get; }
        public TerrainObject Wall { get; }


        public TerrainLibrary()
        {
            Empty = new TerrainObject(' ', true);

            Wall = new TerrainObject('▓', false);
        }
    }
}