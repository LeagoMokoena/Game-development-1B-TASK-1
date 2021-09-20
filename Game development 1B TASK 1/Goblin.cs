using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Goblin : Enemy
    {
        public Goblin(int _xPosition, int _yParameter, Tiletype symbol, int enemyDamage, int startHP, int maxHP) : base(_xPosition, _yParameter, symbol, enemyDamage, startHP, maxHP)
        {
            HP = 10;
            Damage = 1;
        }

        public override movement Returnmove(movement move = movement.noMovement)
        {
            int direction;
            Random r = new Random();
            direction = r.Next(0,4);
            for (int i= 0; i < 4; i++)
            {
                if(Vision(i) == Tiletype.Hero)
            }
            throw new NotImplementedException();
        }

        /*  //public override int Returnmove()
          {
              Random r = new Random();
              Xposition = r.Next();
          }*/
    }
}
