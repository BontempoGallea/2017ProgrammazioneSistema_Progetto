using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace ApplicazioneCondivisione
{
    class Server
    {
        /*
         * Classe che gestirà le tasks del client
        */
        private static int senderPort = 16000;
        private static UdpClient clientUDP = new UdpClient(senderPort);
        private static Thread branchUDP;
        private static Thread branchTCP;
        private static Thread talkUDP;
        private static Thread listenerUDP;
        private int numberAutoSaved = 0;

        public void entryPoint()
        {
            branchUDP = new Thread(entryUDP);
            branchUDP.Start();
           
            branchTCP = new Thread(entryTCP);
            branchTCP.SetApartmentState(ApartmentState.STA);
            branchTCP.Start();
        }

        public void entryUDP()
        {
            talkUDP = new Thread(entryTalk);
            talkUDP.Start();
            listenerUDP = new Thread(entryListen);
            listenerUDP.Start();
        } 

        /*
         * Sezione del ramo UDP dove sono elencate le funzioni che il server userà quando dovrà inviare pacchetti 
         * broadcast sulla LAN.
        */ 
        public void entryTalk()
        {
            while (!Program.closeEverything)
            {
                // Mando pacchetti broadcast ogni 5s, SOLO SE sono ONLINE
                if (Program.luh.getAdmin().getState().CompareTo("online") == 0)
                    BroadcastMessage(Program.luh.getAdmin().getString());

                Thread.Sleep(5000);
            }
        }

        static void BroadcastMessage(string message)
        {
            IPEndPoint ipEP = new IPEndPoint(IPAddress.Broadcast, senderPort);  

            try
            {
                clientUDP.Send(ASCIIEncoding.ASCII.GetBytes(message), ASCIIEncoding.ASCII.GetBytes(message).Length, ipEP);
                //Console.WriteLine("Multicast data sent.....");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.ToString());
            }
        }

        /*
         * Sezione del ramo UDP che elenca le funzioni usate dal server per agire come receiver di pacchetti
        */ 
        public void entryListen()
        {
            while (!Program.closeEverything)
                ReceiveBroadcastMessages();
        }

        private static void ReceiveBroadcastMessages()
        {
            /*
             * Funzione per ricevere un messaggio in broadcast
            */
            bool done = false; // Variabile per terminare la ricezione del pacchetto
            byte[] bytes = new Byte[4096]; // Buffer
            IPEndPoint ipEp = new IPEndPoint(IPAddress.Any, senderPort); // Endpoint dal quale sto ricevendo dati, accetto qualsiasi indirizzo con la senderPort
            try
            {
                while ( !done && !Program.closeEverything )
                {
                    if ( clientUDP.Available > 0 ) // Controllo che sul canale ci siano dei byte disponibili
                    {
                        bytes = clientUDP.Receive(ref ipEp); // Ricevo byte
                        string[] cred = Encoding.ASCII.GetString(bytes, 0, bytes.Length).Split(','); // Converto in stringhe
                        if (Program.luh.isPresent(cred[1] + cred[0]) && !( cred[2].CompareTo("offline") == 0 ))
                        {   
                            // Controllo che la persona è gia presente nella lista e lo stato inviatomi sia ONLINE
                            Program.luh.resetTimer( cred[1] + cred[0] ); // Se presente resetto il timer della persona
                            done = true; // Ricezione completata
                        }
                        else // Se non è gia presente
                        { 
                            Person p = new Person(cred[0], cred[1], cred[2], cred[3], cred[4]); //creo una nuova persona
                            if ( !p.isEqual(Program.luh.getAdmin()) && !( cred[2].CompareTo("offline") == 0 ) ) //se non è uguale all'amministratore
                            {
                                Program.luh.addUser(p);//inserisco nella lista delle persone
                                done = true;//ricezione completata
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /*
         * Sezione del tamo TCP dove si elencano le funzioni usate dal server per ricevere files.
        */ 
        public void entryTCP()
        {
            while (Program.luh.getAdmin().isOnline() && !Program.closeEverything)
                receiveFile();
        }

        public void receiveFile()
        {
            var listener = new TcpListener(Program.luh.getAdmin().getIp(), Program.luh.getAdmin().getPort());// Imposto tcplistener con le credenziali della persona
            listener.Start(); // Inizio ascolto
            Thread.Sleep(2000);
            while (!Program.closeEverything)
            {
                if (!listener.Pending()) // Se non c'è nessuno che vuole inviarmi nulla, continuo col prossimo ciclo
                    continue;

                using (var client = listener.AcceptTcpClient()) { // Bloccante
                    byte[] buf= Encoding.ASCII.GetBytes("");
                    client.GetStream().Read(buf, 0, 1024);
                    string[] vet = Encoding.ASCII.GetString(buf).Split(',');
                    string admin = vet[0];
                    string nomeFile = Path.GetFileName(vet[1]);

                    switch (MessageBox.Show(admin+"sta tentando di inviarti il file",nomeFile, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.No:
                            client.GetStream().Write(ASCIIEncoding.ASCII.GetBytes("no"), 0, 2);
                            return;
                        
                        case DialogResult.Yes:
                            client.GetStream().Write(ASCIIEncoding.ASCII.GetBytes("ok"), 0, 2);
                            break;

                        default:
                            break;
                    }
                    
                    SaveFileDialog a = new SaveFileDialog();
                    a.InitialDirectory = Program.pathSave;
                    numberAutoSaved = a.FileNames.Count(s => s.CompareTo(nomeFile) == 0);

                    if (numberAutoSaved != 0)
                        a.FileName = nomeFile + "(" + numberAutoSaved + ")";
                    else
                        a.FileName = nomeFile;

                    a.Filter = " text |*.txt";

                    if (!Program.automaticSave)
                        a.ShowDialog();
                    else
                        numberAutoSaved++;

                    using (var stream = client.GetStream()) // flusso di dati
                    using (var output = File.Create(a.FileName)) // file di output
                    {
                        // Leggo il file a pezzi da 1KB
                        var buffer = new byte[1024];
                        int bytesRead;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                        }
                    }
                }
                
            }
        }
    }
}
