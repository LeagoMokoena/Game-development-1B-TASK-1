using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Game_development_1B_TASK_1
{
    public class Goblin : Enemy
    {
        public Goblin(int _xPosition, int _yParameter, Tiletype symbol, char characterSymbol, int enemyDamage, int startHP, int maxHP) : base(_xPosition, _yParameter, symbol, characterSymbol, enemyDamage, startHP, maxHP)
        {
            startHP = 10;
            enemyDamage = 1;
            maxHP = 10;
        }

        public override movement Returnmove(movement move = movement.noMovement)
        {
            switch (move)
            {
                case movement.Up:
                    foreach (Tile tile in Vision)
                    {
                        if (tile.Y == Y + 1)
                        {
                            if (tile.tiletype == Tiletype.obstacle)
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

        /*public override movement Returnmove(movement move)
        {
            bool _move = false;
            int direction;
            Random r = new Random();
            direction = r.Next(0, 4);
            /*switch (move)
            {
                case movement.Up:
                    if (Vision[north].tiletype != Tile.Tiletype.empty)
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
            /*
            return move;
            /*while (_move == false)
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
