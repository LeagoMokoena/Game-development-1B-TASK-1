﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    abstract class Enemy : Character
    {

        private Random objectNum = new Random();

        protected Enemy(int _xPosition, int _yParameter, Tiletype symbol, int enemyDamage, int startHP, int maxHP) : base(_xPosition, _yParameter, symbol)
        {
            enemyDamage = Damage;
            maxHP = MaxHp;
            startHP = HP;
            symbol = tiletype;
        }

        public override string ToString()
        {
            string EnemyInfo;
            EnemyInfo = "Goblin at" + "[" + X.ToString() + "," + Y.ToString() + "]("+Damage+")";
            return EnemyInfo;
   

        }
    }
}
