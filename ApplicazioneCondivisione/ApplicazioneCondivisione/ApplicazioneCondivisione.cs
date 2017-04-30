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
    public partial class ApplicazioneCondivisione : Form
    {
        private Person p1 = new Person("Eugenio", "Gallea", "offline");
        private Person p2 = new Person("Gianpaolo", "Bontempo", "Online");
        private Person admin = new Person("Mario", "Rossi", "Offline");

        public ApplicazioneCondivisione()
        {
            InitializeComponent();
        }

        private void applicazioneCondivisione_Load(object sender, EventArgs e)
        {
            int w = listaUsers.Width / 5;
            
            listaUsers.View = View.Details;
            imageList1.ImageSize = new Size(32, 32);

            imageList1.Images.Add("key", Image.FromFile("C:\\ProgramData\\Microsoft\\User Account Pictures\\user.bmp"));
            listaUsers.Columns.Add("Nome", w*2, HorizontalAlignment.Center);
            listaUsers.Columns.Add("Cognome", w*2, HorizontalAlignment.Center);
            listaUsers.Columns.Add("Stato", w, HorizontalAlignment.Center);
            listaUsers.CheckBoxes = true;

            var item1 = new ListViewItem(new[] { p1.getNome(), p1.getCognome(), p1.getStato() });
            var item2 = new ListViewItem(new[] { p2.getNome(), p2.getCognome(), p2.getStato() });

            listaUsers.Items.Add(item1);
            listaUsers.Items.Add(item2);
            listaUsers.StateImageList = this.imageList1;
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void condividiButton_Click(object sender, EventArgs e)
        {
            if (listaUsers.SelectedIndices.Count > 0)
            {
                SendFile f2 = new SendFile();
                f2.Show();
                f2.sendFile();
            }
            else
            {
                MessageBox.Show("Non ha selezionato nessun utente!");
            }
        }

        private void annullaButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void applicazioneCondivisione_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                ShowIcon = true;
                ShowInTaskbar = false;
                taskbarIcon.Visible = true;
                taskbarIcon.ShowBalloonTip(500);
            }
        }

        private void taskbarIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            taskbarIcon.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void apriApplicazioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            taskbarIcon.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }
    }
}
