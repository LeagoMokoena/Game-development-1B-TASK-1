using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;

namespace Game_development_1B_TASK_1
{
    public class GameEngine
    {

        private Shop store;

        public Shop Store
        {
            get { return store; }
            set { store = value; }
        }


        private Map game;

        public Map Game
        {
            get { return game; }
            set { game = value; }
        }

        private Map gameMap;

        public Map GameMap
        {
            get { return gameMap; }
            set { gameMap = value; }
        }

        Random ramdomMove = new Random();

        public GameEngine(int minwidth, int maxwidth,int minheight,int maxheight,int enemynumber,int goldAmount,int weaponAmount)
        {
            game = new Map(minwidth, maxwidth, minheight, maxheight, enemynumber, goldAmount, weaponAmount);

        }

        public Character.movement Cmove;

        public bool MovePlayer(Character.movement direction)
        {
            bool move = false;
            if (game.TheHero.Returnmove(direction) == direction)
            {
                move = true;
                game.mapCharacter[game.TheHero.X, game.TheHero.Y] = new EmptyTile(game.TheHero.X, game.TheHero.Y, Tile.Tiletype.empty, '.');
                
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

        public string heroAttack(int index)
        {
            bool range = false;

            foreach(Tile tile in game.TheHero.Vision)
            {
                if(tile.X == game.TheEnemies[index].X && (tile.Y == game.TheEnemies[index].Y))
                {
                    range = true;
                    break;
                }
            }

            if (range == true)
            {
                game.TheHero.Attack(game.TheEnemies[index]);
                return "You have attacked a " + game.TheEnemies[index] + "by hitting it with " + game.TheHero.Damage.ToString() + "damage and" +
                    " leaving it with " + game.TheEnemies[index].HP.ToString() + "HP";
            }
            else
            {
                return "there is no enemy in the range ";
            }
        }

        public void MoveEnemies()
        {
            bool enemyMovement = false;
            int num;
            Character.movement mve;
            for(int i = 0; i < game.TheEnemies.Length; i++)
            {
                num = ramdomMove.Next(1, 4);
                if (game.TheEnemies[i].Symbol == 'G')
                {
                    if (num == 1)
                    {
                        enemyMovement = enemyMove(Character.movement.Up,game.TheEnemies[i]);
                        if (enemyMovement == true)
                        {
                            game.TheEnemies[i].Returnmove(Character.movement.Up);
                            game.mapCharacter[game.TheEnemies[i].X, game.TheEnemies[i].Y] = new EmptyTile(game.TheEnemies[i].X, game.TheEnemies[i].Y, Tile.Tiletype.empty, '.');
                            game.TheEnemies[i].Move(Character.movement.Up);
                            game.mapCharacter[game.TheEnemies[i].X, game.TheEnemies[i].Y] = game.TheEnemies[i];
                        }
                    }
                    else if (num == 2)
                    {
                        enemyMovement = enemyMove(Character.movement.Down, game.TheEnemies[i]);
                        if (enemyMovement == true)
                        {
                            game.TheEnemies[i].Returnmove(Character.movement.Down);
                            game.mapCharacter[game.TheEnemies[i].X, game.TheEnemies[i].Y] = new EmptyTile(game.TheEnemies[i].X, game.TheEnemies[i].Y, Tile.Tiletype.empty, '.');
                            game.TheEnemies[i].Move(Character.movement.Down);
                            game.mapCharacter[game.TheEnemies[i].X, game.TheEnemies[i].Y] = game.TheEnemies[i];
                        }
                    }
                    else if (num == 3)
                    {
                        enemyMovement = enemyMove(Character.movement.Left, game.TheEnemies[i]);
                        if (enemyMovement == true)
                        {
                            game.TheEnemies[i].Returnmove(Character.movement.Left);
                            game.mapCharacter[game.TheEnemies[i].X, game.TheEnemies[i].Y] = new EmptyTile(game.TheEnemies[i].X, game.TheEnemies[i].Y, Tile.Tiletype.empty, '.');
                            game.TheEnemies[i].Move(Character.movement.Left);
                            game.mapCharacter[game.TheEnemies[i].X, game.TheEnemies[i].Y] = game.TheEnemies[i];
                        }
                    }
                    else
                    {
                        enemyMovement = enemyMove(Character.movement.Right, game.TheEnemies[i]);
                        if (enemyMovement == true)
                        {
                            game.TheEnemies[i].Returnmove(Character.movement.Right);
                            game.mapCharacter[game.TheEnemies[i].X, game.TheEnemies[i].Y] = new EmptyTile(game.TheEnemies[i].X, game.TheEnemies[i].Y, Tile.Tiletype.empty, '.');
                            game.TheEnemies[i].Move(Character.movement.Right);
                            game.mapCharacter[game.TheEnemies[i].X, game.TheEnemies[i].Y] = game.TheEnemies[i];
                        }
                    }
                }
                else
                {
                    mve = game.TheEnemies[i].Returnmove(Character.movement.noMovement);
                    game.mapCharacter[game.TheEnemies[i].X, game.TheEnemies[i].Y] = new EmptyTile(game.TheEnemies[i].X, game.TheEnemies[i].Y, Tile.Tiletype.empty, '.');
                    game.TheEnemies[i].Move(mve);
                    game.mapCharacter[game.TheEnemies[i].X, game.TheEnemies[i].Y] = game.TheEnemies[i];
                }

                foreach (Item j in Game.MapItems)
                    if (j.X == Game.TheHero.X && j.Y == Game.TheHero.Y)
                    {
                        Game.TheEnemies[i].Pickup(j);
                    }
                game.mapCharacter[Game.TheEnemies[i].X, Game.TheEnemies[i].Y] = Game.TheEnemies[i];
            }
        }

        public void goblinAttack(Enemy goblin)
        {
            for (int i = 0; i < goblin.Vision.Length; ++i)
            {
                if (goblin.Vision[i] == game.TheHero)
                {
                    game.TheHero.HP = game.TheHero.HP - goblin.Damage;
                }
            }
                
        }

        public void mageAttack(Enemy mage)
        {
            foreach(Enemy e in game.TheEnemies)
            {
                for(int nu = 0; nu < mage.Vision.Length; nu++)
                {
                    if(mage.Vision[nu] == e)
                    {
                        e.HP = e.HP - mage.Damage;
                    }
                }
            }

            for(int i = 0; i < mage.Vision.Length; i++)
            {
                if(mage.Vision[i] == game.TheHero)
                {
                    game.TheHero.HP -= 5;
                }
            }
        }
        public bool enemyMove(Character.movement movements, Enemy theEnemy)
        {
            bool enemymove = false;
            if (movements == Character.movement.Up)
            {
                if (game.mapCharacter[theEnemy.X - 1, theEnemy.Y].tiletype == Tile.Tiletype.obstacle)
                {
                    enemymove = false;
                }
                else
                {
                    enemymove = true;
                }
            }
            else if (movements == Character.movement.Down)
            {
                if (game.mapCharacter[theEnemy.X + 1, theEnemy.Y].tiletype == Tile.Tiletype.obstacle)
                {
                    enemymove = false;
                }
                else
                {
                    enemymove = true;
                }
            }
            else if (movements == Character.movement.Left)
            {
                if (game.mapCharacter[theEnemy.X, theEnemy.Y - 1].tiletype == Tile.Tiletype.obstacle)
                {
                    enemymove = false;
                }
                else
                {
                    enemymove = true;
                }
            }
            else
            {
                if (game.mapCharacter[theEnemy.X, theEnemy.Y + 1].tiletype == Tile.Tiletype.obstacle)
                {
                    enemymove = false;
                }
                else
                {
                    enemymove = true;
                }
            }
            return enemymove;
        }

        public string save(int minwidth, int maxwidth, int minheight, int maxheight, int enemynumber, int goldAmount,int weaponAmount)
        {
            gameMap = new Map(minwidth, maxwidth, minheight, maxheight, enemynumber, goldAmount,weaponAmount);
            return Convert.ToString(gameMap);
        }

        public string Load()
        {
            return Convert.ToString(gameMap);
        }
    }
}
