using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Hero:Character
    {
        public Hero(int _xposition, int _yposition, int _hp) : this(_xposition, _yposition)
        {
            _xposition = X;
            _yposition = Y;
            _hp = HP;
            Damage = 2;
        }
    }
}
