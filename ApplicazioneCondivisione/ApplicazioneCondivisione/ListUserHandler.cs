using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ApplicazioneCondivisione
{
    class ListUserHandler
    {
        /*
         * Questa è la classe che si occupa di gestire la lista degli utenti attivi nella nostra LAN.  
        */
        private Person admin; // Dove sta girando l'applicazione
        private ApplicazioneCondivisione frame; // Il frame della UI
        private Dictionary<string,Person> users; // Lista degli utenti attivi dai quali ho ricevuto l'online
        private int lastRefresh; // Lunghezza della lista, l'ultima volta che ho fatto refresh
        private Dictionary<string, Person> personeselezionate = new Dictionary<string, Person>();
        private MetroFramework.Controls.MetroTile btn; // Bottone per selezionare il tale utente
        private List<MetroFramework.Controls.MetroTile> listBTN = new List<MetroFramework.Controls.MetroTile>();
        private List<MetroFramework.Controls.MetroTile> selectedlist = new List<MetroFramework.Controls.MetroTile>();

        public ListUserHandler()
        {
            users = new Dictionary<string, Person>();
            lastRefresh = -1;
<<<<<<< HEAD
            admin = new Person("gianpaolo", "Bontempo", "online", GetLocalIPAddress(), "3000");
=======
            admin = new Person("Luca", "Rossi", "online", GetLocalIPAddress(), "3000");
>>>>>>> refs/remotes/origin/master
        }

        public void listaUsersInit(ApplicazioneCondivisione f)
        {
            /*
             * Funzione per inizializzare l'handler della lista di utenti
             * 1) mi salvo il frame dell UI
             * 2) salvo il mio admin
            */ 

            this.frame = f;
<<<<<<< HEAD

           
=======
>>>>>>> refs/remotes/origin/master
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

        public Dictionary<String,Person> getlist() { return users; }

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
                try
                {
                    foreach (Person p in users.Values)
                    {
                        if (p.isNew())
                        {
                            //Controllo se l'utente è una nuova aggiunta o meno
                            p.setOld(); //Setto l'utente come OLD, ossia uno che è già stato visualizzato nella UI
                            btn = new MetroFramework.Controls.MetroTile();
                            btn.Size = new Size(70, 70);
                            btn.Name = p.getNome() + "," + p.getCognome() + "," + p.getIp() + "," + p.getPort();
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
                }catch(Exception e) {
                    Console.WriteLine(e.ToString());
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

        public void condividiButtonClick(Client c)
        {
            /*
             * Funzione che gestisce gli eventi di quando si clicca il pulsante per la condivisione
            */

            if (selectedlist.Count > 0)
            {
                SendFile sd = new SendFile();

                foreach(MetroFramework.Controls.MetroTile m in selectedlist)
                {
                    Thread clientThread = new Thread(() => c.entryPoint(m.Name));
                    clientThread.Start();
                    clientThread.Join();

                    sd.progressBar.Value += 100 / selectedlist.Count; 
                }
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
            if(!users.ContainsKey(p.getCognome()+p.getNome()))
            users.Add(p.getCognome() + p.getNome(), p);
        }

        public Person getAdmin()
        {
            return admin;
        }

        public static string GetLocalIPAddress()
        {
            /*
             * Funzione per trovare il mio indirizzo IPv4
             */

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("indirizzo non trovato");
        }
    }
}
