using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace UserDroneApp
{
    public partial class Accueil : Form
    {

        public static bool Stop = false;
        public int indexGeneral = 0;
        public static string Ip;
        public static int port;
        public string Pong = "";

        public Accueil()
        {
            UDPListenerThread t = new UDPListenerThread(ThreadPriority.Normal, 2508);
            t.AddListener(listenToServer);

            InitializeComponent();
        }

        private void listenToServer(in string unicodeText)
        {
            Pong = unicodeText;
        }

        public void SendMessageToTarget(string message)
        {

            string answers = message;

            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress serverAddr = IPAddress.Parse(Ip);
            IPEndPoint endPoint = new IPEndPoint(serverAddr, port);
            byte[] send_buffer = Encoding.Unicode.GetBytes(answers);
            sock.SendTo(send_buffer, endPoint);
        }


        public void ChoisirCouleur(string LaCouleur)
        {
            switch(LaCouleur)
            {
                case "vert":
                    txtR.Text = "0";
                    txtG.Text = "255";
                    txtB.Text = "0";
                    break;

                case "jaune":
                    txtR.Text = "255";
                    txtG.Text = "255";
                    txtB.Text = "0";

                    break;

                case "bleu":
                    txtR.Text = "0";
                    txtG.Text = "0";
                    txtB.Text = "255";

                    break;

                case "cyan":
                    txtR.Text = "0";
                    txtG.Text = "255";
                    txtB.Text = "255";

                    break;

                case "rouge":
                    txtR.Text = "255";
                    txtG.Text = "0";
                    txtB.Text = "0";

                    break;

                case "gris":
                    txtR.Text = "127";
                    txtG.Text = "127";
                    txtB.Text = "127";

                    break;


            }
        }

        private void btnLancer_Click(object sender, EventArgs e)
        {
            if(txtIP.Text != "")
            {
                Ip = txtIP.Text;
                port = int.Parse(txtPort.Text);

                if (txtPseudo.Text != "")
                {
                    string LesInfo = $"name: {txtPseudo.Text}";
                    SendMessageToTarget(LesInfo);
                }


                if (txtR.Text != "" && txtG.Text != "" && txtB.Text != "")
                {
                    Color myColor = Color.FromArgb(int.Parse(txtR.Text), int.Parse(txtG.Text), int.Parse(txtB.Text));
                    string hex = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");

                    string LesInfo = $"color: {hex}";
                    SendMessageToTarget(LesInfo);
                }


                string temps = "I be back";
                SendMessageToTarget(temps);
                timergeneral.Enabled = true;
                Stop = false;

                menuChargement frm = new menuChargement();
                frm.Show();

            }
            else
            {
                MessageBox.Show("Remplissez correctement toutes les cases", "Erreur !!!", MessageBoxButtons.OK);
            }
        }







        private void txtR_TextChanged(object sender, EventArgs e)
        {
            if(txtR.Text != "")
            {
                if(int.Parse(txtR.Text)<0)
                {
                    txtR.Text = "0";
                }

                if (int.Parse(txtR.Text) > 255)
                {
                    txtR.Text = "255";
                }

                if (txtR.Text != "" && txtG.Text != "" && txtB.Text != "")
                {
                    lblCouleur.BackColor = Color.FromArgb(int.Parse(txtR.Text), int.Parse(txtG.Text), int.Parse(txtB.Text));
                }
            }

            
        }

        private void txtG_TextChanged(object sender, EventArgs e)
        {
            if (txtG.Text != "")
            {
                if (int.Parse(txtG.Text) < 0)
                {
                    txtG.Text = "0";
                }

                if (int.Parse(txtG.Text) > 255)
                {
                    txtG.Text = "255";
                }

                if (txtR.Text != "" && txtG.Text != "" && txtB.Text != "")
                {
                    lblCouleur.BackColor = Color.FromArgb(int.Parse(txtR.Text), int.Parse(txtG.Text), int.Parse(txtB.Text));
                }
            }
        }

        private void txtB_TextChanged(object sender, EventArgs e)
        {
            if (txtB.Text != "")
            {
                if (int.Parse(txtB.Text) < 0)
                {
                    txtB.Text = "0";
                }

                if (int.Parse(txtB.Text) > 255)
                {
                    txtB.Text = "255";
                }

                if (txtR.Text != "" && txtG.Text != "" && txtB.Text != "")
                {
                    lblCouleur.BackColor = Color.FromArgb(int.Parse(txtR.Text), int.Parse(txtG.Text), int.Parse(txtB.Text));
                }
            }
        }

        private void cmbCouleur_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoisirCouleur(cmbCouleur.Text);
        }

        private void btnPortChanger_Click(object sender, EventArgs e)
        {
            btnPortChanger.Visible = false;
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(txtPort.Text, out int Port))
            {
                if(port < 2000)
                {
                    txtPort.Text = "2000";
                }
                if(port > 2500)
                {
                    txtPort.Text = "2500";
                }
            }
            else
            {
                txtPort.Text = "2508";
            }


        }

        private void timergeneral_Tick(object sender, EventArgs e)
        {
            if (Pong != "")
            {
                Stop = true;
                Pong = "";
                timergeneral.Enabled = false;
                indexGeneral = 0;
                MessageBox.Show("Je suis la");
            }
            else
            {
                if (indexGeneral > 105)
                {
                    timergeneral.Enabled = false;
                    MessageBox.Show("Verifiez que vous soyez sur le meme résaux, que vous ayez ecrit correctement l'addresse IP de l'hote et que vous soyez sur le meme port.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    indexGeneral = 0;
                    //MessageBox.Show("Vous avez été déconnecter du serveur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                indexGeneral++;
            }

            if(Stop)
            {
                MessageBox.Show("Je suis la 2");
                Control frm = new Control();
                frm.Show();
                this.Hide();
            }


        }
    }
}
