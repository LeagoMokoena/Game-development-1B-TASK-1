using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Mage : Enemy
    {
        public Mage(int _xPosition, int _yPosition, Tiletype type, char characterSymbol, int starthp, int Maximimuhp, int daMage, List<Item> GOLD) : base(_xPosition, _yPosition, type, characterSymbol, starthp, Maximimuhp, daMage, GOLD)
        {
            Vision = new Tile[8];
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
            return 0;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
