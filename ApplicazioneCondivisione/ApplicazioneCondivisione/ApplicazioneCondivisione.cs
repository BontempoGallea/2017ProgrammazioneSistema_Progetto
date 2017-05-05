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
        static ListUserHandler luh; // Per gestire la lista di utenti
        static Client client;
        static Server server;
        static Thread serverThread;

        public ApplicazioneCondivisione()
        {
            InitializeComponent();
            this.taskbarIcon.ContextMenuStrip = contextMenuStripTaskbarIcon;

            // Creo il list users handler
            luh = new ListUserHandler();
            luh.listaUsersInit(this);

            // Creo la classe client che verrà fatta girare nel rispettivo thread
            client = new Client(luh);

            // Creo la classe server che verrà fatta girare nel rispettivo thread
            server = new Server(luh);
            serverThread = new Thread(server.entryPoint);
            serverThread.Name = "serverThread";
            serverThread.Start();
        }

        private void applicazioneCondivisione_Load(object sender, EventArgs e)
        {
            Person ciao = new Person("marica", "messina", "online", "222.11.11.11", "2343");
            luh.addUser(ciao);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (2 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            metroLabel4.Text = "Le tue credenziali: ";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            luh.clean();
            luh.refreshButtonClick();
            
        }

        private void condividiButton_Click(object sender, EventArgs e)
        {
            luh.condividiButtonClick(client);
        }

        private void annullaButton_Click(object sender, EventArgs e)
        {
            base.SetVisibleCore(false);
            this.WindowState = FormWindowState.Minimized;
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
            luh.changeAdminState("offline");
        }

        private void onlineOptionIconContextMenu_Click(object sender, EventArgs e)
        {
            luh.changeAdminState("online");
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            server.closeAllThreads();
            serverThread.Abort();
            Application.Exit();
        }

        private void apriOptionIconContextMenu_Click(object sender, EventArgs e)
        {
            base.SetVisibleCore(true);
            this.WindowState = FormWindowState.Normal;
        }
    }
}
