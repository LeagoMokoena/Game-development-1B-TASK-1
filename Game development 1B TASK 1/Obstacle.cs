using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Obstacle : Tile
    {
        public Obstacle(int _xPosition,int _yPosition, Tiletype type):base(_xPosition,_yPosition,type)
        {
            for(int Xvalues = 0; Xvalues <= _xPosition; Xvalues++)
            {
                for(int Yvalues = 0; Yvalues <= _yPosition; Yvalues++)
                {
                    if(((Yvalues == 1 || Yvalues == _yPosition)&& Xvalues != 0 && Xvalues != _xPosition)||((Xvalues==0||Xvalues==_xPosition)&&Yvalues>1&& Yvalues < _yPosition))
                    {

                    }
                }
            }

        }
    }
}
