using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Gold : Item
    {
        private int amount;

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public Random goldNum = new Random();

        public Gold(int _xPosition, int _yPosition, Tiletype type, char _symbol) : base(_xPosition, _yPosition, type, _symbol)
        {
            int amount = goldNum.Next(1, 5);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
