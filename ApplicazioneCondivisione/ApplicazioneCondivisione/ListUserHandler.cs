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
        private Dictionary<string,Person> users; // Lista degli utenti attivi dai quali ho ricevuto l'online
        private int lastRefresh; // Lunghezza della lista, l'ultima volta che ho fatto refresh
        private Dictionary<string, Person> selectedUsers = new Dictionary<string, Person>();
        private MetroFramework.Controls.MetroTile btn; // Bottone per selezionare il tale utente
        private List<MetroFramework.Controls.MetroTile> listBTN = new List<MetroFramework.Controls.MetroTile>();
        private List<MetroFramework.Controls.MetroTile> selectedList = new List<MetroFramework.Controls.MetroTile>();

        public ListUserHandler()
        {
            users = new Dictionary<string, Person>();
            lastRefresh = -1;

            admin = new Person("Eugenio", "Gallea", "online", getLocalIPAddress(), "3000");
        }

        public void listaUsersInit()
        {
            /*
             * Funzione per inizializzare l'handler della lista di utenti
             * 1) mi salvo il frame dell UI
             * 2) salvo il mio admin
            */ 
            Program.ac.name.Text = admin.getName();
            Program.ac.surname.Text = admin.getSurname();
            Program.ac.state.Text = admin.getState();
        }

        public void changeAdminState(string s)
        {
            /*
             * Funzione per settare lo stato dell'admin
            */ 
            this.admin.setState(s);
            Program.ac.state.Text = s;
        }

        internal void clean()
        {
            Dictionary<string, Person>.ValueCollection values = users.Values;
            try
            {
                foreach (Person p in values)
                {
                    var isnew = p.isNew();
                    var old = p.old();
                    if (old)
                    {
                       // users.Remove(p.getCognome() + p.getNome());
                        if (!isnew)
                        {

                            Program.ac.flowLayoutPanel1.Controls.Remove(p.getButton());
                        }
                    }
                    if ((p.getState().CompareTo( "offline")==0)&&(!isnew))
                    {
                        Program.ac.flowLayoutPanel1.Controls.Remove(p.getButton());
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public Dictionary<String,Person> getlist() { return users; }

        public string getAdminState()
        {
            /*
             * Funzione per ritornare lo stato dell'admin
            */ 
            return this.admin.getState();
        }

        public void refreshButtonClick()
        {
            /*
             * Funzione che gestisce gli eventi quando si clicca il refresh button
            */
            int l = users.Count(); // Lunghezza attuale della lista, dopo il click
            if ((l > lastRefresh))
            {
                // Entro qui se la lunghezza è aumentata, che vuol dire che sono stati aggiunti altri
                // utenti.
                try
                {
                    Dictionary<string,Person>.ValueCollection values = users.Values;
                    foreach (Person p in values)
                    {
                        if (p.isNew())
                        {
                            p.setOld();
                                btn = new MetroFramework.Controls.MetroTile();
                                btn.Size = new Size(70, 70);
                                btn.Name = p.getName() + "," + p.getSurname() + "," + p.getIp() + "," + p.getPort();
                                btn.Style = MetroFramework.MetroColorStyle.Green;
                                btn.Click += new EventHandler(changeState2_Click);
                                btn.Text = p.getName() + "\n" + p.getSurname();
                                btn.TileImage = Image.FromFile("C:\\ProgramData\\Microsoft\\User Account Pictures\\user-32.png");
                                btn.TileImageAlign = ContentAlignment.TopCenter;
                                btn.UseTileImage = true;

                                listBTN.Add(btn);
                                p.addButton(btn);
                                Program.ac.flowLayoutPanel1.Controls.Add(btn);
                        }
                    }
                }catch(Exception e) {
                    Console.WriteLine(e.ToString());
                }
                lastRefresh = l; //Aggiorno la lunghezza della lista all'ultimo refresh
            }
        }

        internal void resettimer(string v)
        {
            Person a;
            users.TryGetValue(v,out a);
            a.reset();
        }

        internal bool ispresent(string v)
        {
            return users.ContainsKey(v);
            throw new NotImplementedException();
        }

        private void changeState2_Click(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTile changeState = sender as MetroFramework.Controls.MetroTile;
            if (changeState.Style == MetroFramework.MetroColorStyle.Green)
            {
                selectedList.Add(changeState);
                changeState.Style = MetroFramework.MetroColorStyle.Blue;
            }
            else
            {
                selectedList.Remove(changeState);
                changeState.Style = MetroFramework.MetroColorStyle.Green;
            }
        }

        public void condividiButtonClick(Client c)
        {
            /*
             * Funzione che gestisce gli eventi di quando si clicca il pulsante per la condivisione
            */

            if (selectedList.Count > 0)
            {
                SendFile sd = new SendFile();

                foreach(MetroFramework.Controls.MetroTile m in selectedList)
                {
                    Thread clientThread = new Thread(() => c.entryPoint(m.Name));
                    clientThread.Start();
                    clientThread.Join();

                    sd.progressBar.Value += 100 / selectedList.Count; 
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
            if(!users.ContainsKey(p.getSurname()+p.getName()))
            users.Add(p.getSurname() + p.getName(), p);
        }

        public Person getAdmin()
        {
            return admin;
        }

        public static string getLocalIPAddress()
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
