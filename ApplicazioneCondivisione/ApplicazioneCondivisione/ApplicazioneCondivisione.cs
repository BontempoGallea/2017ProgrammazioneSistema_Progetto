﻿using System;
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

            // Associa il menu alla tray icon nella taskbar, per quando clicchi con il tasto destro
            this.taskbarIcon.ContextMenuStrip = contextMenuStripTaskbarIcon;

            // Associo le credenziali dell'admin, ossia dove si sta facendo girare l'applicazione
            metroLabel4.Text = "Le tue credenziali: ";
            name.Text = Program.luh.getAdmin().getName();
            surname.Text = Program.luh.getAdmin().getSurname();
            state.Text = Program.luh.getAdmin().getState();

            // Setto il colore iniziale del bottone di cambio stato
            if (Program.luh.getAdminState().CompareTo("online") == 0)
                changeState.Style = MetroFramework.MetroColorStyle.Green;
            else
                changeState.Style = MetroFramework.MetroColorStyle.Red;

            // Setto il colore di sfondo del refresh button
            refreshButton.Style = MetroFramework.MetroColorStyle.White;

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
            Program.timer.Interval = (2 * 1000); // 2 secs
            Program.timer.Tick += new EventHandler(timer_Tick);
            Program.timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Program.luh.clean();
            Program.luh.refreshButtonClick();
        }

        private void condividiButton_Click(object sender, EventArgs e)
        {
            Program.luh.condividiButtonClick();
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
            this.timer_Tick(sender,e);

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
