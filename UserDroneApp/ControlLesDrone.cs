using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using UserDroneApp.Properties;
using System.Resources;

namespace UserDroneApp
{
    public partial class ControlLesDrone : Form
    {
        public ControlLesDrone()
        {
            InitializeComponent();

            lblSide.Text = (trckSide.Value/100f).ToString();
            lbldirection.Text = (trckdirection.Value/100f).ToString();
            lblRotation.Text = (trckRotation.Value/100f).ToString();
            lblup.Text = (trckUp.Value/100f).ToString();

            string message = $"Rcspeed {lblSide.Text} {lbldirection.Text} {lblRotation.Text} {lblup.Text}";

            SendMessageToTarget(message);

        }



        public void SendMessageToTarget(string message)
        {
            string answers = message;
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress serverAddr = IPAddress.Parse(Accueil.Ip);
            IPEndPoint endPoint = new IPEndPoint(serverAddr,Accueil.port);
            byte[] send_buffer = Encoding.Unicode.GetBytes(answers);
            sock.SendTo(send_buffer, endPoint);
        }


        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            string message = "";
            


            switch(e.KeyChar)
            {
                case 'z':
                    message = "Rc 0 0.5 0 0";
                    break;

                case 's':
                    message = "Rc 0 -0.5 0 0";
                    break;


                case 'q':
                    message = "Rc -0.5 0 0 0";
                    break;

                case 'd':
                    message = "Rc 0.5 0 0 0";
                    break;

                case 'o':
                    message = "Rc 0 0 0 0.5";
                    break;

                case 'l':
                    message = "Rc 0 0 0 -0.5";
                    break;

                case 'k':
                    message = "Rc 0 0 -0.5 0";
                    break;

                case 'm':
                    message = "Rc 0 0 0.5 0";
                    break;


            }


            SendMessageToTarget(message);
            //message = "Rc 0 0 0 0";

            //SendMessageToTarget(message);
        }

        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            string message = "Rc 0 0 0 0";
            SendMessageToTarget(message);
        }

        public Button[] btnKick;

        private void Control_Load(object sender, EventArgs e)
        {
            btnKick = new Button[]
            {
                new Button()
            };

            btnKick[0].Visible = true;
            btnKick[0].Name = "btn_kick";
            btnKick[0].BackColor = Color.Aquamarine;
            btnKick[0].Top = this.Height - 50;
            btnKick[0].Left = this.Width - 100;
            btnKick[0].Width = 85;
            btnKick[0].Height = 35;
            btnKick[0].Text = "Quittez";

            this.Controls.Add(btnKick[0]);

            btnKick[0].Click += new EventHandler(Btn_Click);
        }

        public void Btn_Click(object Sender, EventArgs e)
        {
            Application.Exit();
        }

        private void trckSide_Scroll(object sender, EventArgs e)
        {
            float valeur = trckSide.Value / 100f;
            lblSide.Text = valeur.ToString();

            string message = $"Rcspeed {lblSide.Text} {lbldirection.Text} {lblRotation.Text} {lblup.Text}";

            SendMessageToTarget(message);
        }

        private void trckdirection_Scroll(object sender, EventArgs e)
        {
            float valeur = trckdirection.Value / 100f;
            lbldirection.Text = valeur.ToString();

            string message = $"Rcspeed {lblSide.Text} {lbldirection.Text} {lblRotation.Text} {lblup.Text}";

            SendMessageToTarget(message);
        }

        private void trckRotation_Scroll(object sender, EventArgs e)
        {
            float valeur = trckRotation.Value / 100f;
            lblRotation.Text = $"{valeur}";

            string message = $"Rcspeed {lblSide.Text} {lbldirection.Text} {lblRotation.Text} {lblup.Text}";

            SendMessageToTarget(message);
        }

        private void trckUp_Scroll(object sender, EventArgs e)
        {
            float valeur = trckUp.Value / 100f;
            lblup.Text = valeur.ToString();

            string message = $"Rcspeed {lblSide.Text} {lbldirection.Text} {lblRotation.Text} {lblup.Text}";

            SendMessageToTarget(message);
        }



    }
}
