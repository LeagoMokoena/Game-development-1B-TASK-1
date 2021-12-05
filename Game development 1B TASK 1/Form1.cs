using System;
using System.Windows.Forms;
using System.IO;


namespace Game_development_1B_TASK_1
{
    public partial class Form1 : Form
    {
        string Selected;
        public Form1()
        {
            InitializeComponent();


        }

        protected private GameEngine gameArea;

        public GameEngine GameArea
        {
            get { return gameArea; }
            set { gameArea = value; }
        }

        public Random r = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            int goldNumber = r.Next(1, 5);
            int weaponNumber = r.Next(4, 10);
            gameArea = new GameEngine(10, 17, 10, 13, 5, goldNumber,weaponNumber);
            this.Show();
            gameArea = new GameEngine(10, 17, 10, 13, 5,goldNumber,weaponNumber);
            createMap(gameArea);
            playerStats(gameArea);
            selectEnemy(gameArea);
        }

        private void createMap(GameEngine game)
        {
            Mapdisplay.Text = "";
            Mapdisplay.Text = game.ToString();
        }

        private void playerStats(GameEngine game)
        {
            txtPlayerStatus.Text = game.Game.TheHero.ToString();
        }


        private void selectEnemy(GameEngine game)
        {
            btnAttack.Enabled = false;
            foreach (Enemy en in game.Game.TheEnemies)
            {
                if (en.HP <= 0)
                {
                    for (int it = 0; it < game.Game.Width; it++)
                    {
                        for (int ut = 0; ut < game.Game.Height; ut++)
                        {
                            if (game.Game.mapCharacter[it, ut] == en)
                            {
                                game.Game.checkIfDead(game.Game.mapCharacter[it, ut]);
                            }
                            else
                            {
                                game.Game.mapCharacter[it, ut] = game.Game.mapCharacter[it, ut];
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < game.Game.Enemynum; i++)
            {
                if (game.Game.TheEnemies[i].Symbol == 'G')
                {
                    btnSelectEnemy.Items.Add("Equipped: Goblin (" + game.Game.TheEnemies[i].ToString() + "with Dagger" +"\n"+"(" + game.Game.TheEnemies[i].EquipWeapon.Durability * game.Game.TheEnemies[i].Damage + ")");
                }
                else if(game.Game.TheEnemies[i].Symbol == 'M')
                {
                    btnSelectEnemy.Items.Add("Barehanded: Mage " + game.Game.TheEnemies[i].ToString() + "(5)" + "\n");
                }
                else
                {
                    btnSelectEnemy.Items.Add("Equiped: Leader " + game.Game.TheEnemies[i].ToString() + "with Longsword" + "\n" + "(" + game.Game.TheEnemies[i].EquipWeapon.Durability * game.Game.TheEnemies[i].Damage + ")");
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            bool move;
            move = gameArea.MovePlayer(Character.movement.Up);
            if (move == true)
            {
                gameArea.Game.TheHero.Move(Character.movement.Up);
                foreach (Item i in gameArea.Game.MapItems)
                    if (i.X == gameArea.Game.TheHero.X && i.Y == gameArea.Game.TheHero.Y)
                    {
                        gameArea.Game.TheHero.Pickup(i);
                    }
                gameArea.Game.mapCharacter[gameArea.Game.TheHero.X, gameArea.Game.TheHero.Y] = gameArea.Game.TheHero;
                gameArea.MoveEnemies();
                foreach(Enemy ene in gameArea.Game.TheEnemies)
                {
                    if(ene.Symbol == 'G')
                    {
                        gameArea.goblinAttack(ene);
                    }
                    else
                    {
                        gameArea.mageAttack(ene);
                    }
                }
                selectEnemy(gameArea);
                createMap(GameArea);
                playerStats(gameArea);
            }
            gameArea.Game.UpdateVision();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            bool move;
            move = gameArea.MovePlayer(Character.movement.Left);
            if (move == true)
            {
                gameArea.Game.TheHero.Move(Character.movement.Left);
                foreach (Item i in gameArea.Game.MapItems)
                    if (i.X == gameArea.Game.TheHero.X && i.Y == gameArea.Game.TheHero.Y)
                    {
                        gameArea.Game.TheHero.Pickup(i);
                    }
                gameArea.Game.mapCharacter[gameArea.Game.TheHero.X, gameArea.Game.TheHero.Y] = gameArea.Game.TheHero;
                gameArea.MoveEnemies();
                foreach (Enemy ene in gameArea.Game.TheEnemies)
                {
                    if (ene.Symbol == 'G')
                    {
                        gameArea.goblinAttack(ene);
                    }
                    else
                    {
                        gameArea.mageAttack(ene);
                    }
                }
                selectEnemy(gameArea);
                createMap(GameArea);
                playerStats(gameArea);
            }
            gameArea.Game.UpdateVision();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            bool move;
            move = gameArea.MovePlayer(Character.movement.Right);
            if (move == true)
            {
                gameArea.Game.TheHero.Move(Character.movement.Right);
                foreach (Item i in gameArea.Game.MapItems)
                    if (i.X == gameArea.Game.TheHero.X && i.Y == gameArea.Game.TheHero.Y)
                    {
                        gameArea.Game.TheHero.Pickup(i);
                    }
                gameArea.Game.mapCharacter[gameArea.Game.TheHero.X, gameArea.Game.TheHero.Y] = gameArea.Game.TheHero;
                gameArea.MoveEnemies();
                foreach (Enemy ene in gameArea.Game.TheEnemies)
                {
                    if (ene.Symbol == 'G')
                    {
                        gameArea.goblinAttack(ene);
                    }
                    else
                    {
                        gameArea.mageAttack(ene);
                    }
                }
                selectEnemy(gameArea);
                createMap(GameArea);
                playerStats(gameArea);
            }
            gameArea.Game.UpdateVision();

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            bool move;
            move = gameArea.MovePlayer(Character.movement.Down);
            if (move == true)
            {
                gameArea.Game.TheHero.Move(Character.movement.Down);
                foreach (Item i in gameArea.Game.MapItems)
                    if (i.X == gameArea.Game.TheHero.X && i.Y == gameArea.Game.TheHero.Y)
                    {
                        gameArea.Game.TheHero.Pickup(i);
                    }
                gameArea.Game.mapCharacter[gameArea.Game.TheHero.X, gameArea.Game.TheHero.Y] = gameArea.Game.TheHero;
                gameArea.MoveEnemies();
                foreach (Enemy ene in gameArea.Game.TheEnemies)
                {
                    if (ene.Symbol == 'G')
                    {
                        gameArea.goblinAttack(ene);
                    }
                    else
                    {
                        gameArea.mageAttack(ene);
                    }
                }
                selectEnemy(gameArea);
                createMap(GameArea);
                playerStats(gameArea);
            }
            gameArea.Game.UpdateVision();
        }

        private void btnSelectEnemy_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selected = btnSelectEnemy.SelectedIndex;
            Selected = this.Text = btnSelectEnemy.Items[selected].ToString();
            btnAttack.Enabled = true;

        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
                txtAttackStatus.Text += gameArea.heroAttack(btnSelectEnemy.SelectedIndex) + "\n \n";
                enemyStatus.Text = gameArea.Game.TheEnemies[btnSelectEnemy.SelectedIndex].ToString();
            selectEnemy(gameArea);
            createMap(gameArea);
        }

        private void Mapdisplay_Click(object sender, EventArgs e)
        {

        }

        private void txtPlayerStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveMap_Click(object sender, EventArgs e)
        {
            using (StreamWriter sp = new StreamWriter("save map"))
            {
                sp.WriteLine(gameArea.save(10, 17, 10, 13, gameArea.Game.Enemynum, gameArea.Game.Goldnum,gameArea.Game.Weaponnum));
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Mapdisplay.Text = "";
            using (StreamReader sp = new StreamReader("load map"))
            {
                Mapdisplay.Text = gameArea.Load();
            }
        }
    }
}
