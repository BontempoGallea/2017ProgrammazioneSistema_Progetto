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
        private static int senderPort = 16000;          //porta standard per chi manda sulla rete le proprie credenziali
        private static ListUserHandler luh;
        private static UdpClient clientUDP = new UdpClient(senderPort);
        private static Thread ramoUDP;                  //thread del ramo udp
        private static Thread ramoTCP;                  //thread del ramo tcp
        private static Thread talkUDP;                  //thread che si occupa di inviare pacchetti udp
        private static Thread listenerUDP;              //thread che si occupa di ascoltare pacchetti udp

        public Server(ListUserHandler luhandler)
        {
            luh = luhandler;
        }

        public void entryPoint()
        {
            ramoUDP = new Thread(entryUDP);
            ramoUDP.Start();
            ramoTCP = new Thread(entryTCP);
            ramoTCP.Start();
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
                BroadcastMessage(luh.getAdmin().getString());
            }
        }

        static void BroadcastMessage(string message)
        {
            IPEndPoint ipEP = new IPEndPoint(IPAddress.Broadcast, senderPort);  
            try
            {
                //invia messaggio udp in broadcast
                clientUDP.Send(ASCIIEncoding.ASCII.GetBytes(message), ASCIIEncoding.ASCII.GetBytes(message).Length, ipEP);//invio messaggio in byte su broadcast
                Console.WriteLine("Multicast data sent.....");//visione su output
                Thread.Sleep(5000);//sospendi tread per tot sec
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
                        if (luh.ispresent(cred[1] + cred[0])) {//controllo che la persona è gia presente nella lista
                            luh.resettimer(cred[1]+cred[0]);//se presente resetto il timer della persona
                            done = true;//ricezione completata
                        }
                        else//se non è gia presente
                        { 
                            Person p = new Person(cred[0], cred[1], cred[2], cred[3], cred[4]);//creo una nuova persona
                            if (!p.isEqual(luh.getAdmin()))//se non è uguale all'amministratore
                            {
                                luh.addUser(p);//inserisco nella lista delle persone
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
            while (luh.getAdmin().isOnline())
                receiveFile();
        }

        public void receiveFile()
        {
            var listener = new TcpListener(luh.getAdmin().getIp(), luh.getAdmin().getPort());//imposto  tcplistener con le credenziali della persona
            listener.Start();//inizio ascolto
            Thread.Sleep(2000);
            while (true)
            {
                using (var client = listener.AcceptTcpClient())//aspetta connessione
                using (var stream = client.GetStream())//flusso di dati
                using (var output = File.Create("result.txt"))//file di output
                {
                    // read the file in chunks of 1KB
                    var buffer = new byte[1024];//buffer
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
            ramoTCP.Abort();
            ramoUDP.Abort();
        }
    }
}
