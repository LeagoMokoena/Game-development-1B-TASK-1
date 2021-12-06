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

        public int Weaponnum;

        public int Goldnum;

        public int enemyDigit;

        public int weaponDigit;

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

        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int enemyNum, int goldDrops, int weaponDrops)
        {
            newItem = new Random();
            width = newItem.Next(minWidth, maxWidth);
            height = newItem.Next(minHeight, maxHeight);
            mapCharacter = new Tile[width, height];
            theEnemies = new Enemy[enemyNum];
            mapItems = new Item[goldDrops + weaponDrops];
            createEmptyTile();
            creatObstacle();
            Create(Tile.Tiletype.Hero);
            for (int i = 0; i < enemyNum; i++)
            {
                enemyDigit = newItem.Next(0, 3);
                Enemynum = i;
                Create(Tile.Tiletype.Enemy);
            }
            for (int j = 0; j < goldDrops; j++)
            {
                Goldnum = j;
                Create(Tile.Tiletype.Gold);
            }
            Weaponnum = goldDrops;
            for(int k = 0; k < weaponDrops; k++)
            {
                weaponDigit = newItem.Next(0, 4);
                Create(Tile.Tiletype.Weapon);
                Weaponnum++;
            }
            UpdateVision();
        }



        public void UpdateVision()
        {
            foreach(Enemy en in theEnemies)
            {
                Array.Clear(en.Vision, 0, en.Vision.Length);

                if(en.Symbol == 'G')
                {
                    en.Vision[0] = mapCharacter[en.X - 1, en.Y];
                    en.Vision[1] = mapCharacter[en.X, en.Y - 1];
                    en.Vision[2] = mapCharacter[en.X, en.Y + 1];
                    en.Vision[3] = mapCharacter[en.X + 1, en.Y];
                }
                else if(en.Symbol == 'M')
                {
                    en.Vision[0] = mapCharacter[en.X - 1, en.Y];
                    en.Vision[1] = mapCharacter[en.X, en.Y - 1];
                    en.Vision[2] = mapCharacter[en.X, en.Y + 1];
                    en.Vision[3] = mapCharacter[en.X + 1, en.Y];
                    en.Vision[4] = mapCharacter[en.X - 1, en.Y - 1];
                    en.Vision[5] = mapCharacter[en.X + 1, en.Y - 1];
                    en.Vision[6] = mapCharacter[en.X + 1, en.Y + 1];
                    en.Vision[7] = mapCharacter[en.X - 1, en.Y + 1];
                }
                else
                {
                    en.Vision[0] = mapCharacter[en.X - 1, en.Y];
                    en.Vision[1] = mapCharacter[en.X, en.Y - 1];
                    en.Vision[2] = mapCharacter[en.X, en.Y + 1];
                    en.Vision[3] = mapCharacter[en.X + 1, en.Y];
                }
            }
            theHero.Vision[0] = mapCharacter[theHero.X - 1, theHero.Y];
            theHero.Vision[1] = mapCharacter[theHero.X, theHero.Y - 1];
            theHero.Vision[2] = mapCharacter[theHero.X, theHero.Y + 1];
            theHero.Vision[3] = mapCharacter[theHero.X + 1, theHero.Y];
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
                            List<Item> golds = new List<Item>();
                            theHero = new Hero(xpoint, ypoint, Tile.Tiletype.Hero, 'H', 100, 100,2,golds);
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
                            List<Item> gOLDS = new List<Item>();
                            gOLDS.Add(new Gold(1, 1, Tile.Tiletype.Gold, 'A'));
                            Goblin newGoblin = new Goblin(xpoint, ypoint, Tile.Tiletype.Enemy, 'G', 100, 100, 10,gOLDS);
                            theEnemies[Enemynum] = newGoblin;
                            mapCharacter[xpoint, ypoint] = theEnemies[Enemynum];
                            found = true;
                        }
                        else if(enemyDigit == 2)
                        {
                            List<Item> _GOLDS = new List<Item>();
                            for (int I = 0; I < 3; I++)
                            {
                                _GOLDS.Add(new Gold(1, 1, Tile.Tiletype.Gold, 'A'));
                            }
                            Mage newMage = new Mage(xpoint, ypoint, Tile.Tiletype.Enemy, 'M', 5, 5, 5,_GOLDS);
                            theEnemies[Enemynum] = newMage;
                            mapCharacter[xpoint, ypoint] = theEnemies[Enemynum];
                            found = true;
                        }
                        else
                        {
                            List<Item> GOLDS = new List<Item>();
                            for (int I = 0; I < 2; I++)
                            {
                                GOLDS.Add(new Gold(1, 1, Tile.Tiletype.Gold, 'A'));
                            }
                            Leader newLeader = new Leader(xpoint, ypoint, Tile.Tiletype.Enemy, 'L', theHero, 20, 20,2,GOLDS);
                            theEnemies[Enemynum] = newLeader;
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
                            mapItems[Goldnum] = new Gold(xpoint, ypoint, Tile.Tiletype.Gold, 'A');
                            mapCharacter[xpoint, ypoint] = mapItems[Goldnum];
                            found = true;
                        }
                    }
                    break;
                case Tile.Tiletype.Weapon:
                    while (found == false)
                    {
                        if (mapCharacter[xpoint, ypoint].tiletype != Tile.Tiletype.empty)
                        {
                            xpoint = newItem.Next(0, width);
                            ypoint = newItem.Next(0, height);
                        }
                        else if(weaponDigit == 1)
                        {
                            mapItems[Weaponnum] = new MeleeWeapon(xpoint, ypoint, Tile.Tiletype.Weapon, 'D',MeleeWeapon.Types.Dagger);
                            mapCharacter[xpoint, ypoint] = mapItems[Weaponnum];
                            found = true;
                        }
                        else if(weaponDigit == 2)
                        {
                            mapItems[Weaponnum] = new MeleeWeapon(xpoint, ypoint, Tile.Tiletype.Weapon, 'S', MeleeWeapon.Types.Longsword);
                            mapCharacter[xpoint, ypoint] = mapItems[Weaponnum];
                            found = true;
                        }
                        else if(weaponDigit == 3)
                        {
                            mapItems[Weaponnum] = new RangedWeapons(xpoint, ypoint, Tile.Tiletype.Weapon, 'R', RangedWeapons.Types.Rifle);
                            mapCharacter[xpoint, ypoint] = mapItems[Weaponnum];
                            found = true;
                        }
                        else
                        {
                            mapItems[Weaponnum] = new RangedWeapons(xpoint, ypoint, Tile.Tiletype.Weapon, 'B', RangedWeapons.Types.Longbow);
                            mapCharacter[xpoint, ypoint] = mapItems[Weaponnum];
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

        public void checkIfDead(Tile character)
        {
            foreach(Tile ch in mapCharacter)
            {
                if(ch == character)
                {
                    mapCharacter[character.X,character.Y] = new EmptyTile(character.X, character.Y, Tile.Tiletype.empty, '.');
                }
            }
        }
    }
}

