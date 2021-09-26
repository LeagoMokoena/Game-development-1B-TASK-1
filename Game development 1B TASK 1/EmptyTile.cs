using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class EmptyTile:Tile
    {
        public EmptyTile(int xparameter, int yparameter, Tiletype type, int Xparameter, int Yparameter, char symbol) : base(xparameter, yparameter, type,symbol)
        {

        }
    }
}
