using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace ApplicazioneCondivisione
{
    public class Person
    {
        /*
         * Classe per descrivere un utente
        */
        private bool isold;// bool per sapere se la persona sta ancora inviando pacchetti
        private string nome;//nome
        private string cognome;
        private string stato;
        private IPAddress ip;
        private int port;
        private bool imNew;//boot per sapere se la persona ha gia un metrotile in flowlayout
        private System.Timers.Timer t;//timer che se scade imposta isold a true
        private ListUserHandler luh;
        private MetroTile a;
       
        public Person(string n, string c, string s, string ip, string port)
        {
            t = new System.Timers.Timer(5000);//timer impostato ogni tot sec
            this.nome = n;
            this.cognome = c;
            this.stato = s;
            this.imNew = true;
            this.ip = IPAddress.Parse(ip);
            this.port = int.Parse(port);
            t.Elapsed +=  Ontimeelapse;
            t.AutoReset = true;
            t.Start();
        }
      
        public void reset()
        {
            t.Stop();
            isold = false;
            t.Start();
        }

        private void Ontimeelapse(object sender, System.Timers.ElapsedEventArgs e)
        {
            //metodo chiamato alla scadenza del timer della persona
                isold = true;
                t.Stop();//fermo il timer
                t.Start();//faccio ripartire il timer da 0
        }

        public string getNome()
        {
            return nome;
        }

        public void setNome(string n)
        {
            this.nome = n;
        }

        public string getCognome()
        {
            return this.cognome;
        }

        public void setCognome(string c)
        {
            this.cognome = c;
        }

        public string getStato()
        {
            return this.stato;
        }

        public void setStato(string s)
        {
            this.stato = s;
        }

        public bool isNew()
        {
            // L'utente è una nuova aggiunta?
            return imNew;
        }

        public  bool old()
        {
            return isold;
        }

        public void setOld()
        {
            // L'utente non è più una nuova aggiunta
            imNew = false;
        }

        public IPAddress getIp()
        {
            return ip;
        }

        public int getPort()
        {
            return port;
        }

        public bool isOnline()
        {
            if (stato.Equals("online"))
                return true;
            else
                return false;
        }

        public string getString()
        {
            return nome + "," + cognome + "," + stato + "," + ip.ToString() + "," + port;
        }

        public bool isEqual(Person p)
        {
            return (p.getCognome().CompareTo(cognome) == 0) 
                && (p.getNome().CompareTo(nome) == 0) 
                && (p.getIp().ToString().CompareTo(ip.ToString()) == 0) 
                && (p.getPort() == port);
        }

        internal void addbotton(MetroTile btn)
        {
            a = btn;
        }

        internal MetroTile getbotton()
        {
            return a;
            throw new NotImplementedException();
        }
    }
}
