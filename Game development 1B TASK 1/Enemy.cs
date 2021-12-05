using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Game_development_1B_TASK_1
{
   public abstract class Enemy : Character
    {

        private Random objectNum = new Random();

        protected Enemy(int _xPosition, int _yPosition, Tiletype type, char characterSymbol, int starthp, int Maximimuhp, int daMage) : base(_xPosition, _yPosition, type, characterSymbol, starthp, Maximimuhp, daMage)
        {
            Damage = daMage;
            MaxHp = Maximimuhp;
            HP = starthp;
        }

        public override string ToString()
        {
            string EnemyInfo;
            EnemyInfo = HP+"/"+MaxHp+"HP) at" + "[" + X.ToString() + "," + Y.ToString() + "]";
            return EnemyInfo;
   

        }
    }
}
