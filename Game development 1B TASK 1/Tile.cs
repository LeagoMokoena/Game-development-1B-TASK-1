using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Game_development_1B_TASK_1
{
    public abstract class Tile
    {
        //fields
        private char symbol;

        public char Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }


        protected private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        protected private int y;

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
            Weapon,
            empty,
            obstacle
        }

        public Tiletype tiletype;
        //constructure
        public Tile(int _xPosition, int _yPosition, Tiletype type,char _symbol)
        {
            x = _xPosition;
            y = _yPosition;
            tiletype = type;
            symbol = _symbol;
        }
    }
}
