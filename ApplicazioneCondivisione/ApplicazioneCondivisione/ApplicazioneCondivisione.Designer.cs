namespace ApplicazioneCondivisione
{
  public  partial class ApplicazioneCondivisione : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicazioneCondivisione));
            this.taskbarIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.iconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.esciToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.refresh = new MetroFramework.Controls.MetroTile();
            this.changeState = new MetroFramework.Controls.MetroTile();
            this.nome = new MetroFramework.Controls.MetroLabel();
            this.cognome = new MetroFramework.Controls.MetroLabel();
            this.stato = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
<<<<<<< HEAD
=======
            this.listaUsers = new System.Windows.Forms.ListView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
>>>>>>> refs/remotes/origin/master
            this.iconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskbarIcon
            // 
            this.taskbarIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.taskbarIcon.BalloonTipText = "L\'applicazione è stata minimizzata!";
            this.taskbarIcon.BalloonTipTitle = "Fai doppio clic su questa icona per riaprire.";
            this.taskbarIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("taskbarIcon.Icon")));
            this.taskbarIcon.Text = "Applicazione Sharing";
            this.taskbarIcon.Visible = true;
            this.taskbarIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.taskbarIcon_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.AccessibleName = "condividiButton";
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(490, 610);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(311, 71);
            this.button1.TabIndex = 2;
            this.button1.Text = "Condividi";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.condividiButton_Click);
            // 
            // button2
            // 
            this.button2.AccessibleName = "annullaButton";
            this.button2.Location = new System.Drawing.Point(830, 610);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(311, 71);
            this.button2.TabIndex = 3;
            this.button2.Text = "Annulla";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.annullaButton_Click);
            // 
            // iconContextMenu
            // 
            this.iconContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.iconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statoToolStripMenuItem,
            this.toolStripSeparator1,
            this.esciToolStripMenuItem1});
            this.iconContextMenu.Name = "iconContextMenu";
            this.iconContextMenu.Size = new System.Drawing.Size(170, 86);
            // 
            // statoToolStripMenuItem
            // 
            this.statoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlineToolStripMenuItem,
            this.offlineToolStripMenuItem});
            this.statoToolStripMenuItem.Name = "statoToolStripMenuItem";
            this.statoToolStripMenuItem.Size = new System.Drawing.Size(169, 38);
            this.statoToolStripMenuItem.Text = "Stato";
            // 
            // onlineToolStripMenuItem
            // 
            this.onlineToolStripMenuItem.Name = "onlineToolStripMenuItem";
            this.onlineToolStripMenuItem.Size = new System.Drawing.Size(184, 38);
            this.onlineToolStripMenuItem.Text = "online";
            this.onlineToolStripMenuItem.Click += new System.EventHandler(this.onlineOptionIconContextMenu_Click);
            // 
            // offlineToolStripMenuItem
            // 
            this.offlineToolStripMenuItem.Name = "offlineToolStripMenuItem";
            this.offlineToolStripMenuItem.Size = new System.Drawing.Size(184, 38);
            this.offlineToolStripMenuItem.Text = "offline";
            this.offlineToolStripMenuItem.Click += new System.EventHandler(this.offlineOptionIconContextMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // esciToolStripMenuItem1
            // 
            this.esciToolStripMenuItem1.Name = "esciToolStripMenuItem1";
            this.esciToolStripMenuItem1.Size = new System.Drawing.Size(169, 38);
            this.esciToolStripMenuItem1.Text = "Esci";
            this.esciToolStripMenuItem1.Click += new System.EventHandler(this.esciOptionIconContextMenu_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(23, 113);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(130, 122);
            this.refresh.TabIndex = 4;
            this.refresh.Text = "refresh";
            this.refresh.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // changeState
            // 
            this.changeState.Location = new System.Drawing.Point(184, 113);
            this.changeState.Name = "changeState";
            this.changeState.Size = new System.Drawing.Size(130, 122);
            this.changeState.Style = MetroFramework.MetroColorStyle.Red;
            this.changeState.TabIndex = 5;
            this.changeState.Text = "state";
            this.changeState.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.changeState.Click += new System.EventHandler(this.changeState_Click);
            // 
            // nome
            // 
            this.nome.AutoSize = true;
            this.nome.Location = new System.Drawing.Point(910, 113);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(81, 19);
            this.nome.TabIndex = 6;
            this.nome.Text = "metroLabel1";
            // 
            // cognome
            // 
            this.cognome.AutoSize = true;
            this.cognome.Location = new System.Drawing.Point(910, 147);
            this.cognome.Name = "cognome";
            this.cognome.Size = new System.Drawing.Size(83, 19);
            this.cognome.TabIndex = 7;
            this.cognome.Text = "metroLabel2";
            // 
            // stato
            // 
            this.stato.AutoSize = true;
            this.stato.Location = new System.Drawing.Point(910, 188);
            this.stato.Name = "stato";
            this.stato.Size = new System.Drawing.Size(83, 19);
            this.stato.TabIndex = 8;
            this.stato.Text = "metroLabel3";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(538, 113);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(83, 19);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "metroLabel4";
            // 
<<<<<<< HEAD
=======
            // listaUsers
            // 
            this.listaUsers.AccessibleName = "UsersList";
            this.listaUsers.Location = new System.Drawing.Point(452, 834);
            this.listaUsers.Margin = new System.Windows.Forms.Padding(4);
            this.listaUsers.Name = "listaUsers";
            this.listaUsers.Size = new System.Drawing.Size(10, 10);
            this.listaUsers.TabIndex = 1;
            this.listaUsers.UseCompatibleStateImageBehavior = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(31, 298);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1491, 431);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
>>>>>>> refs/remotes/origin/master
            // ApplicazioneCondivisione
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(1225, 754);
=======
            this.ClientSize = new System.Drawing.Size(1575, 874);
            this.Controls.Add(this.flowLayoutPanel1);
>>>>>>> refs/remotes/origin/master
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.stato);
            this.Controls.Add(this.cognome);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.changeState);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ApplicazioneCondivisione";
            this.Text = "Condividi con...";
            this.Load += new System.EventHandler(this.applicazioneCondivisione_Load);
            this.Resize += new System.EventHandler(this.applicazioneCondivisione_Resize);
            this.iconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon taskbarIcon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip iconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem statoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem onlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offlineToolStripMenuItem;
        private MetroFramework.Controls.MetroTile refresh;
        private MetroFramework.Controls.MetroTile changeState;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        public MetroFramework.Controls.MetroLabel nome;
        public MetroFramework.Controls.MetroLabel cognome;
        public MetroFramework.Controls.MetroLabel stato;
<<<<<<< HEAD
=======
        public System.Windows.Forms.ListView listaUsers;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
>>>>>>> refs/remotes/origin/master
    }
}

