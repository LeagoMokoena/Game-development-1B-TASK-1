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
            Map space = new Map(6,6,7,5,2);

        }

        public bool MovePlayer(Character.movement direction)
        {
            bool move = false;
            if (direction != Character.movement.noMovement)
            {
                switch (direction)
                {
                    case Character.movement.Up:
                        area.mapCharacter[area.TheHero.X - 1, area.TheHero.Y] = new Obstacle(area.TheHero.X - 1, area.TheHero.Y, Tile.Tiletype.Gold, area.Width, area.Height);
                        break;
                    case Character.movement.Down:
                        area.mapCharacter[area.TheHero.X + 1, area.TheHero.Y] = new Obstacle(area.TheHero.X + 1, area.TheHero.Y, Tile.Tiletype.Gold, area.Width, area.Height);
                        break;
                    case Character.movement.Right:
                        area.mapCharacter[area.TheHero.X, area.TheHero.Y + 1] = new Obstacle(area.TheHero.X, area.TheHero.Y + 1, Tile.Tiletype.Gold, area.Width, area.Height);
                        break;
                    case Character.movement.Left:
                        area.mapCharacter[area.TheHero.X, area.TheHero.Y - 1] = new Obstacle(area.TheHero.X, area.TheHero.Y - 1, Tile.Tiletype.Gold, area.Width, area.Height);
                        break;
                }
                move = true;
            }

            return move;
        }

        public override string ToString()
        {
            return base.ToString(area.MapCharacter[,]);
        }

        private static readonly char enemy = 'G';
        private static readonly char Hero = 'H';
        private static readonly char Obstacle = 'X';
    }
}
