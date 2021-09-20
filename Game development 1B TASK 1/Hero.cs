using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Hero : Character
    {
        public Hero(int _xPosition, int _yParameter, Tiletype symbol,int _hp,int _maxHp) : base(_xPosition, _yParameter, symbol)
        {
            MaxHp = _maxHp;
            HP=_hp;
            Damage = 2;
        }

        public override movement Returnmove(movement move = movement.noMovement)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string playerInfo;
            playerInfo = "Player Stats:" +
                "HP:" + HP / MaxHp +
                "Damage:" + Damage +
                "[" + X + "," + Y + "]";
            return playerInfo;
            throw new NotImplementedException();
        }
    }
}
