using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_development_1B_TASK_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Hero.movement move = Character.movement.Up;
            Hero.movement direction;
            Hero h = new Hero();
            direction = h.Returnmove(move);
            h.Move(direction);
            GameEngine g = new GameEngine();
            g.MovePlayer(direction);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            Hero.movement move = Character.movement.Left;
            Hero.movement direction;
            Hero h = new Hero();
            direction = h.Returnmove(move);
            h.Move(direction);
            GameEngine g = new GameEngine();
            g.MovePlayer(direction);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            Hero.movement move = Character.movement.Right;
            Hero.movement direction;
            Hero h = new Hero();
            direction = h.Returnmove(move);
            h.Move(direction);
            GameEngine g = new GameEngine();
            g.MovePlayer(direction);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Hero.movement move = Character.movement.Down;
            Hero.movement direction;
            Hero h = new Hero();
            GameEngine g = new GameEngine();
            direction = h.Returnmove(move);
            h.Move(direction);
            g.MovePlayer(direction);
        }
    }
}
