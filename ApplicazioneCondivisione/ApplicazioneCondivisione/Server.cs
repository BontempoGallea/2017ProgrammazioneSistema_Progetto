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
            while (true) 
                ReceiveBroadcastMessages();
        }

        private static void ReceiveBroadcastMessages()
        {
            /*
             * Funzione per ricevere un messaggio in broadcast
            */
            bool done = false;
            byte[] bytes = new Byte[4096];
            IPEndPoint ipEp = new IPEndPoint(IPAddress.Any, senderPort);

            try
            {
                while (!done)
                {
                    if (clientUDP.Available > 0)
                    {
                        bytes = clientUDP.Receive(ref ipEp);
                        string[] cred = Encoding.ASCII.GetString(bytes, 0, bytes.Length).Split(',');
                        if (Program.luh.ispresent(cred[1] + cred[0])) {
                            Program.luh.resettimer(cred[1]+cred[0]);
                            done = true;
                        }
                        else
                        { 
                            Person p = new Person(cred[0], cred[1], cred[2], cred[3], cred[4]);
                            if (!p.isEqual(Program.luh.getAdmin()))
                            {
                            
                                Program.luh.addUser(p);
                                done = true;
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
            var listener = new TcpListener(Program.luh.getAdmin().getIp(), Program.luh.getAdmin().getPort());
            listener.Start();
            Thread.Sleep(2000);
            while (true)
            {
                using (var client = listener.AcceptTcpClient())
                using (var stream = client.GetStream())
                using (var output = File.Create("result.txt"))
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
