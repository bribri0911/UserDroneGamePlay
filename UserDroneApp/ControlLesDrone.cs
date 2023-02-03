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
using Windows.Gaming.Input;
using Windows.Gaming.XboxLive;
using System.Diagnostics;

namespace UserDroneApp
{
    


    public partial class ControlLesDrone : Form
    {
        public ControlLesDrone()
        {
            InitializeComponent();

            lblSide.Text = (trckSide.Value / 100f).ToString();
            lbldirection.Text = (trckdirection.Value / 100f).ToString();
            lblRotation.Text = (trckRotation.Value / 100f).ToString();
            lblup.Text = (trckUp.Value / 100f).ToString();

            string message = $"Rcspeed {lblSide.Text} {lbldirection.Text} {lblRotation.Text} {lblup.Text}";

            SendMessageToTarget(message);

        }

        Gamepad Controller;




        public void SendMessageToTarget(string message)
        {
            string answers = message;
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress serverAddr = IPAddress.Parse(Accueil.Ip);
            IPEndPoint endPoint = new IPEndPoint(serverAddr, Accueil.port);
            byte[] send_buffer = Encoding.Unicode.GetBytes(answers);
            sock.SendTo(send_buffer, endPoint);
        }


       

        private void Control_KeyUp(object sender, KeyEventArgs e)
        {

            //string message = "Rc 0 0 0 0";
            //SendMessageToTarget(message);
        }

        public Button[] btnKick;

        private void Control_Load(object sender, EventArgs e)
        {
            btnKick = new Button[]
            {
                new Button()
            };

            
            lblInfo.Text = "Button A = kill the monster\r\nButton B = Spawn the monster\r\nButton X = Revive all player";
           

            btnKick[0].Visible = true;
            btnKick[0].Name = "btn_kick";
            btnKick[0].BackColor = Color.Aquamarine;
            btnKick[0].Top = this.Height - 50;
            btnKick[0].Left = this.Width - 100;
            btnKick[0].Width = 85;
            btnKick[0].Height = 35;
            btnKick[0].Text = "Close app";

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

        private void button1_Click(object sender, EventArgs e)
        {
            string message = $"go to {textBox1.Text} {textBox2.Text} {textBox3.Text}";
            SendMessageToTarget(message);
        }

        //XInputController XboxControl = new XInputController();

        private void ControlXbox_Tick(object sender, EventArgs e)
        {
            //string message = "";

            if (Gamepad.Gamepads.Count > 0)
            {
                Controller = Gamepad.Gamepads.First();



                float LeftRight = 0, DownUp = 0, RotateLeftRight = 0, backFrond = 0;

                GamepadReading Reading = Controller.GetCurrentReading();

                LeftRight = (float)Reading.LeftThumbstickX * ((float)trckSide.Value / 100);
                DownUp = (float)Reading.RightThumbstickY * ((float)trckdirection.Value / 100);
                RotateLeftRight = (float)Reading.RightThumbstickX * ((float)trckRotation.Value / 100);
                backFrond = (float)Reading.LeftThumbstickY * ((float)trckUp.Value / 100);

                Console.Out.WriteLine( ((float)Reading.LeftThumbstickX));
                //Console.Out.WriteLine((float) Reading.LeftThumbstickY);
                //Console.Out.WriteLine((float) Reading.RightThumbstickX);
                //Console.Out.WriteLine((float) Reading.RightThumbstickY);
                Console.Out.WriteLine(LeftRight);

                if (LeftRight <= 0.05 && LeftRight >= -0.05) LeftRight = 0;
                if (DownUp <= 0.05 && DownUp >= -0.05) DownUp = 0;
                if (RotateLeftRight <= 0.05 && RotateLeftRight >= -0.05) RotateLeftRight = 0;
                if (backFrond <= 0.05 && backFrond >= -0.05) backFrond = 0;


                string commande = string.Format("Rc {0} {1} {2} {3}", LeftRight, backFrond, RotateLeftRight, DownUp);

                
                if (commande != "")
                {
                    SendMessageToTarget(commande);
                }
                string message = "";

                if (Reading.Buttons == GamepadButtons.A) message = "cmdadmin:monsterkill";
                if (Reading.Buttons == GamepadButtons.B) message = "cmdadmin:monsterspawn ";
                if (Reading.Buttons == GamepadButtons.X) message = "cmdadmin:reviveallplayer";

                SendMessageToTarget(message);

                
                

                LeftRight = 0;
                backFrond = 0;
                RotateLeftRight = 0;
                DownUp = 0;
                
            }

            



            {
                /*
                if (XboxControl.leftTrigger != 0 && XboxControl.rightTrigger != 0)
                {
                    string message = $"Rc {XboxControl.leftThumb.X / 100} {XboxControl.leftThumb.Y / 100} {XboxControl.rightThumb.X / 100} {XboxControl.rightThumb.Y / 100}";
                    SendMessageToTarget(message);
                }*/
            }
        }
    }

    /*
    class XInputController
    {
        Controller controller;
        Gamepad gamepad;
        public bool connected = false;
        public int deadband = 2500;
        public Point leftThumb, rightThumb = new Point(0, 0);
        public float leftTrigger, rightTrigger;

        public XInputController()
        {
            controller = new Controller(UserIndex.One);
            connected = controller.IsConnected;
        }

        // Call this method to update all class values
        public void Update()
        {
            if (!connected) return;

            gamepad = controller.GetState().Gamepad;

            //float test = (Math.Abs((float)gamepad.RightThumbY) < deadband) ? 0 : (float)gamepad.RightThumbY / short.MaxValue * 100
            float X1, X2, Y1, Y2;

            X1 = (Math.Abs((float)gamepad.LeftThumbX) < deadband) ? 0 : (float)gamepad.LeftThumbX / short.MinValue * -100;
            X2 = (Math.Abs((float)gamepad.RightThumbY) < deadband) ? 0 : (float)gamepad.RightThumbY / short.MaxValue * 100;
            Y1 = (Math.Abs((float)gamepad.LeftThumbY) < deadband) ? 0 : (float)gamepad.LeftThumbY / short.MaxValue * 100;
            Y2 = (Math.Abs((float)gamepad.RightThumbX) < deadband) ? 0 : (float)gamepad.RightThumbX / short.MaxValue * 100;


            leftThumb.X = Convert.ToInt32(X1*100);
            leftThumb.Y = Convert.ToInt32(Y1*100);
            rightThumb.Y = Convert.ToInt32(Y2*100);
            rightThumb.X = Convert.ToInt32(X2*100);

            leftTrigger = gamepad.LeftTrigger/100;
            rightTrigger = gamepad.RightTrigger/100;
        }
    }
    */

}
