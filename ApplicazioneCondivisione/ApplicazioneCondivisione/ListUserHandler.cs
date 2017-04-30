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
        private Person p1 = new Person("Eugenio", "Gallea", "offline");
        private Person p2 = new Person("Gianpaolo", "Bontempo", "online");
        private Person admin = new Person("Mario", "Rossi", "offline");

        public ListUserHandler()
        {
                
        }

        public void listaUsersInit(ApplicazioneCondivisione f)
        {
            int w = f.listaUsers.Width / 5;

            f.listaUsers.View = View.Details;

            f.listaUsers.Columns.Add("Nome", w * 2, HorizontalAlignment.Center);
            f.listaUsers.Columns.Add("Cognome", w * 2, HorizontalAlignment.Center);
            f.listaUsers.Columns.Add("Stato", w, HorizontalAlignment.Center);
            f.listaUsers.CheckBoxes = true;

            var item1 = new ListViewItem(new[] { p1.getNome(), p1.getCognome(), p1.getStato() });
            var item2 = new ListViewItem(new[] { p2.getNome(), p2.getCognome(), p2.getStato() });

            f.listaUsers.Items.Add(item1);
            f.listaUsers.Items.Add(item2);

            f.labelAdmin.Text = "Nome: " + admin.getNome() + "\nCognome: " + admin.getCognome() + "\nStato: " + admin.getStato();
        }
    }
}
