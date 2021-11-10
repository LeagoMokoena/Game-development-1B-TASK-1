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
            MaxHp = _maxHp = 2;
            HP=_hp = 50;
            Damage= _damage = 2;
            characterSymbol = 'H';
            Vision = new Tile[8];
        }

    

        public override movement Returnmove(movement move = movement.noMovement)
        {
            bool canMove;
            canMove = checkSurroundings(move);
            switch (move)
            {
                case movement.Up:
                    if(canMove == false)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Up;
                    }
                    break;
                case movement.Down:
                    if (canMove == false)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Down;
                    }

                    break;
                case movement.Left:
                    if (canMove == false)
                    {
                        move = movement.noMovement;
                    }
                    else
                    {
                        move = movement.Left;
                    }
                    break;
                case movement.Right:
                    if (canMove == false)
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

        public bool checkSurroundings(Character.movement movements)
        {
            bool playerMove = false;
            if (movements == Character.movement.Up)
            {
                if (Vision[1].tiletype == Tile.Tiletype.obstacle || Vision[1].tiletype == Tiletype.Enemy)
                {
                    playerMove = false;
                }
                else
                {
                    playerMove = true;
                }
            }
            else if (movements == Character.movement.Down)
            {
                if (Vision[6].tiletype == Tile.Tiletype.obstacle || Vision[6].tiletype == Tiletype.Enemy)
                {
                    playerMove = false;
                }
                else
                {
                    playerMove = true;
                }
            }
            else if (movements == Character.movement.Left)
            {
                if (Vision[3].tiletype == Tile.Tiletype.obstacle || Vision[3].tiletype == Tiletype.Enemy)
                {
                    playerMove = false;
                }
                else
                {
                    playerMove = true;
                }
            }
            else
            {
                if (Vision[4].tiletype == Tile.Tiletype.obstacle || Vision[4].tiletype == Tiletype.Enemy)
                {
                    playerMove = false;
                }
                else
                {
                    playerMove = true;
                }
            }
            return playerMove;
        }
    }
}
