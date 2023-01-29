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
    public partial class Admin : Form
    {
        public Admin()
        {
            
            InitializeComponent();
            Accueil frm = new Accueil();
            frm.Show();
            this.Hide();

        }
    }
}
