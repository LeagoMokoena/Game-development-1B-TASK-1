using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Obstacle : Tile
    {
        public Obstacle(int _xParameter,int _yParameter, Tiletype symbol):base(_xParameter,_yParameter,symbol)
        {
            for(int Xvalues = 0; Xvalues <= _xParameter; Xvalues++)
            {
                for(int Yvalues = 0; Yvalues <= _yParameter; Yvalues++)
                {
                    if(((Yvalues == 1 || Yvalues == _yParameter)&& Xvalues != 0 && Xvalues != _xParameter)||((Xvalues==0||Xvalues==_xParameter)&&Yvalues>1&& Yvalues < _yParameter))
                    {

                    }
                }
            }

        }
    }
}
