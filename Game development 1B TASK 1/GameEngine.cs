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
            direction = area.TheHero.Returnmove(direction);

            if (direction != Character.movement.noMovement)
            {
                area.mapCharacter[area.TheHero.X, area.TheHero.Y] = area.Empty_Tile;
                area.TheHero.Move(direction);
            }

            area.UpdateVision();
                return move;
        }

        public override string ToString()
        {
            string mapDesign = "";

            area.TheHero.Symbol = Hero;
            area.ObstacleX.Symbol = Obstacle;
            area.Empty_Tile.Symbol = Emptytile;
            for(int x = 0; x < area.TheEnemies.Length; x++)
            {
                area.TheEnemies[x].Symbol = enemy;
            }

            for (int i = 0; i < area.Width; i++)//for loop displaying the values in the map array in the game map
            {
                for (int j = 0; j < area.Height; j++)
                {

                    mapDesign += area.mapCharacter[i, j].Symbol;
                }

                mapDesign += "\n";
            }

            return mapDesign;
        }

        private static readonly char enemy = 'G';
        private static readonly char Hero = 'H';
        private static readonly char Obstacle = 'X';
        private static readonly char Emptytile = '.';
    }
}
