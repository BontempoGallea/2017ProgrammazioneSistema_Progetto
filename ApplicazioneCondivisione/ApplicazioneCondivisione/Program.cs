﻿using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO.Pipes;
using System.Text;
using System.IO;
using System.Collections.Generic;

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
        public  static bool exists = false; // Flag per vedere se ci sono altre istanze dello stesso progetto
        public static List<string> pathSend = new List<string>(); // Lista dei paths dei file da inviare
        public static string pathSave = "C:\\Users\\" + Environment.UserName + "\\Download"; // Path di default per il salvataggio dei files in arrivo
        public static bool automaticSave = true; // True = non popparmi la finestra di accetazione quando mi arriva un file   
        private static bool pipeClosed = false;
        public static bool AnnullaBoolean = false;
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

                // Pipe thread per ascoltare
                pipeThread = new Thread(startServer);
              //  pipeThread.SetApartmentState(ApartmentState.STA);
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

                // Avvio l'applicazione
                ac = new ApplicazioneCondivisione();
                Application.Run(ac);
            }
        }

        // Zona per la pipe
        public static void startClient(string path)
        {
            using (var clientSide = new NamedPipeClientStream(".", "MyPipe", PipeDirection.InOut))
            {
                clientSide.Connect();
                try
                {
                    clientSide.ReadMode = PipeTransmissionMode.Message;
                    //Console.WriteLine("Messaggio inviato: " + path);
                    byte[] msg = Encoding.UTF8.GetBytes(path);
                    clientSide.Write(msg, 0, msg.Length);
                    //Thread.Sleep(5000);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public static void startServer()
        {
            try
            {
                while (!closeEverything)
                {
                    using (var serverSide = new NamedPipeServerStream("MyPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous))
                    {
                        Console.WriteLine("Aspetto che qualcuno scriva nella pipe . . .");
                        IAsyncResult ar = serverSide.BeginWaitForConnection(new AsyncCallback(callBack), serverSide);
                        
                        while (!pipeClosed && !closeEverything)
                        {
                            Thread.Sleep(5000);
                            Console.WriteLine("Aspetto di ricevere qualcosa . . .");
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void callBack(IAsyncResult iar)
        {
            try
            {
                NamedPipeServerStream serverPipe = (NamedPipeServerStream)iar.AsyncState;
                serverPipe.EndWaitForConnection(iar);

                byte[] buffer = readMessage(serverPipe);

                pathSend.Add(Encoding.UTF8.GetString(buffer, 0, buffer.Length));
                serverPipe.Close();
                pipeClosed = true;
                return;
            }
            catch (Exception e)
            {
                return;
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
