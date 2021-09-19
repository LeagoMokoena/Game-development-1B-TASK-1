using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    abstract class Character:Tile
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

        public Tile[] vision = new Tile[4];

        public enum movement
        {
            noMovement,
            Up,
            Down,
            Left,
            Right
        }

        public Character(int Xparameter, int Yparameter, Tiletype Symbol) : base(Xparameter, Yparameter, Symbol)
        {
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

        }

        private int DistanceTo(Character target)
        {

        }

        public void Move(movement move)
        {

        }

        public abstract movement Returnmove(movement move = 0)
        {

        }

        public abstract override string ToString();
    }
}
