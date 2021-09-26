using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Obstacle : Tile
    {
        public Obstacle(int _xPosition,int _yPosition, Tiletype type,int Xparameter,int Yparameter,char symbol):base(_xPosition,_yPosition,type,symbol)
        {
        }
    }
}
