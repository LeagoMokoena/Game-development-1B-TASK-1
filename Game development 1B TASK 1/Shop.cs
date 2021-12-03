using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Game_development_1B_TASK_1
{
    class Shop
    {
        private Weapon [] defences;

        private Random ran;

        private Character buyer;

        public Shop(Character _buyer)
        {
            buyer = _buyer;
            defences = new Weapon[3];
            ran = new Random();
            for(int i = 0; i < defences.Length; i++)
            {
                defences[i] = RandomWeapon();
            }
        }


        private Weapon RandomWeapon()
        {
            List<MeleeWeapon.Types> values = Enum.GetValues(typeof(MeleeWeapon.Types)).Cast<MeleeWeapon.Types>().ToList();
            List<RangedWeapons.Types> values2 = Enum.GetValues(typeof(RangedWeapons.Types)).Cast<RangedWeapons.Types>().ToList();
            Random weapon = new Random();
            weapon.Next(values, values2);
        }
    }
}
