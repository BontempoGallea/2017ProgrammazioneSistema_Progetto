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
            this.condividiButton = new System.Windows.Forms.Button();
            this.annullaButton = new System.Windows.Forms.Button();
            this.changeState = new MetroFramework.Controls.MetroTile();
            this.name = new MetroFramework.Controls.MetroLabel();
            this.surname = new MetroFramework.Controls.MetroLabel();
            this.state = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.didascalia = new MetroFramework.Controls.MetroLabel();
            this.contextMenuStripTaskbarIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsButton = new MetroFramework.Controls.MetroTile();
            this.refreshButton = new MetroFramework.Controls.MetroTile();
            this.contextMenuStripTaskbarIcon.SuspendLayout();
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
            // condividiButton
            // 
            this.condividiButton.AccessibleName = "condividiButton";
            this.condividiButton.BackColor = System.Drawing.Color.Transparent;
            this.condividiButton.Location = new System.Drawing.Point(490, 610);
            this.condividiButton.Name = "condividiButton";
            this.condividiButton.Size = new System.Drawing.Size(311, 71);
            this.condividiButton.TabIndex = 2;
            this.condividiButton.Text = "Condividi";
            this.condividiButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.condividiButton.UseVisualStyleBackColor = false;
            this.condividiButton.Click += new System.EventHandler(this.condividiButton_Click);
            // 
            // annullaButton
            // 
            this.annullaButton.AccessibleName = "annullaButton";
            this.annullaButton.Location = new System.Drawing.Point(830, 610);
            this.annullaButton.Name = "annullaButton";
            this.annullaButton.Size = new System.Drawing.Size(311, 71);
            this.annullaButton.TabIndex = 3;
            this.annullaButton.Text = "Annulla";
            this.annullaButton.UseVisualStyleBackColor = true;
            this.annullaButton.Click += new System.EventHandler(this.annullaButton_Click);
            // 
            // changeState
            // 
            this.changeState.Location = new System.Drawing.Point(184, 113);
            this.changeState.Name = "changeState";
            this.changeState.Size = new System.Drawing.Size(253, 104);
            this.changeState.Style = MetroFramework.MetroColorStyle.Red;
            this.changeState.TabIndex = 5;
            this.changeState.Text = "Cambia Stato";
            this.changeState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.changeState.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.changeState.Click += new System.EventHandler(this.changeState_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(910, 101);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(81, 19);
            this.name.TabIndex = 6;
            this.name.Text = "metroLabel1";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // surname
            // 
            this.surname.AutoSize = true;
            this.surname.Location = new System.Drawing.Point(910, 149);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(83, 19);
            this.surname.TabIndex = 7;
            this.surname.Text = "metroLabel2";
            this.surname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Location = new System.Drawing.Point(910, 195);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(83, 19);
            this.state.TabIndex = 8;
            this.state.Text = "metroLabel3";
            this.state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(628, 97);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(81, 19);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Credenziali: ";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(23, 287);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1101, 302);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // didascalia
            // 
            this.didascalia.AutoSize = true;
            this.didascalia.Location = new System.Drawing.Point(33, 248);
            this.didascalia.Name = "didascalia";
            this.didascalia.Size = new System.Drawing.Size(188, 19);
            this.didascalia.TabIndex = 12;
            this.didascalia.Text = "Seleziona chi vuoi inviare il file:";
            // 
            // contextMenuStripTaskbarIcon
            // 
            this.contextMenuStripTaskbarIcon.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripTaskbarIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apriToolStripMenuItem,
            this.statoToolStripMenuItem,
            this.toolStripSeparator1,
            this.esciToolStripMenuItem});
            this.contextMenuStripTaskbarIcon.Name = "contextMenuStripTaskbarIcon";
            this.contextMenuStripTaskbarIcon.Size = new System.Drawing.Size(170, 124);
            // 
            // apriToolStripMenuItem
            // 
            this.apriToolStripMenuItem.Name = "apriToolStripMenuItem";
            this.apriToolStripMenuItem.Size = new System.Drawing.Size(169, 38);
            this.apriToolStripMenuItem.Text = "Apri";
            this.apriToolStripMenuItem.Click += new System.EventHandler(this.apriOptionIconContextMenu_Click);
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
            this.onlineToolStripMenuItem.Size = new System.Drawing.Size(188, 38);
            this.onlineToolStripMenuItem.Text = "Online";
            this.onlineToolStripMenuItem.Click += new System.EventHandler(this.onlineOptionIconContextMenu_Click);
            // 
            // offlineToolStripMenuItem
            // 
            this.offlineToolStripMenuItem.Name = "offlineToolStripMenuItem";
            this.offlineToolStripMenuItem.Size = new System.Drawing.Size(188, 38);
            this.offlineToolStripMenuItem.Text = "Offline";
            this.offlineToolStripMenuItem.Click += new System.EventHandler(this.offlineOptionIconContextMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(169, 38);
            this.esciToolStripMenuItem.Text = "Esci";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.esciToolStripMenuItem_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.settingsButton.Location = new System.Drawing.Point(628, 139);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(81, 78);
            this.settingsButton.TabIndex = 13;
            this.settingsButton.TileImage = global::ApplicazioneCondivisione.Properties.Resources.settings;
            this.settingsButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.settingsButton.UseTileImage = true;
            this.settingsButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.settingsButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.refreshButton.Location = new System.Drawing.Point(33, 113);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(108, 104);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.TileImage = global::ApplicazioneCondivisione.Properties.Resources.refresh;
            this.refreshButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.refreshButton.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.refreshButton.UseTileImage = true;
            this.refreshButton.Click += new System.EventHandler(this.refresh_Click);
            // 
            // ApplicazioneCondivisione
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1161, 716);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.didascalia);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.state);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.name);
            this.Controls.Add(this.changeState);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.annullaButton);
            this.Controls.Add(this.condividiButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ApplicazioneCondivisione";
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.Text = "Condividi con...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ApplicazioneCondivisione_FormClosing);
            this.Load += new System.EventHandler(this.onlineOptionIconContextMenu_Click);
            this.contextMenuStripTaskbarIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon taskbarIcon;
        private System.Windows.Forms.Button condividiButton;
        private System.Windows.Forms.Button annullaButton;
        private MetroFramework.Controls.MetroTile changeState;
        private MetroFramework.Controls.MetroLabel didascalia;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTaskbarIcon;
        private System.Windows.Forms.ToolStripMenuItem apriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private MetroFramework.Controls.MetroTile refreshButton;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public MetroFramework.Controls.MetroLabel metroLabel4;
        public MetroFramework.Controls.MetroLabel name;
        public MetroFramework.Controls.MetroLabel surname;
        public MetroFramework.Controls.MetroLabel state;
        public MetroFramework.Controls.MetroTile settingsButton;
    }
}

