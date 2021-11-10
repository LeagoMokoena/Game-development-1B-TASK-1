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
            Vision = new Tile[8];
        }

        public override movement Returnmove(movement move = movement.noMovement)
        {
            switch (move)
            {
                case movement.Up:
                    foreach(Tile tile in Vision)
                    {
                        if(tile.Y == Y + 1)
                        {
                            if(tile.tiletype == Tiletype.obstacle)
                            {
                                move = movement.noMovement;
                            }
                            else
                            {
                                move = movement.Up;
                            }
                        }
                    }
                    break;
                case movement.Down:
                    foreach (Tile tile in Vision)
                    {
                        if (tile.Y == Y - 1)
                        {
                            if (tile.tiletype == Tiletype.obstacle)
                            {
                                move = movement.noMovement;
                            }
                            else
                            {
                                move = movement.Down;
                            }
                        }
                    }
                    break;
                case movement.Left:
                    foreach (Tile tile in Vision)
                    {
                        if (tile.X == X - 1)
                        {
                            if (tile.tiletype == Tiletype.obstacle)
                            {
                                move = movement.noMovement;
                            }
                            else
                            {
                                move = movement.Left;
                            }
                        }
                    }
                    break;
                case movement.Right:
                    foreach (Tile tile in Vision)
                    {
                        if (tile.X == X + 1)
                        {
                            if (tile.tiletype == Tiletype.obstacle)
                            {
                                move = movement.noMovement;
                            }
                            else
                            {
                                move = movement.Right;
                            }
                        }
                    }
                    break;
            }
            return move;
        }

        public override string ToString()
        {
            string playerInfo;
            playerInfo = "Player Stats:\n" +
                "HP:" + HP / MaxHp + "\n"+
                "Damage:" + Damage +"\n"+
                "[" + X + "," + Y + "]\n"
                + " Amount of gold: " + GoldPurse.Count + "\n";
            return playerInfo;
            throw new NotImplementedException();
        }
    }
}
