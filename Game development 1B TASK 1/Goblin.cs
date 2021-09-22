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
            bool _move = false;
            int direction;
            Random r = new Random();
            direction = r.Next(0,4);
            move = (movement)direction;
            while(_move == false)
            {
                switch (direction)
                {
                    case 0:
                        if(Vision[north].tiletype == Tiletype.Hero || Vision[north].tiletype == )
                }
                    

                if(Vision[i].tiletype == Tiletype.Hero)
                {
                    direction = r.Next(0, 4);
                    move = (movement)direction;
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
