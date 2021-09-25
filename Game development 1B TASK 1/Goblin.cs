using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Goblin : Enemy
    {
        public Goblin(int _xPosition, int _yParameter, Tiletype symbol, char characterSymbol, int enemyDamage, int startHP, int maxHP) : base(_xPosition, _yParameter, symbol, characterSymbol, enemyDamage, startHP, maxHP)
        {
            startHP = 10;
            enemyDamage = 1;
            maxHP = 10;
        }

        public override movement Returnmove(movement move = movement.noMovement)
        {
            bool _move = false;
            int direction;
            Random r = new Random();
            direction = r.Next(0,4);
            while (_move == false)
            {
                if (Vision[direction] != null)
                {
                    direction = r.Next(0, 4);
                    move = (movement)direction;
                }
                else
                {
                    move = (movement)direction;
                    _move = true;
                }
            }
            return move;
            throw new NotImplementedException();
        }

        /*  //public override int Returnmove()
          {
              Random r = new Random();
              Xposition = r.Next();
          }*/
    }
}
