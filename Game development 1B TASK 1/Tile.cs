using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    abstract class Tile
    {
        //fields
        private char symbol;

        public char Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }


        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public enum Tiletype
        {
            Hero,
            Enemy,
            Gold,
            Weapon
        }

        public Tiletype tiletype;
        //constructure
        public Tile(int _xPosition, int _yPosition, Tiletype type)
        {
            x = _xPosition;
            y = _yPosition;
            tiletype = type;
        }
    }
}
