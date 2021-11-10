using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Mage : Enemy
    {
        public Mage(int _xPosition, int _yParameter, Tiletype symbol, char characterSymbol, int enemyDamage, int startHP, int maxHP) : base(_xPosition, _yParameter, symbol, characterSymbol, enemyDamage, startHP, maxHP)
        {
            startHP = 5;
            maxHP = 5;
            enemyDamage = 10;
        }

        public override void Attack(Character target)
        {
            base.Attack(target);
        }

        public override bool CheckRange(Character target)
        {
            bool targets = false;
            foreach(Tile character in Vision)
            {
                if(character.tiletype == target.tiletype)
                {
                    targets = true;
                }
                else
                {
                    targets = false;
                }
            }
            return targets;
        }

        public override movement Returnmove(movement move)
        {
            return movement.noMovement;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
