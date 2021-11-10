using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Game_development_1B_TASK_1
{
    public class Map
    {
        public Tile[,] mapCharacter;

        private Item[] mapItems;

        public Item[] MapItems
        {
            get { return mapItems; }
            set { mapItems = value; }
        }

        public int goldnum;

        public int enemyDigit;

        private Hero theHero;

        public Hero TheHero
        {
            get { return theHero; }
            set { theHero = value; }
        }


        private Enemy[] theEnemies;

        public Enemy[] TheEnemies
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

        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int enemyNum, int goldDrops)
        {
            newItem = new Random();
            width = newItem.Next(minWidth, maxWidth);
            height = newItem.Next(minHeight, maxHeight);
            mapCharacter = new Tile[width, height];
            theEnemies = new Enemy[enemyNum];
            mapItems = new Item[goldDrops];
            createEmptyTile();
            creatObstacle();
            Create(Tile.Tiletype.Hero);
            for (int i = 0; i < enemyNum; i++)
            {
                enemyDigit = newItem.Next(0, 2);
                Enemynum = i;
                Create(Tile.Tiletype.Enemy);
            }
            for (int j = 0; j < goldDrops; j++)
            {
                goldnum = j;
                Create(Tile.Tiletype.Gold);
            }
            UpdateVision();
        }



        public void UpdateVision()
        {
            foreach(Enemy en in theEnemies)
            {
                en.Vision[0] = mapCharacter[en.X - 1, en.Y - 1];
                en.Vision[1] = mapCharacter[en.X - 1, en.Y];
                en.Vision[2] = mapCharacter[en.X - 1, en.Y + 1];
                en.Vision[3] = mapCharacter[en.X, en.Y - 1];
                en.Vision[4] = mapCharacter[en.X, en.Y + 1];
                en.Vision[5] = mapCharacter[en.X + 1, en.Y - 1];
                en.Vision[6] = mapCharacter[en.X + 1, en.Y];
                en.Vision[7] = mapCharacter[en.X + 1, en.Y + 1];
            }

            theHero.Vision[0] = mapCharacter[theHero.X - 1, theHero.Y - 1];
            theHero.Vision[1] = mapCharacter[theHero.X - 1, theHero.Y];
            theHero.Vision[2] = mapCharacter[theHero.X - 1, theHero.Y + 1];
            theHero.Vision[3] = mapCharacter[theHero.X, theHero.Y - 1];
            theHero.Vision[4] = mapCharacter[theHero.X, theHero.Y + 1];
            theHero.Vision[5] = mapCharacter[theHero.X + 1, theHero.Y - 1];
            theHero.Vision[6] = mapCharacter[theHero.X + 1, theHero.Y];
            theHero.Vision[7] = mapCharacter[theHero.X + 1, theHero.Y + 1];
        }

        private Enemy newEnemy;

        public Enemy NewEnemy
        {
            get { return newEnemy; }
            set { newEnemy = value; }
        }


        public Tile Create(Tile.Tiletype tiletype)
        {
            bool found = false;
            int xpoint = newItem.Next(0, width);
            int ypoint = newItem.Next(0, height);
            //mapCharacter[1,0] = new Hero(6, 7, tiletype, 6, 7, 8, 's');
            switch (tiletype)
            {
                case Tile.Tiletype.Hero:
                    //theHero.X = xpoint;
                    //theHero.Y = ypoint;
                    //mapCharacter[xpoint, ypoint] = theHero;
                    while (found == false)
                    {
                        if (mapCharacter[xpoint, ypoint].tiletype != Tile.Tiletype.empty)
                        {
                            xpoint = newItem.Next(0, width);
                            ypoint = newItem.Next(0, height);
                            //theHero.X = xpoint;
                            //theHero.Y = ypoint;
                        }
                        else
                        {
                            theHero = new Hero(xpoint, ypoint, Tile.Tiletype.Hero, 100, 100, 10, 'H');
                            mapCharacter[xpoint, ypoint] = theHero;
                            found = true;
                        }
                    }
                    break;
                case Tile.Tiletype.Enemy:
                    //theEnemies[Enemynum].X = xpoint;
                    //theEnemies[Enemynum].Y = ypoint;
                    //mapCharacter[xpoint, ypoint] = theEnemies[Enemynum];
                    while (found == false)
                    {
                        if (mapCharacter[xpoint, ypoint].tiletype != Tile.Tiletype.empty)
                        {
                            xpoint = newItem.Next(0, width);
                            ypoint = newItem.Next(0, height);
                            //theEnemies[Enemynum].X = xpoint;
                            // theEnemies[Enemynum].Y = ypoint;
                            // mapCharacter[xpoint, ypoint] = theEnemies[Enemynum];
                        }
                        else if (enemyDigit == 1)
                        {
                            theEnemies[Enemynum] = new Goblin(xpoint, ypoint, Tile.Tiletype.Enemy, 'G', 1, 10, 10);
                            mapCharacter[xpoint, ypoint] = theEnemies[Enemynum];
                            found = true;
                        }
                        else
                        {
                            theEnemies[Enemynum] = new Mage(xpoint, ypoint, Tile.Tiletype.Enemy, 'M', 10, 5, 5);
                            mapCharacter[xpoint, ypoint] = theEnemies[Enemynum];
                            found = true;
                        }
                    }
                    break;
                case Tile.Tiletype.Gold:
                    while(found == false)
                    {
                        if(mapCharacter[xpoint,ypoint].tiletype != Tile.Tiletype.empty)
                        {
                            xpoint = newItem.Next(0, width);
                            ypoint = newItem.Next(0, height);
                        }
                        else
                        {
                            mapItems[goldnum] = new Gold(xpoint, ypoint, Tile.Tiletype.Gold, 'A');
                            mapCharacter[xpoint, ypoint] = mapItems[goldnum];
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

            enemyDigit = newItem.Next(1, 2);
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
                    if (Xvalues == 0 && Yvalues >= 0 || Xvalues < width && Yvalues == 0 || Xvalues > 0 && Yvalues == height - 1 || Xvalues == width - 1 && Yvalues >= 0)
                    {
                        mapCharacter[Xvalues, Yvalues] = new Obstacle(Xvalues, Yvalues, Tile.Tiletype.obstacle, 'X');
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
                    if (Xvalues > 0 && Yvalues > 0 || Xvalues < width - 1 && Yvalues < height - 1)
                    {

                        mapCharacter[Xvalues, Yvalues] = new EmptyTile(Xvalues, Yvalues, Tile.Tiletype.empty, '.');
                    }
                }
            }
        }

        public int Enemynum;

        public string attack(string enemy)
        {
            string display = "";
            int i = 0;
            while (i < theEnemies.Length)
            {
                if (theEnemies[i].X == theHero.X - 1 || theEnemies[i].X == theHero.X + 1 || theEnemies[i].Y == theHero.Y - 1 || theHero.Y == theHero.Y + 1 || theEnemies[i].X == theHero.X - 1 && theEnemies[i].Y == theHero.Y - 1 || theEnemies[i].X == theHero.X + 1 && theEnemies[i].Y == theHero.Y - 1 || theEnemies[i].X == theHero.X - 1 && theEnemies[i].Y == theHero.Y + 1 || theEnemies[i].X == theHero.X + 1 && theEnemies[i].Y == theHero.Y + 1)
                {
                    theEnemies[i].HP -= theHero.Damage;
                    if (theEnemies[i].HP <= 0)
                    {
                        display = "----------------------------------------------------------------------------\n You have killed a goblin at [" + theEnemies[i].X + "," + theEnemies[i].Y + "\n" + "----------------------------------------------------------------------------\n";
                        i = theEnemies.Length;
                    }
                    else
                    {
                        display = "----------------------------------------------------------------------------\n You have attacked  the goblin at [" + theHero.X + "," + theHero.Y + "]" + " The goblin takes " + theHero.Damage + " damage and is now at " + theEnemies[i].HP + " HP\n ----------------------------------------------------------------------------\n";
                        i = theEnemies.Length;
                    }
                }
                else
                {
                    display = "----------------------------------------------------------------------------\n The goblin you are trying to attack is to far away \n----------------------------------------------------------------------------\n";
                    i += 1;
                }
            }
                return display;

        }

        public Item GetItemAtPosition(int x, int y)
        {
            bool found = false;
            Item artifact = null;
            for (int i = 0; i < mapItems.Length; i++)
            {
                if (mapItems[i].X == x && mapItems[i].Y == y)
                {
                    artifact = mapItems[i];
                    mapItems[i] = null;
                    found = true;
                }
            }

            if(found == true)
            {
                return artifact;
            }
            else
            {
                return null;
            }
        }
    }
}

