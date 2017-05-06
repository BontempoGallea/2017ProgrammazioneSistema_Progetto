using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicazioneCondivisione
{
    static class Program
    {
        public static Client client;
        public static Server server;
        public static Thread serverThread;
        public static ListUserHandler luh;
        public static ApplicazioneCondivisione ac;

        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [MTAThread]
        static void Main()
        {
             luh = new ListUserHandler();

            // Creo la classe client che verrà fatta girare nel rispettivo thread
            client = new Client();

            // Creo la classe server che verrà fatta girare nel rispettivo thread
            server = new Server();
            serverThread = new Thread(server.entryPoint);
            serverThread.Name = "serverThread";
            serverThread.Start();

            // Avvio l'appplicazione
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ac = new ApplicazioneCondivisione();
            Application.Run(ac);
        }
    }
}
