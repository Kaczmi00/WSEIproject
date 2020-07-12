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

        bool kolej = true; // true= kolej X, false= kolej O.
        int liczba_kolejek = 0;   // tworzę licznik, w wypadku gdy liczba_kolejek=9  wyświetli się komunikat o remisie.

        public Form1()
        {
            InitializeComponent();
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e) //przypisuje zadanie do klawisza "wyjście"
        {
            Application.Exit();
        }

        private void nowaGraToolStripMenuItem_Click(object sender, EventArgs e) // przypisuje zadanie do klawisza "nowa gra".
        {
            Application.Restart();
        }

        private void button_click(object sender, EventArgs e) // tworzę funkcję button_click, która ma za zadanie odczytywać kliknięcia na przyciski
        {
            Button b = (Button)sender;
            if (kolej)                      // jeżeli kolej = true, w przycisku(kwadracie) ujrzymy X. 
                {
                b.Text = "X";
            }
            else                            // jeżeli kolej = false, po kliknięciu w dany kwadrat pojawi się O.
            {
                b.Text = "O";
            }

            kolej = !kolej;                 // po wszystkim status "kolejki" zmienia się  z true na false i odwrotnie, aby przeciwny gracz mógł wykonać swój ruch.
            b.Enabled = false;              // guzik zostaje wyłączony, aby nie można było zmienić wykonanego ruchu

            liczba_kolejek++;                  // liczba kolejek wzrasta o jeden. Przyda się na wypadek, gdy żaden z graczy nie wygra, aby wyświetlić remis.

            CzyJestZwyciezca();                //  zastosowanie funkcji "CzyJestZwyciezca".
        }


        private void CzyJestZwyciezca()
        {
            bool JestZwyciezca = false;                 // tworzenie wartości logicznej JestZwycięzca i ustawienie jej na false.    

                                                        // sprawdzanie, czy wartości w rzędzie są takie same, i jednocześnie niepuste. Jeśli tak, wartość "zwycięzca" zmieni się w true.
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))          
                JestZwyciezca = true;

            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) &&(!B1.Enabled))
                JestZwyciezca = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                JestZwyciezca = true;


                                                         // sprawdzanie, czy wartości w pionie są takie same, i jednocześnie niepuste. Jeśli tak, wartość "zwycięzca" zmieni się w true.
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                JestZwyciezca = true;

            else if ((A2.Text == B2.Text) && (B2.Text == C3.Text) && (!A2.Enabled))
                JestZwyciezca = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                JestZwyciezca = true;

                                                          // sprawdzanie, czy wartości na skos są takie same, i jednocześnie niepuste. Jeśli tak, wartość "zwycięzca" zmieni się w true.
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                JestZwyciezca = true;

            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                JestZwyciezca = true;
            

            if (JestZwyciezca)                        
            {
                WylaczPrzyciski();                    
                string wygrany = "";                        
                if (kolej)
                {
                    wygrany = "O";
                }
                else
                {
                    wygrany = "X";
                }

                MessageBox.Show(wygrany + " WYGRYWA!");     // wyświetlanie komunikatu o tym, kto wygrał
            } 

            else
            {
                if (liczba_kolejek == 9)                    // jeżeli liczba kolejek wynosi 9, wyświetla się komunikat o remisie.
                    MessageBox.Show(" REMIS!");
            }


        } 

        private void WylaczPrzyciski()                             // jeżeli któryś z graczy wygra, przyciski się wyłączają aby nie można było kontynuować gry.
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }
    }
}
