
namespace UserDroneApp
{
    partial class Accueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Accueil));
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.boxinfo = new System.Windows.Forms.GroupBox();
            this.btnPortChanger = new System.Windows.Forms.Button();
            this.lblCouleur = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtG = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtR = new System.Windows.Forms.TextBox();
            this.cmbCouleur = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPseudo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLancer = new System.Windows.Forms.Button();
            this.timergeneral = new System.Windows.Forms.Timer(this.components);
            this.boxinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(133, 18);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(323, 22);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "192.168.1.104";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adresse IP Prof : ";
            // 
            // boxinfo
            // 
            this.boxinfo.Controls.Add(this.btnPortChanger);
            this.boxinfo.Controls.Add(this.lblCouleur);
            this.boxinfo.Controls.Add(this.txtB);
            this.boxinfo.Controls.Add(this.txtG);
            this.boxinfo.Controls.Add(this.label5);
            this.boxinfo.Controls.Add(this.txtR);
            this.boxinfo.Controls.Add(this.cmbCouleur);
            this.boxinfo.Controls.Add(this.label4);
            this.boxinfo.Controls.Add(this.txtPort);
            this.boxinfo.Controls.Add(this.label3);
            this.boxinfo.Controls.Add(this.txtPseudo);
            this.boxinfo.Controls.Add(this.label2);
            this.boxinfo.Controls.Add(this.txtIP);
            this.boxinfo.Controls.Add(this.label1);
            this.boxinfo.Location = new System.Drawing.Point(12, 12);
            this.boxinfo.Name = "boxinfo";
            this.boxinfo.Size = new System.Drawing.Size(471, 186);
            this.boxinfo.TabIndex = 2;
            this.boxinfo.TabStop = false;
            // 
            // btnPortChanger
            // 
            this.btnPortChanger.Location = new System.Drawing.Point(133, 46);
            this.btnPortChanger.Name = "btnPortChanger";
            this.btnPortChanger.Size = new System.Drawing.Size(323, 27);
            this.btnPortChanger.TabIndex = 13;
            this.btnPortChanger.Text = "Changer le port";
            this.btnPortChanger.UseVisualStyleBackColor = true;
            this.btnPortChanger.Click += new System.EventHandler(this.btnPortChanger_Click);
            // 
            // lblCouleur
            // 
            this.lblCouleur.Location = new System.Drawing.Point(341, 114);
            this.lblCouleur.Name = "lblCouleur";
            this.lblCouleur.Size = new System.Drawing.Size(98, 22);
            this.lblCouleur.TabIndex = 12;
            this.lblCouleur.Text = "                ";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(288, 114);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(47, 22);
            this.txtB.TabIndex = 11;
            this.txtB.TextChanged += new System.EventHandler(this.txtB_TextChanged);
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(235, 114);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(47, 22);
            this.txtG.TabIndex = 10;
            this.txtG.TextChanged += new System.EventHandler(this.txtG_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "RGB";
            // 
            // txtR
            // 
            this.txtR.Location = new System.Drawing.Point(182, 114);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(47, 22);
            this.txtR.TabIndex = 8;
            this.txtR.TextChanged += new System.EventHandler(this.txtR_TextChanged);
            // 
            // cmbCouleur
            // 
            this.cmbCouleur.FormattingEnabled = true;
            this.cmbCouleur.Items.AddRange(new object[] {
            "vert",
            "jaune",
            "bleu",
            "cyan",
            "rouge",
            "gris"});
            this.cmbCouleur.Location = new System.Drawing.Point(133, 79);
            this.cmbCouleur.Name = "cmbCouleur";
            this.cmbCouleur.Size = new System.Drawing.Size(144, 24);
            this.cmbCouleur.TabIndex = 7;
            this.cmbCouleur.SelectedIndexChanged += new System.EventHandler(this.cmbCouleur_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "couleur : ";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(133, 46);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(319, 22);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "2509";
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Port : ";
            // 
            // txtPseudo
            // 
            this.txtPseudo.Location = new System.Drawing.Point(133, 149);
            this.txtPseudo.Name = "txtPseudo";
            this.txtPseudo.Size = new System.Drawing.Size(323, 22);
            this.txtPseudo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pseudo :";
            // 
            // btnLancer
            // 
            this.btnLancer.Location = new System.Drawing.Point(12, 204);
            this.btnLancer.Name = "btnLancer";
            this.btnLancer.Size = new System.Drawing.Size(456, 56);
            this.btnLancer.TabIndex = 3;
            this.btnLancer.Text = "rejoindre la partie";
            this.btnLancer.UseVisualStyleBackColor = true;
            this.btnLancer.Click += new System.EventHandler(this.btnLancer_Click);
            // 
            // timergeneral
            // 
            this.timergeneral.Tick += new System.EventHandler(this.timergeneral_Tick);
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 272);
            this.Controls.Add(this.btnLancer);
            this.Controls.Add(this.boxinfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Accueil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.boxinfo.ResumeLayout(false);
            this.boxinfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox boxinfo;
        private System.Windows.Forms.TextBox txtPseudo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.ComboBox cmbCouleur;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCouleur;
        private System.Windows.Forms.Button btnLancer;
        private System.Windows.Forms.Button btnPortChanger;
        private System.Windows.Forms.Timer timergeneral;
    }
}

