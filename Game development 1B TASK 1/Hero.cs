using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Game_development_1B_TASK_1
{
    public class Hero : Character
    {
        public Hero(int _xPosition, int _yParameter, Tiletype symbol,int _hp,int _maxHp,int _damage, char characterSymbol) : base(_xPosition, _yParameter, symbol,characterSymbol)
        {
            MaxHp = _maxHp;
            HP=_hp;
            Damage= _damage = 2;
            characterSymbol = 'X';
        }

        public override movement Returnmove(movement move)
        {
            switch (move)
            {
                case movement.Up:
                    if(Vision[north].tiletype != Tile.Tiletype.empty)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Up;
                    }
                    break;
                case movement.Down:
                    if (Vision[south].tiletype != Tiletype.empty)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Down;
                    }
                    break;
                case movement.Left:
                    if (Vision[west].tiletype != Tiletype.empty)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Left;
                    }
                    break;
                case movement.Right:
                    if (Vision[east].tiletype != Tiletype.empty)
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
