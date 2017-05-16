using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO.Pipes;
using System.Text;
using System.IO;

namespace ApplicazioneCondivisione
{
    static class Program
    {
        public static Client client;
        public static Server server;
        public static Thread serverThread;
        public static Thread pipeThread;
        public static ListUserHandler luh;
        public static ApplicazioneCondivisione ac;
        public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); // Inizializzo timer
        public static bool closeEverything = false; // Questo è il flag al quale i thread fanno riferimento per sapere se devono chiudere tutto o no
        public static RegistryKey key;
        public  static bool exists = false;
        public static string path;

        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {
            // Controllo che non esista nessuna istanza dello stesso processo
            exists = Process
                    .GetProcessesByName(System.IO
                                        .Path
                                        .GetFileNameWithoutExtension(
                                            System.Reflection.Assembly.GetEntryAssembly().Location)
                                                                        ).Length > 1;

            if (exists)
            {
                //MessageBox.Show("C'è già un altro processo che va");
                //Console.WriteLine("Argomenti arrivati: " + args[0]);
                startClient(args[0]);
                closeEverything = true;
            }

            if (!closeEverything)
            {
                Application.EnableVisualStyles(); // Questa operazione deve essere fatta prima di inizializzare qualsiasi oggetto
                Application.SetCompatibleTextRenderingDefault(false);
                luh = new ListUserHandler();
                pipeThread = new Thread(startServer);
                pipeThread.Start();

                // Codice per l'aggiunta dell'opzione al context menu di Windows
                key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\Classes\\*\\Shell\\Condividi in LAN");
                key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\Classes\\*\\Shell\\Condividi in LAN\\command");
                key.SetValue("", "\"" + Application.ExecutablePath + "\"" + " \"%1\"");

                // Creo la classe client che verrà fatta girare nel rispettivo thread
                client = new Client();

                // Creo la classe server che verrà fatta girare nel rispettivo thread
                server = new Server();
                serverThread = new Thread(server.entryPoint) { Name = "serverThread" };
                serverThread.Start();

                // Avvio l'appplicazione
                ac = new ApplicazioneCondivisione();
                Application.Run(ac);
            }
        }

        public static void startClient(string path)
        {
            using (var clientSide = new NamedPipeClientStream(".", "MyPipe", PipeDirection.InOut))
            {
                clientSide.Connect();
                try
                {
                    clientSide.ReadMode = PipeTransmissionMode.Message;
                    Console.WriteLine("Messaggio inviato: " + path);
                    byte[] msg = Encoding.UTF8.GetBytes(path);
                    clientSide.Write(msg, 0, msg.Length);
                    Thread.Sleep(5000);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public static void startServer()
        {
            while (true)
            {
                using (var serverSide = new NamedPipeServerStream("MyPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message))
                {
                    Console.WriteLine("Aspetto che qualcuno scriva nella pipe . . .");
                    serverSide.WaitForConnection();
                    path = Encoding.UTF8.GetString(readMessage(serverSide));
                    Console.WriteLine("Ho ricevuto un path: " + path);
                    serverSide.Disconnect();
                }
            }
        }

        public static byte[] readMessage(PipeStream ps)
        {
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[0x1000]; // 4Kb

            do
            {
                ms.Write(buffer, 0, ps.Read(buffer, 0, buffer.Length));
            } while (!ps.IsMessageComplete);

            return ms.ToArray();
        }
    }
}
