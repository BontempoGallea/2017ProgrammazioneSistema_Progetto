using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
namespace ApplicazioneCondivisione
{
    static class Program
    {
        public static Client client;
        public static Server server;
        public static Thread serverThread;
        public static ListUserHandler luh;
        public static ApplicazioneCondivisione ac;
        public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();// inizializzo timer
        public static bool closeEverything = false; // Questo è il flag al quale i thread fanno riferimento per sapere se devono chiudere tutto o no
        public static RegistryKey key;
        
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            luh = new ListUserHandler();
            
            // Codice ancora da controllare per l'aggiunta dell'opzione al context menu di Windows
            key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\Classes\\*\\Shell\\condividi in lan");
            key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\Classes\\*\\Shell\\condividi in lan\\command");
            key.SetValue("", "\"" + Application.ExecutablePath +"\"\""+"%1\"");
            // Creo la classe client che verrà fatta girare nel rispettivo thread
            client = new Client();
            
            // Creo la classe server che verrà fatta girare nel rispettivo thread
            server = new Server();
            serverThread = new Thread(server.entryPoint){ Name = "serverThread" };
            serverThread.Start();

            // Avvio l'appplicazione
            ac = new ApplicazioneCondivisione();
            Application.Run(ac);
        }
    }
}
