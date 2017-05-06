using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

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

        public void entryPoint()
        {
            branchUDP = new Thread(entryUDP);
            branchUDP.Start();

            branchTCP = new Thread(entryTCP);
            branchTCP.Start();
        }

        public void entryUDP()
        {
            talkUDP = new Thread(entryTalk);
            talkUDP.Start();
            listenerUDP = new Thread(entryListen);
            listenerUDP.Start();
        } 

        public void entryTalk()
        {
            while (true)
            {
                BroadcastMessage(Program.luh.getAdmin().getString());
            }
        }

        static void BroadcastMessage(string message)
        {
            IPEndPoint ipEP = new IPEndPoint(IPAddress.Broadcast, senderPort);  
            try
            {
                // Mando pacchetti broadcast
                clientUDP.Send(ASCIIEncoding.ASCII.GetBytes(message), ASCIIEncoding.ASCII.GetBytes(message).Length, ipEP);
                Console.WriteLine("Multicast data sent.....");
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.ToString());
            }
        }

        public void entryListen()
        {
            while (true)  ReceiveBroadcastMessages();
        }

        private static void ReceiveBroadcastMessages()
        {
            /*
             * Funzione per ricevere un messaggio in broadcast
             * 
            */
            //variabile per terminare la ricezione del pacchetto
            bool done = false;
            byte[] bytes = new Byte[4096];//buffer
            IPEndPoint ipEp = new IPEndPoint(IPAddress.Any, senderPort);//imposto il broadcast come sender del pacchetto
            try
            {
                while (!done)
                {
                    if (clientUDP.Available > 0)//controllo che sul canale ci siano dei byte disponibili
                    {
                        bytes = clientUDP.Receive(ref ipEp);//ricevo byte
                        string[] cred = Encoding.ASCII.GetString(bytes, 0, bytes.Length).Split(',');//converto in stringhe
                        if (Program.luh.ispresent(cred[1] + cred[0])) {//controllo che la persona è gia presente nella lista
                            Program.luh.resettimer(cred[1]+cred[0]);//se presente resetto il timer della persona
                            done = true;//ricezione completata
                        }
                        else//se non è gia presente
                        { 
                            Person p = new Person(cred[0], cred[1], cred[2], cred[3], cred[4]);//creo una nuova persona
                            if (!p.isEqual(Program.luh.getAdmin()))//se non è uguale all'amministratore
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

        public void entryTCP()
        {
            while (Program.luh.getAdmin().isOnline())
                receiveFile();
        }

        public void receiveFile()
        {
            var listener = new TcpListener(Program.luh.getAdmin().getIp(), Program.luh.getAdmin().getPort());//imposto  tcplistener con le credenziali della persona
            listener.Start();//inizio ascolto
            Thread.Sleep(2000);
            while (true)
            {
                using (var client = listener.AcceptTcpClient())//aspetta connessione
                using (var stream = client.GetStream())//flusso di dati
                using (var output = File.Create("result.txt"))//file di output
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

        public void closeAllThreads()
        {
            listenerUDP.Abort();
            talkUDP.Abort();
            branchTCP.Abort();
            branchUDP.Abort();
        }
    }
}
