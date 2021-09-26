﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Map 
    {
        public Tile[,] mapCharacter;
        private Hero theHero;


        public Hero TheHero
        {
            get { return theHero; }
            set { theHero = value;}
        }

        private Enemy [] theEnemies;

        public Enemy [] TheEnemies
        {
            get { return theEnemies; }
            set { theEnemies = value; }
        }

        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        private Random newItem;

        public Random NewItem
        {
            get { return newItem; }
            set { newItem = value; }
        }

        public Map(int minWidth,int maxWidth,int minHeight,int maxHeight,int enemyNum)
        {
            newItem = new Random();
            theHero = new Hero(1,5,Tile.Tiletype.Hero,10,10,2,'H');
            width = newItem.Next(minWidth, maxWidth);
            height = newItem.Next(minHeight, maxHeight);
            mapCharacter = new Tile[width, height];
            theEnemies = new Enemy[enemyNum];
            creatObstacle();
            createEmptyTile();
            Create(Tile.Tiletype.Hero);
            for(int i = 0; i < enemyNum; i++)
            {
                enemyNum = i;
                Create(Tile.Tiletype.Enemy);
            }
            UpdateVision();
        }

        public void UpdateVision()
        {
            theHero.Vision[1] = mapCharacter[theHero.X - 1, theHero.Y];
            theHero.Vision[2] = mapCharacter[theHero.X + 1, theHero.Y];
            theHero.Vision[3] = mapCharacter[theHero.X, theHero.Y + 1];
            theHero.Vision[4] = mapCharacter[theHero.X, theHero.Y - 1];

            for(int i = 0; i < theEnemies.Length; ++i)
            {
                theEnemies[i].Vision[1] = mapCharacter[theEnemies[i].X - 1, theEnemies[i].Y];
                theEnemies[i].Vision[2] = mapCharacter[theEnemies[i].X + 1, theEnemies[i].Y];
                theEnemies[i].Vision[3] = mapCharacter[theEnemies[i].X, theEnemies[i].Y + 1];
                theEnemies[i].Vision[4] = mapCharacter[theEnemies[i].X, theEnemies[i].Y - 1];
            }
        }

        private Enemy newEnemy;

        public Enemy NewEnemy
        {
            get { return newEnemy; }
            set { newEnemy = value; }
        }


        private Tile Create(Tile.Tiletype tiletype)
        {
            bool found = false;
            int xpoint = newItem.Next(0, width);
            int ypoint = newItem.Next(0, height);
            mapCharacter[1,0] = new Hero(6, 7, tiletype, 6, 7, 8, 's');
            switch (tiletype)
            {
                case Tile.Tiletype.Hero:
                    theHero.X = xpoint;
                    theHero.Y = ypoint;
                    mapCharacter[xpoint, ypoint] = theHero;
                    while (found == false)
                    {
                        if (mapCharacter[xpoint, ypoint] != empty_Tile)
                        {
                            xpoint = newItem.Next(0, width);
                            ypoint = newItem.Next(0, height);
                            theHero.X = xpoint;
                            theHero.Y = ypoint;
                            mapCharacter[xpoint, ypoint] = theHero;
                        }
                        else
                        {
                            found = true;
                        }
                    }
                    break;
                case Tile.Tiletype.Enemy:
                    theEnemies[Enemynum].X = xpoint;
                    theEnemies[Enemynum].Y = ypoint;
                    mapCharacter[xpoint, ypoint] = theEnemies[Enemynum];
                    while (found == false)
                    { if (mapCharacter[xpoint, ypoint] != empty_Tile)
                        {
                            xpoint = newItem.Next(0, width);
                            ypoint = newItem.Next(0, height);
                            theEnemies[Enemynum].X = xpoint;
                            theEnemies[Enemynum].Y = ypoint;
                            mapCharacter[xpoint, ypoint] = theEnemies[Enemynum];
                        }
                        else
                        {
                            found = true;
                        }
                    }
                    break;
            }
            // case Tile.Tiletype.Enemy:
            // newEnemy.X = newItem.Next(0, width);
            // newEnemy.Y = newItem.Next(0, height);
            //  break;
            //case Tile.Tiletype.Gold:
            //  Gold.X = newItem.Next(0, width);
            //Gold.Y = newItem.Next(0, height);
            //break;
            //case Tile.Tiletype.Weapon:
            //  MeleeWeapon.X = newItem.Next(0, width);
            //MeleeWeapon.Y = newItem.Next(0, height);
            //break;

            return mapCharacter[xpoint, ypoint];
        }

        private Obstacle obstacleX;

        public Obstacle ObstacleX
        {
            get { return obstacleX; }
            set { obstacleX = value; }
        }

        private EmptyTile empty_Tile;

        public EmptyTile Empty_Tile
        {
            get { return empty_Tile; }
            set { empty_Tile = value; }
        }


        private void creatObstacle()
        {
            for (int Xvalues = 0; Xvalues < width; Xvalues++)
            {
                for (int Yvalues = 0; Yvalues < height; Yvalues++)
                {
                    if (((Yvalues == 0 || Yvalues < height) && Xvalues >= 0 || Xvalues < width))
                    {
                        mapCharacter[Xvalues, Yvalues] = obstacleX;
                    }
                }
            }
        }

        private void createEmptyTile()
        {
            for (int Xvalues = 0; Xvalues < width; Xvalues++)
            {
                for (int Yvalues = 0; Yvalues < height; Yvalues++)
                {
                    if (((Yvalues > 0 || Yvalues < height - 1) && Xvalues > 0 || Xvalues < width - 1))
                    {
                        mapCharacter[Xvalues, Yvalues] = null;
                    }
                }
            }
        }

        public int Enemynum;
    }
}
