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

namespace ApplicazioneCondivisione
{
    public partial class ApplicazioneCondivisione : MetroFramework.Forms.MetroForm
    {
        static ListUserHandler luh; // Per gestire la lista di utenti
        static Client client;
        static Server server;
        private bool allowVisible;     // ContextMenu's Show command used
        private bool allowClose;       // ContextMenu's Exit command used

        public ApplicazioneCondivisione()
        {
            /*
             * Per settare tutte la situazione iniziale di user interface e dei thread per client
             * e server.
            */
            
            InitializeComponent();
            taskbarIcon.ContextMenuStrip = iconContextMenu;
            
            ShowInTaskbar = false;
            taskbarIcon.Visible = true;

            // Creo il list users handler
            luh = new ListUserHandler();
            luh.listaUsersInit(this);

            // Creo la classe client che verrà fatta girare nel rispettivo thread
            client = new Client(luh);

            // Creo la classe server che verrà fatta girare nel rispettivo thread
            server = new Server(luh);
            Thread serverThread = new Thread(server.entryPoint);
            serverThread.Name = "serverThread";
            serverThread.Start();
        }

        private void applicazioneCondivisione_Load(object sender, EventArgs e)
        {
            /*
             * Funzione che setta l'aspetto della UI quando viene fatta partire
            */
            
            taskbarIcon.ContextMenuStrip = this.iconContextMenu;
            metroLabel4.Text = "Le tue credenziali: ";
            this.WindowState = FormWindowState.Minimized;
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void condividiButton_Click(object sender, EventArgs e)
        {
            luh.condividiButtonClick(client);
        }

        private void annullaButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void esciOptionIconContextMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void offlineOptionIconContextMenu_Click(object sender, EventArgs e)
        {
            luh.changeAdminState("offline");
        }

        private void onlineOptionIconContextMenu_Click(object sender, EventArgs e)
        {
            luh.changeAdminState("online");
        }

        private void changeState_Click(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTile changeState = sender as MetroFramework.Controls.MetroTile;
            if (luh.getAdminState().Equals("online"))
            {
                luh.changeAdminState("offline");
                changeState.Style = MetroFramework.MetroColorStyle.Red;
            }
            else
            {
                luh.changeAdminState("online");
                changeState.Style = MetroFramework.MetroColorStyle.Green;
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            luh.refreshButtonClick();
        }

        private void apriApplicazione_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            taskbarIcon.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }
    }
}
