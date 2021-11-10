using System;
using System.Windows.Forms;


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
            int goldNumber = r.Next(0, 5);
            gameArea = new GameEngine(10, 17, 10, 13, 5, goldNumber);

            foreach (Enemy g in gameArea.Game.TheEnemies)
            {
                btnSelectEnemy.Items.Add(g.ToString());
            }

            btnSelectEnemy.SelectedIndex = 0;
            enemyStatus.Text = gameArea.Game.TheEnemies[btnSelectEnemy.SelectedIndex].ToString();
            this.Show();
            gameArea = new GameEngine(10, 17, 10, 13, 5,goldNumber);
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
            for (int i = 0; i < game.Game.Enemynum; i++)
            {
                btnSelectEnemy.Items.Add(game.Game.TheEnemies[i].ToString() + "\n");
            }
        }

        private bool attack(string selected)
        {
            int up = gameArea.Game.TheHero.X - 1;
            int down = gameArea.Game.TheHero.X + 1;
            int left = gameArea.Game.TheHero.Y - 1;
            int right = gameArea.Game.TheHero.Y + 1;
            bool dead = false;
            foreach (Enemy e in gameArea.Game.TheEnemies)
            {
                if (selected == e.ToString())
                {
                    if ((e.X == up || e.X == down || e.Y == left || e.Y == right) || (e.X == up && e.Y == left || e.X == up && e.Y == right || e.X == down && e.Y == left || e.X == down && e.Y == right))
                    {
                        e.HP -= gameArea.Game.TheHero.Damage;
                        if (e.HP <= 0)
                        {
                            txtAttackStatus.Text += "----------------------------------------------------------------------------\n";
                            txtAttackStatus.Text += "You have killed a goblin at [" + e.X + "," + e.Y + "]";
                            txtAttackStatus.Text += "----------------------------------------------------------------------------\n";
                            dead = true;
                        }
                        else
                        {
                            txtAttackStatus.Text += "----------------------------------------------------------------------------\n";
                            txtAttackStatus.Text += "You have attacked  the goblin at [" + e.X + "," + e.Y + "]" + " The goblin takes " + gameArea.Game.TheHero.Damage + " damage and is now at " + e.HP + " HP\n";
                            txtAttackStatus.Text += "----------------------------------------------------------------------------\n";
                            
                        }
                    }
                    else
                    {
                        txtAttackStatus.Text += "----------------------------------------------------------------------------\n";
                        txtAttackStatus.Text += "The goblin you are trying to attack is to far away";
                        txtAttackStatus.Text += "----------------------------------------------------------------------------\n";
                    }
                }
            }

            return dead;


        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            gameArea.MovePlayer(Character.movement.Up);
            gameArea.MoveEnemies();
            createMap(GameArea);
            playerStats(gameArea);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            gameArea.MovePlayer(Character.movement.Left);
            gameArea.MoveEnemies();
            createMap(GameArea);
            playerStats(gameArea);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            gameArea.MovePlayer(Character.movement.Right);
            gameArea.MoveEnemies();
            createMap(GameArea);
            playerStats(gameArea);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            gameArea.MovePlayer(Character.movement.Down);
            gameArea.MoveEnemies();
            createMap(GameArea);
            playerStats(gameArea);
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
        }

        private void Mapdisplay_Click(object sender, EventArgs e)
        {

        }

        private void txtPlayerStatus_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
