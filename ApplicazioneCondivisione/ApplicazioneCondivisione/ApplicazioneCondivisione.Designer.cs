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
            this.refresh = new MetroFramework.Controls.MetroTile();
            this.changeState = new MetroFramework.Controls.MetroTile();
            this.nome = new MetroFramework.Controls.MetroLabel();
            this.cognome = new MetroFramework.Controls.MetroLabel();
            this.stato = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.didascalia = new MetroFramework.Controls.MetroLabel();
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
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(33, 113);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(108, 104);
            this.refresh.TabIndex = 4;
            this.refresh.TileImage = global::ApplicazioneCondivisione.Properties.Resources.refresh;
            this.refresh.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.refresh.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.refresh.UseTileImage = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // changeState
            // 
            this.changeState.Location = new System.Drawing.Point(184, 113);
            this.changeState.Name = "changeState";
            this.changeState.Size = new System.Drawing.Size(253, 104);
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
            this.metroLabel4.Size = new System.Drawing.Size(81, 19);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Credenziali: ";
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
            // ApplicazioneCondivisione
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 714);
            this.Controls.Add(this.didascalia);
            this.Controls.Add(this.flowLayoutPanel1);
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
            this.Load += new System.EventHandler(this.onlineOptionIconContextMenu_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon taskbarIcon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private MetroFramework.Controls.MetroTile refresh;
        private MetroFramework.Controls.MetroTile changeState;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        public MetroFramework.Controls.MetroLabel nome;
        public MetroFramework.Controls.MetroLabel cognome;
        public MetroFramework.Controls.MetroLabel stato;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroLabel didascalia;
    }
}

