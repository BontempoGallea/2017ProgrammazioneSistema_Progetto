using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicazioneCondivisione
{
    class ListUserHandler
    {
        private Person admin = new Person("Mario", "Rossi", "offline");
        private ApplicazioneCondivisione frame;
        private List<Person> users;
        private int lastRefresh;

        private MetroFramework.Controls.MetroTile btn;
        private int i = 0;
        private int j = 0;
        private List<MetroFramework.Controls.MetroTile> listBTN = new List<MetroFramework.Controls.MetroTile>();
        private List<MetroFramework.Controls.MetroTile> selectedlist = new List<MetroFramework.Controls.MetroTile>();

        public ListUserHandler()
        {
            users = new List<Person>();
            lastRefresh = 0;
        }

        public void listaUsersInit(ApplicazioneCondivisione f)
        {
            this.frame = f;

            users.Add(new Person("Eugenio", "Gallea", "offline"));
            users.Add(new Person("Gianpaolo", "Bontempo", "online"));

            f.nome.Text = admin.getNome();
            f.cognome.Text = admin.getCognome();
            f.stato.Text = admin.getStato();
        }

        public void changeAdminState(string s)
        {
            this.admin.setStato(s);
            frame.stato.Text = s;
        }

        public string getAdminState()
        {
            return this.admin.getStato();
        }

        public void refreshButtonClick()
        {
            int l = users.Count();

            if (l > lastRefresh)
            {
                foreach (Person p in users)
                {
                    btn = new MetroFramework.Controls.MetroTile();
                    btn.Size = new Size(70, 70);
                    btn.Name = "BTN";
                    btn.Style = MetroFramework.MetroColorStyle.Green;
                    btn.Click += new EventHandler(changeState2_Click);
                    btn.Text = p.getNome() + "\n" + p.getCognome();
                    btn.TileImage = Image.FromFile("C:\\ProgramData\\Microsoft\\User Account Pictures\\user-32.png");
                    btn.TileImageAlign = ContentAlignment.TopCenter;
                    btn.UseTileImage = true;
                    
                    listBTN.Add(btn);
                    frame.flowLayoutPanel1.Controls.Add(btn);
                }

                lastRefresh = l;
            }
        }

        private void changeState2_Click(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTile changeState = sender as MetroFramework.Controls.MetroTile;
            if (changeState.Style == MetroFramework.MetroColorStyle.Green)
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

        public void condividiButtonClick()
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
    }
}
