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
            Vision = new Tile[4];
        }

        public override movement Returnmove(movement move = movement.noMovement)
        {
            bool canMove;
            canMove = enemyMove(move);
            switch (move)
            {
                case movement.Up:
                    if (canMove == false)
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


        public bool enemyMove(Character.movement movements)
        {
            bool playerMove = false;
            if (movements == Character.movement.Up)
            {
                if (Vision[0].tiletype == Tile.Tiletype.obstacle)
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
                if (Vision[3].tiletype == Tile.Tiletype.obstacle)
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
                if (Vision[1].tiletype == Tile.Tiletype.obstacle)
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
                if (Vision[2].tiletype == Tile.Tiletype.obstacle)
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
