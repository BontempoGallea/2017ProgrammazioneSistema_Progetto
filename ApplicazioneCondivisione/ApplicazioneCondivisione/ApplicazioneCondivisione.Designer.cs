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
            this.listaUsers = new System.Windows.Forms.ListView();
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
            this.button1.Location = new System.Drawing.Point(653, 756);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(415, 88);
            this.button1.TabIndex = 2;
            this.button1.Text = "Condividi";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.condividiButton_Click);
            // 
            // button2
            // 
            this.button2.AccessibleName = "annullaButton";
            this.button2.Location = new System.Drawing.Point(1107, 756);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(415, 88);
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
            this.iconContextMenu.Size = new System.Drawing.Size(202, 102);
            // 
            // statoToolStripMenuItem
            // 
            this.statoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlineToolStripMenuItem,
            this.offlineToolStripMenuItem});
            this.statoToolStripMenuItem.Name = "statoToolStripMenuItem";
            this.statoToolStripMenuItem.Size = new System.Drawing.Size(201, 46);
            this.statoToolStripMenuItem.Text = "Stato";
            // 
            // onlineToolStripMenuItem
            // 
            this.onlineToolStripMenuItem.Name = "onlineToolStripMenuItem";
            this.onlineToolStripMenuItem.Size = new System.Drawing.Size(216, 46);
            this.onlineToolStripMenuItem.Text = "online";
            this.onlineToolStripMenuItem.Click += new System.EventHandler(this.onlineOptionIconContextMenu_Click);
            // 
            // offlineToolStripMenuItem
            // 
            this.offlineToolStripMenuItem.Name = "offlineToolStripMenuItem";
            this.offlineToolStripMenuItem.Size = new System.Drawing.Size(216, 46);
            this.offlineToolStripMenuItem.Text = "offline";
            this.offlineToolStripMenuItem.Click += new System.EventHandler(this.offlineOptionIconContextMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // esciToolStripMenuItem1
            // 
            this.esciToolStripMenuItem1.Name = "esciToolStripMenuItem1";
            this.esciToolStripMenuItem1.Size = new System.Drawing.Size(201, 46);
            this.esciToolStripMenuItem1.Text = "Esci";
            this.esciToolStripMenuItem1.Click += new System.EventHandler(this.esciOptionIconContextMenu_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(31, 140);
            this.refresh.Margin = new System.Windows.Forms.Padding(4);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(173, 151);
            this.refresh.TabIndex = 4;
            this.refresh.Text = "refresh";
            this.refresh.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // changeState
            // 
            this.changeState.Location = new System.Drawing.Point(245, 140);
            this.changeState.Margin = new System.Windows.Forms.Padding(4);
            this.changeState.Name = "changeState";
            this.changeState.Size = new System.Drawing.Size(173, 151);
            this.changeState.Style = MetroFramework.MetroColorStyle.Red;
            this.changeState.TabIndex = 5;
            this.changeState.Text = "state";
            this.changeState.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.changeState.Click += new System.EventHandler(this.changeState_Click);
            // 
            // nome
            // 
            this.nome.AutoSize = true;
            this.nome.Location = new System.Drawing.Point(1213, 140);
            this.nome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(84, 20);
            this.nome.TabIndex = 6;
            this.nome.Text = "metroLabel1";
            // 
            // cognome
            // 
            this.cognome.AutoSize = true;
            this.cognome.Location = new System.Drawing.Point(1213, 182);
            this.cognome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cognome.Name = "cognome";
            this.cognome.Size = new System.Drawing.Size(87, 20);
            this.cognome.TabIndex = 7;
            this.cognome.Text = "metroLabel2";
            // 
            // stato
            // 
            this.stato.AutoSize = true;
            this.stato.Location = new System.Drawing.Point(1213, 233);
            this.stato.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stato.Name = "stato";
            this.stato.Size = new System.Drawing.Size(87, 20);
            this.stato.TabIndex = 8;
            this.stato.Text = "metroLabel3";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(717, 140);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(87, 20);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "metroLabel4";
            // 
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
            // ApplicazioneCondivisione
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1575, 874);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.stato);
            this.Controls.Add(this.cognome);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.changeState);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listaUsers);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ApplicazioneCondivisione";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
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
        public System.Windows.Forms.ListView listaUsers;
    }
}

