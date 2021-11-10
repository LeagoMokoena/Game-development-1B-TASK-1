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
        private Map game;

        public Map Game
        {
            get { return game; }
            set { game = value; }
        }

        Random ramdomMove = new Random();

        public GameEngine(int minwidth, int maxwidth,int minheight,int maxheight,int enemynumber,int goldAmount)
        {
            game = new Map(minwidth,maxwidth,minheight,maxheight,enemynumber,goldAmount);

        }

        public Character.movement Cmove;

        public bool MovePlayer(Character.movement direction)
        {
            bool move = false;
            if (game.TheHero.Returnmove(direction) == direction)
            {
                game.mapCharacter[game.TheHero.X, game.TheHero.Y] = new EmptyTile(game.TheHero.X, game.TheHero.Y, Tile.Tiletype.empty, '.');
                game.TheHero.Move(direction);
                foreach (Item i in game.MapItems)
                    if (i.X == game.TheHero.X && i.Y == game.TheHero.Y)
                    {
                        game.TheHero.Pickup(i);
                    }
                game.mapCharacter[game.TheHero.X, game.TheHero.Y] = game.TheHero;
            }
            else
            {
                move = false;
            }
            game.UpdateVision();
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

            if (range)
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

                        }
                        game.mapCharacter[game.TheEnemies[i].X, game.TheEnemies[i].Y] = game.TheEnemies[i];
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
            }
        }

        public void enemyAttack(int attackDamage)
        {
            foreach(Enemy en in game.TheEnemies)
            {
                if (en.Symbol == 'G')
                {
                    if(en.Vision[1].tiletype == Tile.Tiletype.Hero)
                    {
                        game.TheHero.HP -= attackDamage;
                    }
                    else if(en.Vision[3].tiletype == Tile.Tiletype.Hero)
                    {
                        game.TheHero.HP -= attackDamage;
                    }
                    else if(en.Vision[4].tiletype == Tile.Tiletype.Hero)
                    {
                        game.TheHero.HP -= attackDamage;
                    }
                    else if(en.Vision[6].tiletype == Tile.Tiletype.Hero)
                    {
                        game.TheHero.HP -= attackDamage;
                    }
                }
                else
                {
                    foreach (Tile tile in en.Vision)
                    {
                        if (tile.tiletype == Tile.Tiletype.Hero)
                        {
                            game.TheHero.HP -= attackDamage;
                        }
                    }

                    if (en.Vision[0].tiletype == Tile.Tiletype.Enemy)
                    {
                        foreach (Enemy e in game.TheEnemies)
                        {
                            if (e.X == en.Vision[0].X && e.Y == en.Vision[0].Y)
                            {
                                e.HP -= attackDamage;
                            }
                        }
                    }
                    if (en.Vision[1].tiletype == Tile.Tiletype.Enemy)
                    {
                        foreach (Enemy e in game.TheEnemies)
                        {
                            if (e.X == en.Vision[1].X && e.Y == en.Vision[1].Y)
                            {
                                e.HP -= attackDamage;
                            }
                        }
                    }
                    if (en.Vision[2].tiletype == Tile.Tiletype.Enemy)
                    {
                        foreach (Enemy e in game.TheEnemies)
                        {
                            if (e.X == en.Vision[2].X && e.Y == en.Vision[2].Y)
                            {
                                e.HP -= attackDamage;
                            }
                        }
                    }
                    
                    if(en.Vision[3].tiletype == Tile.Tiletype.Enemy)
                    {
                        foreach (Enemy e in game.TheEnemies)
                        {
                            if (e.X == en.Vision[3].X && e.Y == en.Vision[3].Y)
                            {
                                e.HP -= attackDamage;
                            }
                        }
                    }
                    
                    if(en.Vision[4].tiletype == Tile.Tiletype.Enemy)
                    {
                        foreach (Enemy e in game.TheEnemies)
                        {
                            if (e.X == en.Vision[4].X && e.Y == en.Vision[4].Y)
                            {
                                e.HP -= attackDamage;
                            }
                        }
                    }
                    
                    if(en.Vision[5].tiletype == Tile.Tiletype.Enemy)
                    {
                        foreach (Enemy e in game.TheEnemies)
                        {
                            if (e.X == en.Vision[5].X && e.Y == en.Vision[5].Y)
                            {
                                e.HP -= attackDamage;
                            }
                        }
                    }
                    
                    if(en.Vision[6].tiletype == Tile.Tiletype.Enemy)
                    {
                        foreach (Enemy e in game.TheEnemies)
                        {
                            if (e.X == en.Vision[6].X && e.Y == en.Vision[6].Y)
                            {
                                e.HP -= attackDamage;
                            }
                        }
                    }
                    
                    if(en.Vision[7].tiletype == Tile.Tiletype.Enemy)
                    {
                        foreach (Enemy e in game.TheEnemies)
                        {
                            if (e.X == en.Vision[1].X && e.Y == en.Vision[1].Y)
                            {
                                e.HP -= attackDamage;
                            }
                        }
                    }
                }
            }
        }

        /*public bool checkSurroundings(Character.movement movements, Hero theCharacter)
        {
            bool playerMove = false;
            if (movements == Character.movement.Up)
            {
                if(game.mapCharacter[theCharacter.X - 1, theCharacter.Y].tiletype == Tile.Tiletype.obstacle)
                {
                    playerMove = false;
                }
                else
                {
                    playerMove = true;
                }
            }
            else if(movements == Character.movement.Down)
            {
                if (game.mapCharacter[theCharacter.X + 1, theCharacter.Y].tiletype == Tile.Tiletype.obstacle)
                {
                    playerMove = false;
                }
                else
                {
                    playerMove = true;
                }
            }
            else if(movements == Character.movement.Left)
            {
                if (game.mapCharacter[theCharacter.X, theCharacter.Y - 1].tiletype == Tile.Tiletype.obstacle)
                {
                    playerMove = false;
                }
                else
                {
                    playerMove = true;
                }
            }
            else
            {
                if (game.mapCharacter[theCharacter.X, theCharacter.Y + 1].tiletype == Tile.Tiletype.obstacle)
                {
                    playerMove = false;
                }
                else
                {
                    playerMove = true;
                }
            }
            return playerMove;
        }*/

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
    }
}
