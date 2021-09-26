using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Hero : Character
    {
        public Hero(int _xPosition, int _yParameter, Tiletype symbol,int _hp,int _maxHp,int _damage, char characterSymbol) : base(_xPosition, _yParameter, symbol,characterSymbol)
        {
            MaxHp = _maxHp;
            HP=_hp;
            Damage= _damage = 2;
            characterSymbol = 'X';
        }

        public override movement Returnmove(movement move = movement.noMovement)
        {
            switch (move)
            {
                case movement.Up:
                    if(Vision[north] != null)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Up;
                    }
                    break;
                case movement.Down:
                    if (Vision[south] != null)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Down;
                    }
                    break;
                case movement.Left:
                    if (Vision[west] != null)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Left;
                    }
                    break;
                case movement.Right:
                    if (Vision[east] != null)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Right;
                    }
                    break;
            }
            return move;
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string playerInfo;
            playerInfo = "Player Stats:\n" +
                "HP:" + HP / MaxHp + "\n"+
                "Damage:" + Damage +"\n"+
                "[" + X + "," + Y + "]\n";
            return playerInfo;
            throw new NotImplementedException();
        }
    }
}
