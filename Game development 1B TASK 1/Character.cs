using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    abstract class Character : Tile
    {
        private int hP;

        public int HP
        {
            get { return hP; }
            set { hP = value; }
        }

        private int maxHP;

        public int MaxHp
        {
            get { return maxHP; }
            set { maxHP = value; }
        }

        private int damage;

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        private Tile [] vision;

        public Tile [] Vision
        {
            get { return vision; }
            set { vision = value; }
        }

        public enum movement
        {
            noMovement,
            Up,
            Down,
            Left,
            Right
        }

       /* public Character(int Xposition,int Yposition,Tiletype Symbol)
        {
            Xposition = X;
            Yposition = Y;
            Symbol = tiletype;
        }*/
/*        public Character(Tiletype Symbol) : this(Symbol,Symbol)
        {
        }*/

        protected Character(int _xPosition, int _yParameter, Tiletype symbol) : base(_xPosition, _yParameter, symbol)
        {
            Vision = new Tile[4];
        }

        public int north = 1;
        public int south = 2;
        public int east = 3;
        public int west = 4;

        public virtual void Attack(Character target)
        {
            target.hP -= damage;
        }

        public bool IsDead()
        {
            if (hP <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool CheckRange(Character target)
        {
            int barehanded = 1;
            if(DistanceTo(target) < barehanded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int DistanceTo(Character target)
        {
            return Math.Abs(X - target.X) + Math.Abs(Y - target.Y);
        }

        public void Move(movement move)
        {
            if(move == movement.noMovement)
            {
                X = X;
                Y = Y;
            }
            else if(move == movement.Up)
            {
                Y += 1;
            }
            else if(move == movement.Down)
            {
                Y -= 1;
            }
            else if(move == movement.Left)
            {
                X -= 1;
            }
            else
            {
                X += 1;
            }
        }

        public abstract movement Returnmove(movement move = 0);

        public abstract override string ToString();
    }
}
