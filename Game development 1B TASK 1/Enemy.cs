﻿using System;
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
            enemyDamage = Damage;
            maxHP = MaxHp;
            startHP = HP;
        }

        public override string ToString()
        {
            string EnemyInfo;
            EnemyInfo = "Goblin at" + "[" + X.ToString() + "," + Y.ToString() + "] \n" + HP.ToString() + " HP \n" +"{" + Damage.ToString() + "}";
            return EnemyInfo;
   

        }
    }
}
