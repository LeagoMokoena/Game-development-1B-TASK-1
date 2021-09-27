using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Game_development_1B_TASK_1
{
    public class Obstacle : Tile
    {
        public Obstacle(int _xPosition,int _yPosition, Tiletype type,char symbol):base(_xPosition,_yPosition,type,symbol)
        {
        }
    }
}
