using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Game_development_1B_TASK_1
{
    public abstract class Character : Tile
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

        private List<Item> goldPurse;

        public List<Item> GoldPurse
        {
            get { return goldPurse; }
            set { goldPurse = value; }
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
        protected Character(int _xPosition, int _yPosition, Tiletype type,char characterSymbol,int starthp, int Maximimuhp,int daMage) : base(_xPosition, _yPosition, type,characterSymbol)
        {
            Symbol = characterSymbol;
            HP = starthp;
            MaxHp = Maximimuhp;
            Damage = daMage;
            goldPurse = new List<Item>();
            Vision = new Tile[8];
        }

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
            switch (move)
            {
                case Character.movement.Up:
                        X -= 1;
                       
                    break;
                case Character.movement.Left:
                        Y -= 1;
                    break;
                case Character.movement.Right:
                        Y += 1;
 
                    break;
                case Character.movement.Down:
                        X += 1;
                    break;
            }
        }

        public void Pickup(Item i)
        {
            if(i.Symbol == 'A')
            {
                goldPurse.Add(i);
            }
        }

        public abstract movement Returnmove(movement move);

        public abstract override string ToString();
    }
}
