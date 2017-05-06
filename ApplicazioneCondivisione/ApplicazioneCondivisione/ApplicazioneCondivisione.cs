using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;

namespace ApplicazioneCondivisione
{
    public partial class ApplicazioneCondivisione : MetroFramework.Forms.MetroForm
    {
        public ApplicazioneCondivisione()
        {
            InitializeComponent();
            this.taskbarIcon.ContextMenuStrip = contextMenuStripTaskbarIcon;
            name.Text = Program.luh.getAdmin().getName();
            surname.Text = Program.luh.getAdmin().getSurname();
            state.Text = Program.luh.getAdmin().getState();

            /* Codice ancora da controllare per l'aggiunta dell'opzione al context menu di Windows
             * Ci sono problemi per quanto riguarda l'accesso e la sicurezza ai registri di sistema...Bah!
            RegistryKey key;
            key = Registry.ClassesRoot.CreateSubKey("HKEY_CLASSES_ROOT\\*\\shellex\\ContextMenuHandlers\\MOH");
            key = Registry.ClassesRoot.CreateSubKey("HKEY_CLASSES_ROOT\\*\\shellex\\ContextMenuHandlers\\MOH\\command");
            key.SetValue("", Application.ExecutablePath);
            */
        }

        private void applicazioneCondivisione_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (2 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            metroLabel4.Text = "Le tue credenziali: ";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Program.luh.clean();
            Program.luh.refreshButtonClick();
        }

        private void condividiButton_Click(object sender, EventArgs e)
        {
            Program.luh.condividiButtonClick(Program.client);
        }

        private void annullaButton_Click(object sender, EventArgs e)
        {
            base.SetVisibleCore(false);
            this.WindowState = FormWindowState.Minimized;
        }

        private void changeState_Click(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTile changeState = sender as MetroFramework.Controls.MetroTile;
            if (Program.luh.getAdminState().Equals("online"))
            {
                Program.luh.changeAdminState("offline");
                changeState.Style = MetroFramework.MetroColorStyle.Red;
            }
            else
            {
                Program.luh.changeAdminState("online");
                changeState.Style = MetroFramework.MetroColorStyle.Green;
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Program.luh.refreshButtonClick();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(false);
        }

        private void taskbarIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            base.SetVisibleCore(true);
            this.WindowState = FormWindowState.Normal;
        }

        private void esciOptionIconContextMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void offlineOptionIconContextMenu_Click(object sender, EventArgs e)
        {
            Program.luh.changeAdminState("offline");
        }

        private void onlineOptionIconContextMenu_Click(object sender, EventArgs e)
        {
            Program.luh.changeAdminState("online");
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.server.closeAllThreads();
            Program.serverThread.Abort();
            Application.Exit();
        }

        private void apriOptionIconContextMenu_Click(object sender, EventArgs e)
        {
            base.SetVisibleCore(true);
            this.WindowState = FormWindowState.Normal;
        }
    }
}
