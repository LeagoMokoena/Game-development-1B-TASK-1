using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class GameEngine
    {
        private Map area;

        public Map Area
        {
            get { return area; }
            set { area = value; }
        }

        public GameEngine()
        {
            Map space = new Map();

        }

        public bool MovePlayer(Character.movement direction)
        {
            
        }
    }
}
