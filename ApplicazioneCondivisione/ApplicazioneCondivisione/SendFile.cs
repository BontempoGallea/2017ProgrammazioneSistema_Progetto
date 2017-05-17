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
            // Setto il testo della finestra
            this.Text = "Invio in corso...";

            // Setto opzioni della barra di caricamento
            progressBar.Value = 0;
            progressBar.Text = progressBar.Value.ToString();

            // Setto il bottone per annullare
            button1.Text = "Interrompi";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.AnnullaBoolean = true;
            this.Close();
        }
    }
}
