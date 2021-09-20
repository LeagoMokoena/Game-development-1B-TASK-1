using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    abstract class Tile
    {
        //fields
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
        public Tile(int _xPosition, int _yPosition, Tiletype symbol)
        {
            x = _xPosition;
            y = _yPosition;
            tiletype = symbol;
        }
    }
}
