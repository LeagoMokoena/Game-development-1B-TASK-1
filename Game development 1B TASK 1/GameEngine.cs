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
            store = new Shop(game.TheHero);
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

        public void MoveEnemies(Enemy attaker)
        {
            bool enemyMovement = false;
            int num;
            num = ramdomMove.Next(1, 4);
            if (attaker.Symbol == 'G')
            {
                if (num == 1)
                {
                    enemyMovement = enemyMove(Character.movement.Up,attaker);
                    if (enemyMovement == true)
                    {
                        attaker.Returnmove(Character.movement.Up);
                        game.mapCharacter[attaker.X, attaker.Y] = new EmptyTile(attaker.X, attaker.Y, Tile.Tiletype.empty, '.');
                        attaker.Move(Character.movement.Up);
                        game.mapCharacter[attaker.X, attaker.Y] = attaker;
                    }
                    else
                    {
                        attaker.Returnmove(Character.movement.noMovement);
                        game.mapCharacter[attaker.X, attaker.Y] = new EmptyTile(attaker.X, attaker.Y, Tile.Tiletype.empty, '.');
                        attaker.Move(Character.movement.noMovement);
                        game.mapCharacter[attaker.X, attaker.Y] = attaker;
                    }
                }
                else if (num == 2)
                {
                    enemyMovement = enemyMove(Character.movement.Down, attaker);
                    if (enemyMovement == true)
                    {
                        attaker.Returnmove(Character.movement.Down);
                        game.mapCharacter[attaker.X, attaker.Y] = new EmptyTile(attaker.X, attaker.Y, Tile.Tiletype.empty, '.');
                        attaker.Move(Character.movement.Down);
                        game.mapCharacter[attaker.X, attaker.Y] = attaker;
                    }
                    else
                    {
                        attaker.Returnmove(Character.movement.noMovement);
                        game.mapCharacter[attaker.X, attaker.Y] = new EmptyTile(attaker.X, attaker.Y, Tile.Tiletype.empty, '.');
                        attaker.Move(Character.movement.noMovement);
                        game.mapCharacter[attaker.X, attaker.Y] = attaker;
                    }
                }
                else if (num == 3)
                {
                    enemyMovement = enemyMove(Character.movement.Left, attaker);
                    if (enemyMovement == true)
                    {
                        attaker.Returnmove(Character.movement.Left);
                        game.mapCharacter[attaker.X, attaker.Y] = new EmptyTile(attaker.X, attaker.Y, Tile.Tiletype.empty, '.');
                        attaker.Move(Character.movement.Left);
                        game.mapCharacter[attaker.X, attaker.Y] = attaker;
                    }
                    else
                    {
                        attaker.Returnmove(Character.movement.noMovement);
                        game.mapCharacter[attaker.X, attaker.Y] = new EmptyTile(attaker.X, attaker.Y, Tile.Tiletype.empty, '.');
                        attaker.Move(Character.movement.noMovement);
                        game.mapCharacter[attaker.X, attaker.Y] = attaker;
                    }
                }
                else
                {
                    enemyMovement = enemyMove(Character.movement.Right, attaker);
                    if (enemyMovement == true)
                    {

                        attaker.Returnmove(Character.movement.Up);
                        game.mapCharacter[attaker.X, attaker.Y] = new EmptyTile(attaker.X, attaker.Y, Tile.Tiletype.empty, '.');
                        attaker.Move(Character.movement.Up);
                        game.mapCharacter[attaker.X, attaker.Y] = attaker;
                    }
                    else
                    {
                        attaker.Returnmove(Character.movement.noMovement);
                        game.mapCharacter[attaker.X, attaker.Y] = new EmptyTile(attaker.X, attaker.Y, Tile.Tiletype.empty, '.');
                        attaker.Move(Character.movement.noMovement);
                        game.mapCharacter[attaker.X, attaker.Y] = attaker;
                    }

                }
            }

            if(attaker.Symbol == 'L')
            {
                game.mapCharacter[attaker.X, attaker.Y] = new EmptyTile(attaker.X, attaker.Y, Tile.Tiletype.empty, '.');
                attaker.Move(attaker.Returnmove(Character.movement.noMovement));
                game.mapCharacter[attaker.X, attaker.Y] = attaker;
            }

            foreach (Item j in Game.MapItems)
                if (j.X == attaker.X && j.Y == attaker.Y)
                {
                    attaker.Pickup(j);
                }
            game.mapCharacter[attaker.X, attaker.Y] = attaker;
        }

        public void goblinAttack(Enemy goblin)
        {
            for (int i = 0; i < goblin.Vision.Length; ++i)
            {
                if (goblin.Vision[i] == game.TheHero)
                {
                    game.TheHero.HP = game.TheHero.HP - goblin.EquipWeapon.Damage;
                }
            }
                
        }
        public void leaderAttack(Enemy leader)
        {
            for (int i = 0; i < leader.Vision.Length; ++i)
            {
                if (leader.Vision[i] == game.TheHero)
                {
                    game.TheHero.HP = game.TheHero.HP - leader.EquipWeapon.Damage;
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
