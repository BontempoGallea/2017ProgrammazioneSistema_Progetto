using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicazioneCondivisione
{
    class ListUserHandler
    {
        private Person admin = new Person("Mario", "Rossi", "offline");
        private ApplicazioneCondivisione frame = null;
        private List<Person> users;

        public ListUserHandler()
        {
            users = new List<Person>();
        }

        public void listaUsersInit(ApplicazioneCondivisione f)
        {
            users.Add(new Person("Eugenio", "Gallea", "offline"));
            users.Add(new Person("Gianpaolo", "Bontempo", "online"));

            this.frame = f;

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
    }
}
