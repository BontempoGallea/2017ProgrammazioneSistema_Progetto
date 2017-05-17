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
            this.SuspendLayout();
            // 
            // defaultPath
            // 
            this.defaultPath.AutoSize = true;
            this.defaultPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultPath.Location = new System.Drawing.Point(31, 166);
            this.defaultPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.defaultPath.Name = "defaultPath";
            this.defaultPath.Size = new System.Drawing.Size(396, 39);
            this.defaultPath.TabIndex = 1;
            this.defaultPath.Text = "Cartella di destinazione";
            this.defaultPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // destinationPath
            // 
            this.destinationPath.AccessibleName = "destinationPath";
            this.destinationPath.AutoSize = true;
            this.destinationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationPath.Location = new System.Drawing.Point(31, 258);
            this.destinationPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.destinationPath.Name = "destinationPath";
            this.destinationPath.Size = new System.Drawing.Size(0, 31);
            this.destinationPath.TabIndex = 2;
            this.destinationPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 386);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(530, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Salvataggio automatico dei file?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.AccessibleName = "browse";
            this.button1.Location = new System.Drawing.Point(800, 258);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 51);
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
            this.description.Location = new System.Drawing.Point(427, 465);
            this.description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(0, 31);
            this.description.TabIndex = 7;
            this.description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // salvaModifiche
            // 
            this.salvaModifiche.AccessibleName = "salvaModifiche";
            this.salvaModifiche.Location = new System.Drawing.Point(544, 641);
            this.salvaModifiche.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.salvaModifiche.Name = "salvaModifiche";
            this.salvaModifiche.Size = new System.Drawing.Size(224, 79);
            this.salvaModifiche.TabIndex = 8;
            this.salvaModifiche.Text = "Salva";
            this.salvaModifiche.UseVisualStyleBackColor = true;
            this.salvaModifiche.Click += new System.EventHandler(this.salvaModifiche_Click);
            // 
            // Annulla
            // 
            this.Annulla.AccessibleName = "annulla";
            this.Annulla.Location = new System.Drawing.Point(800, 641);
            this.Annulla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Annulla.Name = "Annulla";
            this.Annulla.Size = new System.Drawing.Size(224, 79);
            this.Annulla.TabIndex = 9;
            this.Annulla.Text = "Annulla";
            this.Annulla.UseVisualStyleBackColor = true;
            this.Annulla.Click += new System.EventHandler(this.Annulla_Click);
            // 
            // radioButtonNo
            // 
            this.radioButtonNo.AutoSize = true;
            this.radioButtonNo.Location = new System.Drawing.Point(172, 532);
            this.radioButtonNo.Name = "radioButtonNo";
            this.radioButtonNo.Size = new System.Drawing.Size(84, 36);
            this.radioButtonNo.TabIndex = 10;
            this.radioButtonNo.TabStop = true;
            this.radioButtonNo.Text = "no";
            this.radioButtonNo.UseVisualStyleBackColor = true;
            // 
            // radioButtonSi
            // 
            this.radioButtonSi.AutoSize = true;
            this.radioButtonSi.Location = new System.Drawing.Point(172, 465);
            this.radioButtonSi.Name = "radioButtonSi";
            this.radioButtonSi.Size = new System.Drawing.Size(73, 36);
            this.radioButtonSi.TabIndex = 11;
            this.radioButtonSi.TabStop = true;
            this.radioButtonSi.Text = "si";
            this.radioButtonSi.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 749);
            this.Controls.Add(this.radioButtonSi);
            this.Controls.Add(this.radioButtonNo);
            this.Controls.Add(this.Annulla);
            this.Controls.Add(this.salvaModifiche);
            this.Controls.Add(this.description);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.destinationPath);
            this.Controls.Add(this.defaultPath);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Settings";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
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
    }
}