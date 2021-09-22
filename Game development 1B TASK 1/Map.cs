using System;
using System.Collections.Generic;
using System.Text;

namespace Game_development_1B_TASK_1
{
    class Map
    {
        private Tile [,]mapCharacter;

        public Tile [,] MapCharacter
        {
            get { return mapCharacter; }
            set { mapCharacter = value; }
        }

        private Hero theHero;

        public Hero TheHero
        {
            get { return theHero; }
            set { theHero = value; }
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
            width = newItem.Next(minWidth, maxWidth);
            height = newItem.Next(minHeight, maxHeight);
            mapCharacter = new Tile[width, height];
            theEnemies = new Enemy[enemyNum];
            Create(Tile.Tiletype.Hero);
            for(int i = 0; i < enemyNum; i++)
            {
                Create(Tile.Tiletype.Enemy);
            }
            UpdateVision();
        }

        public void UpdateVision()
        {
            foreach(Tile s in theHero.Vision)
                if(theHero.X -1 == )
        }

        private Tile Create(Tile.Tiletype tiletype)
        {
            Enemy newEnemy;
            Character Gold;
            Character MeleeWeapon;
            switch (tiletype)
            {
                case Tile.Tiletype.Hero:
                    theHero.X = newItem.Next(0, width);
                    theHero.Y = newItem.Next(0, height);
                    break;
                case Tile.Tiletype.Enemy:
                    newEnemy.X = newItem.Next(0, width);
                    newEnemy.Y = newItem.Next(0, height);
                    break;
                case Tile.Tiletype.Gold:
                    Gold.X = newItem.Next(0, width);
                    Gold.Y = newItem.Next(0, height);
                    break;
                case Tile.Tiletype.Weapon:
                    MeleeWeapon.X = newItem.Next(0, width);
                    MeleeWeapon.Y = newItem.Next(0, height);
                    break;

            }
        }


    }
}
