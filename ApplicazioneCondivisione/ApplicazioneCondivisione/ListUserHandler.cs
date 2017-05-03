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
        /*
         * Questa è la classe che si occupa di gestire la lista degli utenti attivi nella nostra LAN.  
        */
        private Person admin = new Person("Mario", "Rossi", "offline"); // Dove sta girando l'applicazione
        private ApplicazioneCondivisione frame; // Il frame della UI
        private List<Person> users; // Lista degli utenti attivi dai quali ho ricevuto l'online
        private int lastRefresh; // Lunghezza della lista, l'ultima volta che ho fatto refresh

        private MetroFramework.Controls.MetroTile btn; // Bottone per selezionare il tale utente
        private int i = 0;
        private int j = 0;
        private List<MetroFramework.Controls.MetroTile> listBTN = new List<MetroFramework.Controls.MetroTile>();
        private List<MetroFramework.Controls.MetroTile> selectedlist = new List<MetroFramework.Controls.MetroTile>();

        public ListUserHandler()
        {
            users = new List<Person>();
            lastRefresh = -1;
        }

        public void listaUsersInit(ApplicazioneCondivisione f)
        {
            /*
             * Funzione per inizializzare l'handler della lista di utenti
             * 1) mi salvo il frame dell UI
             * 2) salvo il mio admin
            */ 

            this.frame = f;

            users.Add(new Person("Eugenio", "Gallea", "offline"));
            users.Add(new Person("Gianpaolo", "Bontempo", "online"));

            f.nome.Text = admin.getNome();
            f.cognome.Text = admin.getCognome();
            f.stato.Text = admin.getStato();
        }

        public void changeAdminState(string s)
        {
            /*
             * Funzione per settare lo stato dell'admin
            */ 
            this.admin.setStato(s);
            frame.stato.Text = s;
        }

        public string getAdminState()
        {
            /*
             * Funzione per ritornare lo stato dell'admin
            */ 
            return this.admin.getStato();
        }

        public void refreshButtonClick()
        {
            /*
             * Funzione che gestisce gli eventi quando si clicca il refresh button
            */
            
            int l = users.Count(); // Lunghezza attuale della lista, dopo il click

            if (l > lastRefresh)
            {
                // Entro qui se la lunghezza è aumentata, che vuol dire che sono stati aggiunti altri
                // utenti.
                foreach(Person p in users)
                {
                    if (p.isNew())
                    {
                        //Controllo se l'utente è una nuova aggiunta o meno
                        p.setOld(); //Setto l'utente come OLD, ossia uno che è già stato visualizzato nella UI
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
                }

                lastRefresh = l; //Aggiorno la lunghezza della lista all'ultimo refresh
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
            /*
             * Funzione che gestisce gli eventi di quando si clicca il pulsante per la condivisione
            */
            
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

        public void addUser(Person p)
        {
            /*
             * Funzione per aggiungere un utente alla lista degli user
            */
            
            users.Add(p);
        }
    }
}
