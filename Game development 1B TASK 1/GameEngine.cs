using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class GameEngine
    {
        private Map game;

        public Map Game
        {
            get { return game; }
            set { game = value; }
        }



        public GameEngine(int minwidth, int maxwidth,int minheight,int maxheight,int enemynumber)
        {
            game = new Map(minwidth,maxwidth,minheight,maxheight,enemynumber);

        }

        public bool MovePlayer(Character.movement direction)
        {
            bool move = false;
            direction = game.TheHero.Returnmove(direction);

            if (direction != Character.movement.noMovement)
            {
                game.mapCharacter[game.TheHero.X, game.TheHero.Y] = game.Empty_Tile;
                game.TheHero.Move(direction);
            }

            game.UpdateVision();
                return move;
        }

        public override string ToString()
        {
            string mapDesign = "";

            game.TheHero.Symbol = Hero;
            game.ObstacleX.Symbol = Obstacle;
            game.Empty_Tile.Symbol = Emptytile;
            for(int x = 0; x < game.TheEnemies.Length; x++)
            {
                game.TheEnemies[x].Symbol = enemy;
            }

            for (int i = 0; i < game.Width; i++)//for loop displaying the values in the map array in the game map
            {
                for (int j = 0; j < game.Height; j++)
                {

                    mapDesign += game.mapCharacter[i, j].Symbol;
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
