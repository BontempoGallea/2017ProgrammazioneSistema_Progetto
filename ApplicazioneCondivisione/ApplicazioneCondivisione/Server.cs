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
            try
            {
                branchUDP = new Thread(entryUDP);
                branchUDP.Start();

                branchTCP = new Thread(entryTCP);
                branchTCP.SetApartmentState(ApartmentState.STA);
                branchTCP.Start();
            }
            catch (ArgumentException e) { }
            catch (ThreadStateException e) { }
            catch (OutOfMemoryException e) { }
            catch (InvalidOperationException e) { }
        }

        public void entryUDP()
        {
            try
            {
                talkUDP = new Thread(entryTalk);
                talkUDP.Start();
                listenerUDP = new Thread(entryListen);
                listenerUDP.Start();
            }
            catch (ArgumentException e) { }
            catch (ThreadStateException e) { }
            catch (OutOfMemoryException e) { }
            catch (InvalidOperationException e) { }
        }

        /*
         * Sezione del ramo UDP dove sono elencate le funzioni che il server userà quando dovrà inviare pacchetti 
         * broadcast sulla LAN.
        */
        public void entryTalk()
        {
            while (!Program.closeEverything)
            {
                while (Program.luh.getAdmin() == null) { }
                // Mando pacchetti broadcast ogni 5s, SOLO SE sono ONLINE
                if (Program.luh.getAdmin().getState().CompareTo("online") == 0)//da fare un lock
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
                while (!done && !Program.closeEverything)
                {
                    if (clientUDP.Available > 0) // Controllo che sul canale ci siano dei byte disponibili
                    {
                        bytes = clientUDP.Receive(ref ipEp); // Ricevo byte
                        string[] cred = Encoding.ASCII.GetString(bytes, 0, bytes.Length).Split(','); // Converto in stringhe
                        if (Program.luh.isPresent(cred[1] + cred[0]) && !(cred[2].CompareTo("offline") == 0))
                        {
                            // Controllo che la persona è gia presente nella lista e lo stato inviatomi sia ONLINE
                            Program.luh.resetTimer(cred[1] + cred[0]); // Se presente resetto il timer della persona
                            done = true; // Ricezione completata
                        }
                        else // Se non è gia presente
                        {
                            Person p = new Person(cred[0], cred[1], cred[2], cred[3], cred[4]); //creo una nuova persona
                            if (!p.isEqual(Program.luh.getAdmin()) && !(cred[2].CompareTo("offline") == 0)) //se non è uguale all'amministratore
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
            while (Program.luh.getAdmin() == null) { }
            while (Program.luh.getAdmin().isOnline() && !Program.closeEverything)
                receiveFile();
        }

        public void receiveFile()
        {
            string admin;
            string[] vet;
            int byteletti;
            string nomeFile;
            int numFile;
            byte[] autorizzo = new byte[1024];
            byte[] bufferfile = new byte[1024];
            string pathDir;
            SaveFileDialog datifile = new SaveFileDialog();
            try
            {
                var listener = new TcpListener(Program.luh.getAdmin().getIp(), Program.luh.getAdmin().getPort());// Imposto tcplistener con le credenziali della persona
                listener.Start(); // Inizio ascolto
                Thread.Sleep(2000);
                while (!Program.closeEverything)
                {
                    if (!listener.Pending()) // Se non c'è nessuno che vuole inviarmi nulla, continuo col prossimo ciclo
                        continue;

                    using (var client = listener.AcceptTcpClient()) //accetto tcpclient
                    { // Bloccante
                        //ricevo pacchetto di informazione
                        byte[] buf = new byte[1024];

                        byteletti = client.GetStream().Read(buf, 0, 1024);//leggo in buf 1024 byte dallo stream del client
                        vet = Encoding.ASCII.GetString(buf).Split(',');//scompongo le parole separate da virgola
                        admin = vet[0];
                        nomeFile = Path.GetFileName(vet[1]);
                        string tipo = vet[2];
                        //
                        if (tipo.CompareTo("cartella") == 0)
                        {

                            if (!int.TryParse(vet[3], out numFile))//salvo in numfile quanti file scaricare
                            {
                                return;
                            }
                            if (Program.automaticSave)//se il salvataggio non è automatico
                            {
                                //se il salvataggio non è automatico allora chiedi all'utente se scaricare
                                //la cartella o no in ogni caso informo il mittente della decisione presa
                                switch (MessageBox.Show(admin + "sta tentando di inviarti la cartella", nomeFile, MessageBoxButtons.YesNo))
                                {
                                    case DialogResult.No:
                                        //nel caso di risposta negativa informo mittente
                                        autorizzo = ASCIIEncoding.ASCII.GetBytes("no");
                                        client.GetStream().Write(autorizzo, 0, autorizzo.Length);
                                        return;

                                    case DialogResult.Yes:
                                        autorizzo = ASCIIEncoding.ASCII.GetBytes("ok");
                                        client.GetStream().Write(autorizzo, 0, autorizzo.Length);
                                        break;

                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                autorizzo = ASCIIEncoding.ASCII.GetBytes("ok");
                                client.GetStream().Write(autorizzo, 0, autorizzo.Length);
                            }
                            Directory.CreateDirectory(Program.pathSave + "/" + nomeFile);
                            pathDir = Program.pathSave + "/" + nomeFile;
                            for (int j = 0; j < numFile; j++)
                            {

                                datifile.InitialDirectory = Program.pathSave;
                                numberAutoSaved = datifile.FileNames.Count(s => s.CompareTo(nomeFile) == 0);

                                if (numberAutoSaved != 0)
                                    datifile.FileName = pathDir + "/" + vet[4 + j] + "(" + numberAutoSaved + ")";
                                else
                                    datifile.FileName = pathDir + "/" + vet[4 + j];

                                datifile.Filter = " text |*.txt";

                                if (!Program.automaticSave)
                                    datifile.ShowDialog();
                                else
                                    numberAutoSaved++;

                                using (var stream = client.GetStream()) // flusso di dati
                                using (var output = File.Create(datifile.FileName)) // file di output
                                {
                                    // Leggo il file a pezzi da 1KB
                                    bufferfile = new byte[1024];
                                    int bytesRead;
                                    while ((bytesRead = stream.Read(bufferfile, 0, bufferfile.Length)) > 0)
                                    {
                                        output.Write(bufferfile, 0, bytesRead);

                                    }
                                    client.GetStream().Write(ASCIIEncoding.ASCII.GetBytes("fine?"), 0, 2);
                                    byteletti = client.GetStream().Read(buf, 0, 1024);
                                    String risposta = Encoding.ASCII.GetString(buf);
                                    if (risposta.CompareTo("annulla") == 0)
                                    {
                                        File.Delete(datifile.FileName);
                                        foreach (String b in Directory.GetFiles(pathDir))
                                        {
                                            File.Delete(b);
                                        }
                                        Directory.Delete(pathDir);
                                        continue;
                                    }
                                }
                            }

                        }
                        else if (tipo.CompareTo("file") == 0)
                        {
                            if (!Program.automaticSave)//se il salvataggio non è automatico
                            {
                                switch (MessageBox.Show(admin + "sta tentando di inviarti il file", nomeFile, MessageBoxButtons.YesNo))
                                {
                                    case DialogResult.No:
                                        autorizzo = ASCIIEncoding.ASCII.GetBytes("no");
                                        client.GetStream().Write(autorizzo, 0, autorizzo.Length);
                                        return;

                                    case DialogResult.Yes:
                                        autorizzo = ASCIIEncoding.ASCII.GetBytes("ok");
                                        client.GetStream().Write(autorizzo, 0, autorizzo.Length);
                                        break;

                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                autorizzo = ASCIIEncoding.ASCII.GetBytes("ok");
                                client.GetStream().Write(autorizzo, 0, autorizzo.Length);
                            }
                            string[] vett2 = nomeFile.Split('.');
                            numberAutoSaved = 0;
                            datifile.FileName = Program.pathSave + @"\" + nomeFile;
                            while (File.Exists(datifile.FileName))
                            {
                                numberAutoSaved++;
                                datifile.FileName = Program.pathSave + @"\" + vett2[0] + "(" + numberAutoSaved + ")" + "." + vett2[1];

                            }
                            datifile.InitialDirectory = Program.pathSave;



                            datifile.Filter = " text |*.txt";

                            if (!Program.automaticSave)
                                datifile.ShowDialog();
                            else
                                numberAutoSaved++;

                            using (var stream = client.GetStream()) // flusso di dati
                            using (var output = File.Create(datifile.FileName)) // file di output
                            {
                                // Leggo il file a pezzi da 1KB

                                int bytesRead;
                                while ((bytesRead = stream.Read(bufferfile, 0, 1024)) > 0)
                                {
                                    output.Write(bufferfile, 0, bytesRead);
                                    if (bytesRead < 1024)
                                        break;
                                }
                                buf = ASCIIEncoding.ASCII.GetBytes("fine?");
                                client.GetStream().Write(buf, 0, 2);
                                buf = new byte[1024];
                                client.GetStream().Read(buf, 0, 1024);
                                String risposta = Encoding.ASCII.GetString(buf);
                                if (risposta.CompareTo("annulla") == 0)
                                {
                                    File.Delete(datifile.FileName);
                                }
                            }
                        }
                        client.Close();
                    }



                }
            }
            catch (ArgumentNullException e) { }
            catch (EncoderFallbackException e) { }
            catch (ArgumentException e) { }
            catch (SocketException e) { }
            catch (ObjectDisposedException e) { }
            catch (System.Security.SecurityException e) { }
            catch (FileNotFoundException e) { }
            catch (InvalidOperationException e) { }
            catch (DirectoryNotFoundException e) { }
            catch (PathTooLongException e) { }
            catch (IOException e) { }
            catch (UnauthorizedAccessException e) { }
        }
    }
}
