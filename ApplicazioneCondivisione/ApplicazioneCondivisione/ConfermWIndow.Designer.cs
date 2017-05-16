namespace ApplicazioneCondivisione
{
    partial class ConfermWIndow
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 126);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(84, 20);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "metroLabel1";
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(547, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(207, 82);
            this.button1.TabIndex = 1;
            this.button1.Text = "annulla";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(161, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(215, 82);
            this.button2.TabIndex = 2;
            this.button2.Text = "ok";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ConfermWIndow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 461);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.metroLabel1);
            this.Name = "ConfermWIndow";
            this.Text = "conferma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}