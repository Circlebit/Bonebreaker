﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bonebreaker2
{
    class Map
    {
        public Tile[,] Tile { get; }

        public int Height { get; }
        public int Width { get; }

        public Map(int height, int width)
        {
            Height = height;
            Width = width;

            Tile = new Tile[Height,Width];
            for (int y = 0; y < Width; y++)
            {
                for (int x = 0; x < Height; x++)
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
