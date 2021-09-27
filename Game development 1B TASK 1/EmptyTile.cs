using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Game_development_1B_TASK_1
{
   public class EmptyTile:Tile
    {
        public EmptyTile(int xparameter, int yparameter, Tiletype type, char symbol) : base(xparameter, yparameter, type,symbol)
        {

        }
    }
}
