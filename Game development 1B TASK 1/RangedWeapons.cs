using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class RangedWeapons : Weapon
    {
        public enum Types
        {
            Rifle,
            Longbow
        }

        public Types weaponType;
        public RangedWeapons(int _xPosition, int _yPosition, Tiletype type, char _symbol, Types _weaponType) : base(_xPosition, _yPosition, type, _symbol)
        {
            weaponType = _weaponType;
            X = _xPosition;
            Y = _yPosition;
            Symbol = _symbol;
            if (weaponType == Types.Longbow)
            {
                Longbow();
            }
            else
            {
                Rifle();
            }
        }

        public override int Range()
        {
            return base.Range();
        }

        public void Rifle()
        {
            WeaponType = "Rifle";
            Durability = 3;
            Damage = 5;
            Cost = 7;
        }

        public void Longbow()
        {
            WeaponType = "Longbow";
            Durability = 4;
            Damage = 4;
            Cost = 6;
        }
    }
}
