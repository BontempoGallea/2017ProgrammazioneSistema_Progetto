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
            metroProgressBar1.Value = 0;
            label2.Text = "Percentale inviata: " + metroProgressBar1.Value + "%";
            button1.Text = "Interrompi";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void sendFile()
        {
            while(metroProgressBar1.Value < 100) {
                metroProgressBar1.Value = metroProgressBar1.Value + 1;
                label2.Text = "Percentale inviata: " + metroProgressBar1.Value + "%";
            }

           button1.Text = "Fine";
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
