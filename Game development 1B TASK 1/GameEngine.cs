﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;

namespace Game_development_1B_TASK_1
{
    public class GameEngine
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
            game.UpdateVision();
            direction = game.TheHero.Returnmove(direction);

            if (direction != Character.movement.noMovement)
            {
                game.mapCharacter[game.TheHero.X, game.TheHero.Y] = new EmptyTile(game.TheHero.X, game.TheHero.Y, Tile.Tiletype.empty, '.');
                game.TheHero.Move(direction);
                game.mapCharacter[game.TheHero.X, game.TheHero.Y] = game.TheHero;
                move = true;
            }
            else
            {
                move = false;
            }
               
            return move;
        }

        public override string ToString()
        {
            string mapDesign = "";

            //game.TheHero.Symbol = Hero;
            //game.ObstacleX.Symbol = Obstacle;
            //game.Empty_Tile.Symbol = Emptytile;
           // for(int x = 0; x < game.TheEnemies.Length; x++)
            {
               // game.TheEnemies[x].Symbol = enemy;
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

    }
}
