using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class MeleeWeapon : Weapon
    {

        public enum Types
        {
            Dagger,
            Longsword
        }

        public Types weaponType;
        public MeleeWeapon(int _xPosition, int _yPosition, Tiletype type, char _symbol,Types _weaponType) : base(_xPosition, _yPosition, type, _symbol)
        {
            weaponType = _weaponType;
            X = _xPosition;
            Y = _yPosition;
            Symbol = _symbol;
            if(weaponType == Types.Dagger)
            {
                daggerStats();
            }
            else
            {
                longswordStats();
            }
        }

        public override int Range()
        {
            return 1;
        }

        public void daggerStats()
        {
            WeaponType = "Dagger";
            Durability = 10;
            Damage = 3;
            Cost = 3;
        }

        public void longswordStats()
        {
            WeaponType = "Longsword";
            Durability = 6;
            Damage = 4;
            Cost = 5;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }

}
