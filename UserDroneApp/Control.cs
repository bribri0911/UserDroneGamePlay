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
    public partial class Control : Form
    {
        public Control()
        {
            InitializeComponent();
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
            btnKick = new Button[1];
            btnKick[0].Visible = true;
            btnKick[0].Name = "btn_kick";
            btnKick[0].BackColor = Color.Aquamarine;
            btnKick[0].Top = 10;
            btnKick[0].Left = this.Width - 100;
            btnKick[0].Width = 80;
            btnKick[0].Height = 30;
            btnKick[0].Text = "Quittez";

            this.Controls.Add(btnKick[0]);

            btnKick[0].Click += new EventHandler(Btn_Click);
        }

        public void Btn_Click(object Sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
