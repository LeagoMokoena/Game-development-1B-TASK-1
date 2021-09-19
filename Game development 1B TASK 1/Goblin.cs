using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Goblin:Enemy
    {
        public Goblin(int Xposition,int Yposition)
        {
            Xposition = X;
            Yposition = Y;
            HP = 10;
            Damage = 1;
        }

        public override int Returnmove()
        {
            Random r = new Random();
            Xposition = r.Next();
        }
    }
}
