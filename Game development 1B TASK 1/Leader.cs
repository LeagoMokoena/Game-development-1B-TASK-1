using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Leader : Enemy
    {
        private Tile Hero
        {
            get { return Hero; }
            set { Hero = value; }
        }

        public Leader(int _xPosition, int _yPosition, Tiletype type, char characterSymbol, Tile HERO,int starthp = 20, int Maximimuhp = 20, int daMage = 2) : base(_xPosition, _yPosition, type, characterSymbol, starthp, Maximimuhp, daMage)
        {
            HP = starthp;
            Damage = daMage;
            Hero = HERO;
        }


        public override movement Returnmove(movement move)
        {
            bool _move = false;
            int Num;
            if(X == Hero.X - 1 && Y == Hero.Y)
            {
                move = movement.Up;
            }
            else if(X == Hero.X && Hero.Y < Y)
            {
                move = movement.Left;
            }
            else if(X == Hero.X && Hero.Y > Y)
            {
                move = movement.Right;
            }
            else
            {
                move = movement.Down;
            }
            while(_move == false)
            {
                _move = checkSurroundings(move);
                if (_move == false)
                {
                    Random r = new Random();
                    Num = r.Next(1, 4);
                    if(Num == 1)
                    {
                        move = movement.Up;
                    }
                    else if(Num == 2)
                    {
                        move = movement.Down;
                    }
                    else if(Num == 3)
                    {
                        move = movement.Left;
                    }
                    else
                    {
                        move = movement.Right;
                    }

                }
                
            }
            return move;
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool checkSurroundings(Character.movement movements)
        {
            bool playerMove;
            if (movements == Character.movement.Up)
            {
                if (Vision[0].tiletype == Tile.Tiletype.obstacle || Vision[0].tiletype == Tiletype.Enemy)
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
                if (Vision[3].tiletype == Tile.Tiletype.obstacle || Vision[3].tiletype == Tiletype.Enemy)
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
                if (Vision[1].tiletype == Tile.Tiletype.obstacle || Vision[1].tiletype == Tiletype.Enemy)
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
                if (Vision[2].tiletype == Tile.Tiletype.obstacle || Vision[2].tiletype == Tiletype.Enemy)
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
