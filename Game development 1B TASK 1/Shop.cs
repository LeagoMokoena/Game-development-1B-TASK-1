using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Game_development_1B_TASK_1
{
    public class Shop
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
            char weap;
            weap = (char)ran.Next('a', 'd');
            if (weap == 'a')
            {
                MeleeWeapon newMeleeWeapon = new MeleeWeapon(1, 1, Tile.Tiletype.Weapon, 'D', MeleeWeapon.Types.Dagger);
                return newMeleeWeapon;
            }
            else if(weap == 'b')
            {
                MeleeWeapon newMeleeWeapon = new MeleeWeapon(1, 1, Tile.Tiletype.Weapon, 'S', MeleeWeapon.Types.Longsword);
                return newMeleeWeapon;
            }
            else if(weap == 'c')
            {
                RangedWeapons newRangedweapon = new RangedWeapons(1, 1, Tile.Tiletype.Weapon, 'R', RangedWeapons.Types.Rifle);
                return newRangedweapon;
            }
            else
            {
                RangedWeapons newRangedweapon = new RangedWeapons(1, 1, Tile.Tiletype.Weapon, 'B', RangedWeapons.Types.Longbow);
                return newRangedweapon;
            }
        }

        public bool CanBuy(int num)
        {
            if(buyer.GoldPurse.Count == defences[num].Cost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Buy(int num)
        {
            int count = buyer.GoldPurse.Count;
            for(int i = 0; i < defences[num].Cost; i++)
            {
                buyer.GoldPurse.RemoveAt(count);
                count--;
            }

            buyer.Pickup(defences[num]);
            defences[num] = RandomWeapon();
        }

        public string DisplayWeapon(int num)
        {
            return "Buy " + defences[num].WeaponType + " (" + defences[num].Cost + " Gold)";
        }
    }
}
