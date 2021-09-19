using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    abstract class Enemy : Character
    {

        private Random objectNum = new Random();

        public Enemy(int xPosition,int yPosition,int enemyDamage,int startHP,int maxHP, Tiletype symbol):this(xPosition,yPosition)
        {
            
            enemyDamage = Damage; 
            xPosition = X;
            yPosition = Y;
            maxHP = MaxHp;
            startHP = HP;
            symbol = tiletype;
        }

        public override string ToString()
        {
            Console.WriteLine("at" + "[" + X + "," + Y + "]");
        }
    }
}
