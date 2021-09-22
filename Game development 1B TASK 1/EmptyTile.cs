using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class EmptyTile:Tile
    {
        public EmptyTile(int xparameter,int yparameter,Tiletype symbol) : base(xparameter, yparameter, symbol)
        {
            for (int Xvalues = 0; Xvalues <= xparameter; Xvalues++)
            {
                for (int Yvalues = 0; Yvalues <= yparameter; Yvalues++)
                {
                    if (((Yvalues > 0 || Yvalues < yparameter) && Xvalues > 0 && Xvalues < xparameter))
                    {

                    }
                }
            }
    }
}
