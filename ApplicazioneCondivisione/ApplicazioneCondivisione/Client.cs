using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ApplicazioneCondivisione
{
    class Client
    {
        /*
         * Classe che gestirà le tasks del client
        */

        ListUserHandler luh;

        public void entryPoint(ListUserHandler luh)
        {
            this.luh = luh;
            Thread.Sleep(5000);
            Person p = new Person("Luca", "Verdi", "online");
            luh.addUser(p);
        }
    }
}
