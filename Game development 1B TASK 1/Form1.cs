using System;
using System.Windows.Forms;
using System.IO;


namespace Game_development_1B_TASK_1
{
    public partial class Form1 : Form
    {
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
            int goldNumber = r.Next(10, 15);
            int weaponNumber = r.Next(4, 10);
            gameArea = new GameEngine(15, 20, 15, 20, 5, goldNumber,weaponNumber);
            this.Show();
            gameArea = new GameEngine(15, 20, 15, 20, 5,goldNumber,weaponNumber);
            createMap(gameArea);
            playerStats(gameArea);
            selectEnemy();
            stockShop();
        }

        private void createMap(GameEngine game)
        {
            Mapdisplay.Text = "";
            Mapdisplay.Text = game.ToString();
        }

        public void stockShop()
        {
            btnWeapon1.Text = gameArea.Store.defences[0].WeaponType;
            btnWeapon2.Text = gameArea.Store.defences[1].WeaponType;
            btnWeapon3.Text = gameArea.Store.defences[2].WeaponType;
            btnWeapon1.Enabled = gameArea.Store.CanBuy(0);
            btnWeapon2.Enabled = gameArea.Store.CanBuy(1);
            btnWeapon3.Enabled = gameArea.Store.CanBuy(2);
        }

        public void restockShop(int x)
        {
            if(x == 0)
            {
                btnWeapon1.Text = gameArea.Store.defences[0].WeaponType;
                btnWeapon1.Enabled = gameArea.Store.CanBuy(0);
            }
            else if(x == 1)
            {
                btnWeapon2.Text = gameArea.Store.defences[1].WeaponType;
                btnWeapon2.Enabled = gameArea.Store.CanBuy(1);
            }
            else
            {
                btnWeapon3.Text = gameArea.Store.defences[2].WeaponType;
                btnWeapon3.Enabled = gameArea.Store.CanBuy(2);
            }
        }

        private void playerStats(GameEngine game)
        {
            txtPlayerStatus.Text = game.Game.TheHero.ToString();
        }


        private void selectEnemy()
        {
            btnAttack.Enabled = false;
            btnSelectEnemy.Items.Clear();
            foreach (Enemy en in gameArea.Game.TheEnemies)
            {
                if (en.HP > 0)
                {
                    if (en.Symbol == 'G')
                    {
                        btnSelectEnemy.Items.Add("Equipped: Goblin (" + en.ToString() + "with " + en.EquipWeapon.WeaponType + "\n" + "(" + en.EquipWeapon.Durability * en.Damage + ")");
                    }
                    else if (en.Symbol == 'M')
                    {
                        btnSelectEnemy.Items.Add("Barehanded: Mage " + en.ToString() + "(5)" + "\n");
                    }
                    else
                    {
                        btnSelectEnemy.Items.Add("Equiped: Leader " + en.ToString() + "with "+ en.EquipWeapon.WeaponType + "\n" + "(" + en.EquipWeapon.Durability * en.Damage + ")");
                    }
                }
            }
        }

        public void deadEnemies()
        {
            foreach (Enemy en in gameArea.Game.TheEnemies)
            {
                if (en.HP <= 0)
                {
                    for (int it = 0; it < gameArea.Game.Width; it++)
                    {
                        for (int ut = 0; ut < gameArea.Game.Height; ut++)
                        {
                            if (gameArea.Game.mapCharacter[it, ut] == en)
                            {
                                gameArea.Game.checkIfDead(gameArea.Game.mapCharacter[it, ut]);
                            }
                        }
                    }
                }

                selectEnemy();
            }

        }


        public void checkAffordability()
        {
            if(gameArea.Game.TheHero.GoldPurse.Count == gameArea.Store.defences[0].Cost)
            {
                btnWeapon1.Enabled = true;
            }

            if (gameArea.Game.TheHero.GoldPurse.Count == gameArea.Store.defences[1].Cost)
            {
                btnWeapon1.Enabled = true;
            }

            if (gameArea.Game.TheHero.GoldPurse.Count == gameArea.Store.defences[2].Cost)
            {
                btnWeapon1.Enabled = true;
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
                foreach(Enemy ene in gameArea.Game.TheEnemies)
                {
                    if (ene.Symbol != 'M')
                    {
                        gameArea.MoveEnemies(ene);
                        gameArea.goblinAttack(ene);
                        gameArea.leaderAttack(ene);
                    }
                    else
                    {
                        gameArea.mageAttack(ene);
                    }
                }
                deadEnemies();
                createMap(GameArea);
                playerStats(gameArea);
            }
            gameArea.Game.UpdateVision();
            checkAffordability();
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
                foreach (Enemy ene in gameArea.Game.TheEnemies)
                {
                    if (ene.Symbol != 'M')
                    {
                        gameArea.MoveEnemies(ene);
                        gameArea.goblinAttack(ene);
                        gameArea.leaderAttack(ene);
                    }
                    else
                    {
                        gameArea.mageAttack(ene);
                    }
                }
                deadEnemies();
                createMap(GameArea);
                playerStats(gameArea);
            }
            gameArea.Game.UpdateVision();
            checkAffordability();
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
                foreach (Enemy ene in gameArea.Game.TheEnemies)
                {
                    if (ene.Symbol != 'M')
                    {
                        gameArea.MoveEnemies(ene);
                        gameArea.goblinAttack(ene);
                        gameArea.leaderAttack(ene);
                    }
                    else
                    {
                        gameArea.mageAttack(ene);
                    }
                }
                deadEnemies();
                createMap(GameArea);
                playerStats(gameArea);
            }
            gameArea.Game.UpdateVision();
            checkAffordability();
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
                foreach (Enemy ene in gameArea.Game.TheEnemies)
                {
                    if (ene.Symbol != 'M')
                    {
                        gameArea.MoveEnemies(ene);
                        gameArea.goblinAttack(ene);
                        gameArea.leaderAttack(ene);
                    }
                    else
                    {
                        gameArea.mageAttack(ene);
                    }
                }
                deadEnemies();
                createMap(GameArea);
                playerStats(gameArea);
            }
            gameArea.Game.UpdateVision();
            checkAffordability();
        }

        private string Kill(Character kill,Character victor)
        {
            string reward;
            victor.Loot(kill);
            if(victor.tiletype == Tile.Tiletype.Hero)
            {
                if (kill.Symbol != 'M') 
                { 
                    reward = "You looted a " + kill.EquipWeapon.WeaponType + " from " + kill.Symbol + " at[" + kill.X + "," + kill.Y + "]" + "\n"
                       + "You also scored " + kill.GoldPurse.Count + " of gold";
                }
                else
                {
                    reward = "You looted " + kill.GoldPurse.Count + " of gold";
                }
            }
            else
            {
                if (kill.Symbol != 'M')
                {
                    reward = victor.Symbol + " looted a " + kill.EquipWeapon.WeaponType + " from " + kill.Symbol + " at[" + kill.X + "," + kill.Y + "]" + "\n"
 + victor.Symbol + " also scored " + kill.GoldPurse.Count + " of gold";
                }
                else
                {
                    reward = "You looted " + kill.GoldPurse.Count + " of its gold";
                }
            }

            return reward;
        }

        private void btnSelectEnemy_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelectEnemy.Text = gameArea.Game.TheEnemies[btnSelectEnemy.SelectedIndex].ToString();
            btnAttack.Enabled = true;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            txtAttackStatus.Text += gameArea.heroAttack(btnSelectEnemy.SelectedIndex) + "\n \n";
            enemyStatus.Text = gameArea.Game.TheEnemies[btnSelectEnemy.SelectedIndex].ToString();
            if (gameArea.Game.TheEnemies[btnSelectEnemy.SelectedIndex].HP <= 0)
            {
                enemyStatus.Text = Kill(gameArea.Game.TheEnemies[btnSelectEnemy.SelectedIndex],gameArea.Game.TheHero);
            }
            deadEnemies();
            createMap(gameArea);
            playerStats(gameArea);
            gameArea.Game.UpdateVision();
        }

        private void Mapdisplay_Click(object sender, EventArgs e)
        {

        }

        private void txtPlayerStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveMap_Click(object sender, EventArgs e)
        {
            StreamWriter wt = new StreamWriter(@"C:\Users\leago\OneDrive\Documents\Save-Game-Map-GADE1B");
            wt.Write(Mapdisplay.Text);
            wt.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Stream ld;
            OpenFileDialog di = new OpenFileDialog();
            if (di.ShowDialog() == DialogResult.OK)
            {
                if ((ld = di.OpenFile()) != null)
                {
                    string map = di.FileName;
                    string tr = File.ReadAllText(map);
                    Mapdisplay.Text = tr;
                }
            }
        }

        private void btnWeapon1_Click(object sender, EventArgs e)
        {
            txBoughtItem.Text = gameArea.Store.DisplayWeapon(0);
            gameArea.Store.Buy(0);
            playerStats(gameArea);
            restockShop(0);
        }

        private void btnWeapon2_Click(object sender, EventArgs e)
        {
            txBoughtItem.Text = gameArea.Store.DisplayWeapon(1);
            gameArea.Store.Buy(1);
            playerStats(gameArea);
            restockShop(1);
        }

        private void btnWeapon3_Click(object sender, EventArgs e)
        {
            txBoughtItem.Text = gameArea.Store.DisplayWeapon(2);
            gameArea.Store.Buy(2);
            playerStats(gameArea);
            restockShop(2);
        }
    }
}
