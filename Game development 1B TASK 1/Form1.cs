using System;
using System.Windows.Forms;

namespace Game_development_1B_TASK_1
{
    public partial class Form1 : Form
    {

        GameEngine game = new GameEngine(6,17,5,13,5);
       
        string Selected;
        public Form1()
        {
            InitializeComponent();
            createMap();
            playerStats();
            selectEnemy();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createMap();
            playerStats();
            selectEnemy();
        }

        private void createMap()
        {

            Mapdisplay.Text = "";
            Mapdisplay.Text = game.ToString();
        }

        private void playerStats()
        {
            txtPlayerStatus.Text = game.Game.TheHero.ToString();
        }


        private void selectEnemy()
        {
            btnAttack.Enabled = false;
            for (int i = 0; i < game.Game.TheEnemies.Length; i++)
            {
                btnSelectEnemy.Items.Add(game.Game.TheEnemies[i].ToString() + "\n");
            }
        }

        private bool attack(string selected)
        {
            int up = game.Game.TheHero.X - 1;
            int down = game.Game.TheHero.X + 1;
            int left = game.Game.TheHero.Y - 1;
            int right = game.Game.TheHero.Y + 1;
            bool dead = false;
            foreach (Enemy e in game.Game.TheEnemies)
            {
                if (selected == e.ToString())
                {
                    if ((e.X == up || e.X == down || e.Y == left || e.Y == right) || (e.X == up && e.Y == left || e.X == up && e.Y == right || e.X == down && e.Y == left || e.X == down && e.Y == right))
                    {
                        e.HP -= game.Game.TheHero.Damage;
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
                            txtAttackStatus.Text += "You have attacked  the goblin at [" + e.X + "," + e.Y + "]" + " The goblin takes " + game.Game.TheHero.Damage + " damage and is now at " + e.HP + " HP\n";
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
            Hero.movement move = Character.movement.Up;
            Hero.movement direction;
            direction = game.Game.TheHero.Returnmove(move);
            game.Game.TheHero.Move(direction);
            game.MovePlayer(direction);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            Hero.movement move = Character.movement.Left;
            Hero.movement direction;
            direction = game.Game.TheHero.Returnmove(move);
            game.Game.TheHero.Move(direction);
            game.MovePlayer(direction);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            Hero.movement move = Character.movement.Right;
            Hero.movement direction;
            direction = game.Game.TheHero.Returnmove(move);
            game.Game.TheHero.Move(direction);
            game.MovePlayer(direction);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Hero.movement move = Character.movement.Down;
            Hero.movement direction;
            direction = game.Game.TheHero.Returnmove(move);
            game.Game.TheHero.Move(direction);
            game.MovePlayer(direction);
        }

        private void btnSelectEnemy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = btnSelectEnemy.SelectedIndex;
            Selected = this.Text = btnSelectEnemy.Items[selected].ToString();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            bool enemyDead;
            enemyDead=attack(Selected);
            if(enemyDead == true)
            {
                foreach(Enemy en in game.Game.TheEnemies)
                    if(en.HP <= 0)
                    {
                        game.Game.mapCharacter[en.X, en.Y] = game.Game.Empty_Tile;
                        btnSelectEnemy.Items.Remove(btnSelectEnemy.Text);
                    }
            }
            else
            {
                btnSelectEnemy.Text = "";
            }
        }
    }
}
