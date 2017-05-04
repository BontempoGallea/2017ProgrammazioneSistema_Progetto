using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneCondivisione
{
    public class Person
    {
        /*
         * Classe per descrivere un utente
        */
        
        private string nome;
        private string cognome;
        private string stato;
        private IPAddress ip;
        private int port;
        private bool imNew;

        public Person(string n, string c, string s, string ip, string port)
        {
            this.nome = n;
            this.cognome = c;
            this.stato = s;
            this.imNew = true;
            this.ip = IPAddress.Parse(ip);
            this.port = int.Parse(port);
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
    }
}
