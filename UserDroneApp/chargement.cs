using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace UserDroneApp
{
    public partial class chargement : Form
    {
        public chargement()
        {
            InitializeComponent();
            timer1.Enabled = true;
            BtnDyna(10, 10);
        }

        private void chargement_Paint(object sender, PaintEventArgs e)
        {
            Pen monStylo = new Pen(Color.FromArgb(43, 250, 250), 5);
            Graphics g = this.CreateGraphics();
            

            g.DrawArc(monStylo, 10, 10, this.Size.Width - 20, this.Size.Height - 20, 0, 360);

            
        }

        private int i = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Pen monStylo = new Pen(Color.FromArgb(43, 250, 250), 5);
            Graphics g = this.CreateGraphics();
            

            
            while (true)
            {
                g.drawRectangle(monStylo, 10, 10, this.Size.Width - 20, this.Size.Height - 20, 0, 360);

                
                i++;
            }
        }






        public Button[,] btnDynaEasterEgg;

        public void BtnDyna(int li, int co)
        {
            int PHaut, PGauche, TLarge, THaut, compte;
            PHaut = 85;
            PGauche = 15;
            TLarge = 50;
            THaut = 50;

            btnDynaEasterEgg = new Button[li, co];

            for (int index = 0; index < li; index++)
            {
                for (int index2 = 0; index2 < co; index2++)
                {
                    btnDynaEasterEgg[index, index2] = new Button();
                    btnDynaEasterEgg[index, index2].Visible = true;
                    btnDynaEasterEgg[index, index2].Name = "btn_" + index + "_" + index2;
                    btnDynaEasterEgg[index, index2].BackColor = Color.Aquamarine;
                    btnDynaEasterEgg[index, index2].Top = PHaut;
                    btnDynaEasterEgg[index, index2].Left = PGauche;
                    btnDynaEasterEgg[index, index2].Width = TLarge;
                    btnDynaEasterEgg[index, index2].Height = THaut;

                    this.Controls.Add(btnDynaEasterEgg[index, index2]);


                    PGauche += 65;

                }
                PGauche = 15;
                PHaut += 65;

            }


        }


    }
}
