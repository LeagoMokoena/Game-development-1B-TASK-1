using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    public abstract class Item : Tile
    {
        protected Item(int _xPosition, int _yPosition, Tiletype type, char _symbol) : base(_xPosition, _yPosition, type, _symbol)
        {
        }

        public abstract override string ToString();
    }
}
