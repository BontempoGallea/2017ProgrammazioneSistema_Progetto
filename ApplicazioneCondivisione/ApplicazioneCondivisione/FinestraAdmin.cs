using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicazioneCondivisione
{
    public partial class finestraadmin : MetroFramework.Forms.MetroForm
    {
        public finestraadmin()
        {
            InitializeComponent();
        }




        public string nome;
        public string cognome;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            nome = textbox.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            cognome = textbox.Text;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Program.luh.setadmin(nome, cognome);
            Program.ac.name.Text = nome;
            Program.ac.surname.Text = cognome;
            this.Close();

        }
    }
}
