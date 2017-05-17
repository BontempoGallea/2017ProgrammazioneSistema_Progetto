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
            this.checkBoxYes = new System.Windows.Forms.CheckBox();
            this.checkBoxNo = new System.Windows.Forms.CheckBox();
            this.description = new System.Windows.Forms.Label();
            this.salvaModifiche = new System.Windows.Forms.Button();
            this.Annulla = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // defaultPath
            // 
            this.defaultPath.AutoSize = true;
            this.defaultPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultPath.Location = new System.Drawing.Point(23, 134);
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
            this.destinationPath.Location = new System.Drawing.Point(23, 208);
            this.destinationPath.Name = "destinationPath";
            this.destinationPath.Size = new System.Drawing.Size(0, 25);
            this.destinationPath.TabIndex = 2;
            this.destinationPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Salvataggio automatico dei file?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.AccessibleName = "browse";
            this.button1.Location = new System.Drawing.Point(600, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Sfoglia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // checkBoxYes
            // 
            this.checkBoxYes.AccessibleName = "checkBoxYes";
            this.checkBoxYes.AutoSize = true;
            this.checkBoxYes.Location = new System.Drawing.Point(139, 375);
            this.checkBoxYes.Name = "checkBoxYes";
            this.checkBoxYes.Size = new System.Drawing.Size(63, 29);
            this.checkBoxYes.TabIndex = 5;
            this.checkBoxYes.Text = "Sì";
            this.checkBoxYes.UseVisualStyleBackColor = true;
            // 
            // checkBoxNo
            // 
            this.checkBoxNo.AccessibleName = "checkBoxNo";
            this.checkBoxNo.AutoSize = true;
            this.checkBoxNo.Location = new System.Drawing.Point(139, 429);
            this.checkBoxNo.Name = "checkBoxNo";
            this.checkBoxNo.Size = new System.Drawing.Size(71, 29);
            this.checkBoxNo.TabIndex = 6;
            this.checkBoxNo.Text = "No";
            this.checkBoxNo.UseVisualStyleBackColor = true;
            // 
            // description
            // 
            this.description.AccessibleName = "description";
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(320, 375);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(0, 25);
            this.description.TabIndex = 7;
            this.description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // salvaModifiche
            // 
            this.salvaModifiche.AccessibleName = "salvaModifiche";
            this.salvaModifiche.Location = new System.Drawing.Point(408, 517);
            this.salvaModifiche.Name = "salvaModifiche";
            this.salvaModifiche.Size = new System.Drawing.Size(168, 64);
            this.salvaModifiche.TabIndex = 8;
            this.salvaModifiche.Text = "Salva";
            this.salvaModifiche.UseVisualStyleBackColor = true;
            this.salvaModifiche.Click += new System.EventHandler(this.salvaModifiche_Click);
            // 
            // Annulla
            // 
            this.Annulla.AccessibleName = "annulla";
            this.Annulla.Location = new System.Drawing.Point(600, 517);
            this.Annulla.Name = "Annulla";
            this.Annulla.Size = new System.Drawing.Size(168, 64);
            this.Annulla.TabIndex = 9;
            this.Annulla.Text = "Annulla";
            this.Annulla.UseVisualStyleBackColor = true;
            this.Annulla.Click += new System.EventHandler(this.Annulla_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 604);
            this.Controls.Add(this.Annulla);
            this.Controls.Add(this.salvaModifiche);
            this.Controls.Add(this.description);
            this.Controls.Add(this.checkBoxNo);
            this.Controls.Add(this.checkBoxYes);
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
        private System.Windows.Forms.CheckBox checkBoxYes;
        private System.Windows.Forms.CheckBox checkBoxNo;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Button salvaModifiche;
        private System.Windows.Forms.Button Annulla;
    }
}