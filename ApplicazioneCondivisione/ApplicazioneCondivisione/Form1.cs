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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Person p1 = new Person("Eugenio", "Gallea", "online");
            Person p2 = new Person("GianPaolo", "Bontempo", "online");

            int w = listView1.Width / 5;

            listView1.View = View.Details;

            listView1.Columns.Add("Nome", w*2, HorizontalAlignment.Center);
            listView1.Columns.Add("Cognome", w*2, HorizontalAlignment.Center);
            listView1.Columns.Add("Stato", w, HorizontalAlignment.Center);
            listView1.CheckBoxes = true;

            var item1 = new ListViewItem(new[] { p1.getNome(), p1.getCognome(), p1.getStato() });
            var item2 = new ListViewItem(new[] { p2.getNome(), p2.getCognome(), p2.getStato() });

            listView1.Items.Add(item1);
            listView1.Items.Add(item2);
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
