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
        private ListUserHandler luh;

        public ApplicazioneCondivisione()
        {
            InitializeComponent();
            luh = new ListUserHandler();
        }

        private void applicazioneCondivisione_Load(object sender, EventArgs e)
        {
            luh.listaUsersInit(this);
            taskbarIcon.ContextMenuStrip = this.iconContextMenu;
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void condividiButton_Click(object sender, EventArgs e)
        {
            if (listaUsers.CheckedIndices.Count > 0)
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
