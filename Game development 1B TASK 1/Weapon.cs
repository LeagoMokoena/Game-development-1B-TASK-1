using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    abstract class Weapon : Item
    {
        private int damage;

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }


        public override string ToString()
        {
            throw new NotImplementedException();
        }

        private int durability;

        public int Durability
        {
            get { return durability; }
            set { durability = value; }
        }

        private int cost;

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }


        public Weapon(int _xPosition, int _yPosition, Tiletype type, char _symbol) : base(_xPosition, _yPosition, type, _symbol)
        {

        }

        private string weaponType;
        public string WeaponType
        {
            get { return weaponType; }
            set { weaponType = value; }
        }

        public virtual int Range()
        {
            return 0;
        }
    }
}
