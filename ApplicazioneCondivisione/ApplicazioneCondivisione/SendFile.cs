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
    public partial class SendFile : Form
    {
        public SendFile()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            label2.Text = "Percentale inviata: " + progressBar1.Value + "%";
            button1.Text = "Interrompi";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void sendFile()
        {
            while(progressBar1.Value < 100) {
                progressBar1.Value = progressBar1.Value + 1;
                label2.Text = "Percentale inviata: " + progressBar1.Value + "%";
            }

            button1.Text = "Fine";
        }
    }
}
