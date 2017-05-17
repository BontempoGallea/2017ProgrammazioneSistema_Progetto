namespace ApplicazioneCondivisione
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.defaultPath = new System.Windows.Forms.Label();
            this.destinationPath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.description = new System.Windows.Forms.Label();
            this.salvaModifiche = new System.Windows.Forms.Button();
            this.Annulla = new System.Windows.Forms.Button();
            this.radioButtonNo = new System.Windows.Forms.RadioButton();
            this.radioButtonSi = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Nome = new System.Windows.Forms.Label();
            this.Cognome = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxCognome = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // defaultPath
            // 
            this.defaultPath.AutoSize = true;
            this.defaultPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultPath.Location = new System.Drawing.Point(22, 307);
            this.defaultPath.Name = "defaultPath";
            this.defaultPath.Size = new System.Drawing.Size(320, 31);
            this.defaultPath.TabIndex = 1;
            this.defaultPath.Text = "Cartella di destinazione";
            this.defaultPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // destinationPath
            // 
            this.destinationPath.AccessibleName = "destinationPath";
            this.destinationPath.AutoSize = true;
            this.destinationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationPath.Location = new System.Drawing.Point(22, 381);
            this.destinationPath.Name = "destinationPath";
            this.destinationPath.Size = new System.Drawing.Size(0, 25);
            this.destinationPath.TabIndex = 2;
            this.destinationPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 491);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Salvataggio automatico dei file?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.AccessibleName = "browse";
            this.button1.Location = new System.Drawing.Point(773, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Sfoglia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // description
            // 
            this.description.AccessibleName = "description";
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(450, 557);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(0, 25);
            this.description.TabIndex = 7;
            this.description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // salvaModifiche
            // 
            this.salvaModifiche.AccessibleName = "salvaModifiche";
            this.salvaModifiche.Location = new System.Drawing.Point(745, 727);
            this.salvaModifiche.Name = "salvaModifiche";
            this.salvaModifiche.Size = new System.Drawing.Size(148, 47);
            this.salvaModifiche.TabIndex = 8;
            this.salvaModifiche.Text = "Salva";
            this.salvaModifiche.UseVisualStyleBackColor = true;
            this.salvaModifiche.Click += new System.EventHandler(this.salvaModifiche_Click);
            // 
            // Annulla
            // 
            this.Annulla.AccessibleName = "annulla";
            this.Annulla.Location = new System.Drawing.Point(920, 727);
            this.Annulla.Name = "Annulla";
            this.Annulla.Size = new System.Drawing.Size(168, 47);
            this.Annulla.TabIndex = 9;
            this.Annulla.Text = "Annulla";
            this.Annulla.UseVisualStyleBackColor = true;
            this.Annulla.Click += new System.EventHandler(this.Annulla_Click);
            // 
            // radioButtonNo
            // 
            this.radioButtonNo.AutoSize = true;
            this.radioButtonNo.Location = new System.Drawing.Point(128, 609);
            this.radioButtonNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonNo.Name = "radioButtonNo";
            this.radioButtonNo.Size = new System.Drawing.Size(70, 29);
            this.radioButtonNo.TabIndex = 10;
            this.radioButtonNo.TabStop = true;
            this.radioButtonNo.Text = "No";
            this.radioButtonNo.UseVisualStyleBackColor = true;
            this.radioButtonNo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBox_Click);
            // 
            // radioButtonSi
            // 
            this.radioButtonSi.AutoSize = true;
            this.radioButtonSi.Location = new System.Drawing.Point(128, 555);
            this.radioButtonSi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonSi.Name = "radioButtonSi";
            this.radioButtonSi.Size = new System.Drawing.Size(62, 29);
            this.radioButtonSi.TabIndex = 11;
            this.radioButtonSi.TabStop = true;
            this.radioButtonSi.Text = "Si";
            this.radioButtonSi.UseVisualStyleBackColor = true;
            this.radioButtonSi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 31);
            this.label1.TabIndex = 12;
            this.label1.Text = "Credenziali admin";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Nome
            // 
            this.Nome.AccessibleName = "Nome";
            this.Nome.AutoSize = true;
            this.Nome.Location = new System.Drawing.Point(47, 183);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(68, 25);
            this.Nome.TabIndex = 13;
            this.Nome.Text = "Nome";
            // 
            // Cognome
            // 
            this.Cognome.AccessibleName = "Cognome";
            this.Cognome.AutoSize = true;
            this.Cognome.Location = new System.Drawing.Point(47, 249);
            this.Cognome.Name = "Cognome";
            this.Cognome.Size = new System.Drawing.Size(104, 25);
            this.Cognome.TabIndex = 14;
            this.Cognome.Text = "Cognome";
            // 
            // textBoxNome
            // 
            this.textBoxNome.AccessibleName = "nome";
            this.textBoxNome.Location = new System.Drawing.Point(431, 176);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(229, 31);
            this.textBoxNome.TabIndex = 15;
            this.textBoxNome.TextChanged += new System.EventHandler(this.textBoxNome_TextChanged);
            // 
            // textBoxCognome
            // 
            this.textBoxCognome.AccessibleName = "cognome";
            this.textBoxCognome.Location = new System.Drawing.Point(431, 249);
            this.textBoxCognome.Name = "textBoxCognome";
            this.textBoxCognome.Size = new System.Drawing.Size(229, 31);
            this.textBoxCognome.TabIndex = 16;
            this.textBoxCognome.TextChanged += new System.EventHandler(this.textBoxCognome_TextChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 797);
            this.Controls.Add(this.textBoxCognome);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.Cognome);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonSi);
            this.Controls.Add(this.radioButtonNo);
            this.Controls.Add(this.Annulla);
            this.Controls.Add(this.salvaModifiche);
            this.Controls.Add(this.description);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.destinationPath);
            this.Controls.Add(this.defaultPath);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label defaultPath;
        private System.Windows.Forms.Label destinationPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Button salvaModifiche;
        private System.Windows.Forms.Button Annulla;
        private System.Windows.Forms.RadioButton radioButtonNo;
        private System.Windows.Forms.RadioButton radioButtonSi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.Label Cognome;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxCognome;
    }
}