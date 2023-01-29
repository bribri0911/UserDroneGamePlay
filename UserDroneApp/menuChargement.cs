using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserDroneApp
{
    public partial class menuChargement : Form
    {
        
        public menuChargement()
        {
            InitializeComponent();
            index = this.Width / 2 - 90;
            timer1.Enabled = true;
            
        }

        private void menuChargement_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public int index = 0;
        private int leTemps = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            leTemps++;
            

            Graphics g = this.CreateGraphics();
            Pen monStylo = new Pen(Color.FromArgb(43, 250, 250), 5);
            Pen monStylo2 = new Pen(Color.FromArgb(149, 252, 252), 5);
            Pen monStylo3 = new Pen(Color.FromArgb(255, 255, 255), 5);

            g.DrawArc(monStylo, index , 130 , 5, 5 , 0, 360);
            
            g.DrawArc(monStylo2, index - 60, 130, 5, 5, 0, 360);
            g.DrawArc(monStylo3, index - 90, 130, 5, 5, 0, 360);

            index += 30;

            if (index > this.Width / 2 + 120)
            {
                Brush tempBrush = new SolidBrush(Color.White);
                g.FillRectangle( tempBrush, this.Width/2 + 80 , 120, this.Width/2, 20);
            }

            if (index > this.Width/2 + 210)
            {

                index = this.Width/2 -90;
            }

            if (leTemps > 106)
            {
                //Accueil frm = new Accueil();
                //frm.Show();

                this.Hide();

            }




        }

        

    }
}
