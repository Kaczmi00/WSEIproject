using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolkoIkrzyzyk
{
    public partial class Form1 : Form
    {

        bool turn = true; // true= X turn, false= O turn.
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nowaGraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            turn = !turn;
            b.Enabled = false;

            checkForWinner();
        }


        private void checkForWinner()
        {
            bool thereIsAWinner = false;

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text))
                thereIsAWinner = true;

            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text))
                thereIsAWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text))
                thereIsAWinner = true;


            if (thereIsAWinner)
            {
                string winner = "";
                if (turn)
                {
                    winner = "O";
                }
                else
                {
                    winner = "X";
                }

                MessageBox.Show(winner + "wins!");
            }


        } //end checkforwinner
    }
}
