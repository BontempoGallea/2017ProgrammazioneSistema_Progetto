using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicazioneCondivisione 
{
    public partial class SendFile : MetroFramework.Forms.MetroForm
    {
        public SendFile()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            label2.Text = "Percentale inviata: " + progressBar.Value + "%";
            button1.Text = "Interrompi";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
