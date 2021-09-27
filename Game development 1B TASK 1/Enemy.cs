using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Game_development_1B_TASK_1
{
   public abstract class Enemy : Character
    {

        private Random objectNum = new Random();

        protected Enemy(int _xPosition, int _yParameter, Tiletype symbol, char characterSymbol,int enemyDamage,int startHP, int maxHP) : base(_xPosition, _yParameter, symbol, characterSymbol)
        {
            Vision = new Tile[4];
            enemyDamage = Damage;
            maxHP = MaxHp;
            startHP = HP;
        }

        public override string ToString()
        {
            string EnemyInfo;
            EnemyInfo = "Goblin at" + "[" + X.ToString() + "," + Y.ToString() + "]("+Damage+")";
            return EnemyInfo;
   

        }
    }
}
