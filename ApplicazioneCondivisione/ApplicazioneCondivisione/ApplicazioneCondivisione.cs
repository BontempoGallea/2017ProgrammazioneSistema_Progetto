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
    public partial class ApplicazioneCondivisione : MetroFramework.Forms.MetroForm
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
            metroLabel4.Text = "Le tue credenziali: ";
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void condividiButton_Click(object sender, EventArgs e)
        {
            if (selectedlist.Count > 0)
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
        MetroFramework.Controls.MetroTile btn;
        int i = 0;
        int j = 0;
        List<MetroFramework.Controls.MetroTile> listBTN = new List<MetroFramework.Controls.MetroTile>();
        List<MetroFramework.Controls.MetroTile> selectedlist = new List<MetroFramework.Controls.MetroTile>();
        private void refresh_Click(object sender, EventArgs e)
        {
            
            btn = new MetroFramework.Controls.MetroTile();
            btn.Location = new Point(60 + i, 150+j);
            btn.Size = new Size(70, 70);
            btn.Name = "BTN";
            btn.Style = MetroFramework.MetroColorStyle.Green;
            btn.Click += new EventHandler(changeState2_Click);
            btn.Text = "ciao";
            listBTN.Add(btn);
            flowLayoutPanel1.Controls.Add(btn);
            i = i + 80;
            if (i > 400)
            {
                i = 0;
                j = j + 80;
            }
           // foreach (MetroFramework.Controls.MetroTile b in listBTN)
          //  {
               // this.Controls.AddRange(new MetroFramework.Controls.MetroTile[] { b });
           // }

        }
        
        private void changeState2_Click(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTile changeState = sender as MetroFramework.Controls.MetroTile;
            if (changeState.Style== MetroFramework.MetroColorStyle.Green)
            {
                selectedlist.Add(changeState);
                changeState.Style = MetroFramework.MetroColorStyle.Blue;
                
            }
            else
            {
                selectedlist.Remove(changeState);
                changeState.Style = MetroFramework.MetroColorStyle.Green;
            }
        }

       
    }
}
