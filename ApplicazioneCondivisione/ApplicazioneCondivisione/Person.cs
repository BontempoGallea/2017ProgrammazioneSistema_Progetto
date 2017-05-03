using System;
using System.Collections.Generic;
using System.Linq;
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
        private bool imNew;

        public Person(string n, string c, string s)
        {
            this.nome = n;
            this.cognome = c;
            this.stato = s;
            this.imNew = true;
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
    }
}
