﻿using System;
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
        private static ListUserHandler luh;
        private Person admin;
        private static UdpClient clientUDP = new UdpClient(senderPort);

        public Server(Person a, ListUserHandler luhandler)
        {
            this.admin = a;
            luh = luhandler;
        }

        public void entryPoint()
        {
            Thread ramoUDP = new Thread(entryUDP);
            ramoUDP.Start();

            Thread ramoTCP = new Thread(entryTCP);
            ramoTCP.Start();
        }

        public void entryUDP()
        {
            Thread talkUDP = new Thread(entryTalk);
            talkUDP.Start();

            Thread listenerUDP = new Thread(entryListen);
            listenerUDP.Start();
        } 

        public void entryTalk()
        {
            while (true)
                udpImOnline(this.admin);
        }

        public void entryListen()
        {
            while (true) 
                ReceiveBroadcastMessages();
        }

        public void entryTCP()
        {
            while (admin.isOnline())
                receiveFile();
        }

        private static void ReceiveBroadcastMessages()
        {
            /*
             * Funzione per ricevere un messaggio in broadcast
            */
            bool done = false;
            byte[] bytes = new Byte[100];
            IPEndPoint ipEp = new IPEndPoint(IPAddress.Any, senderPort);
            try
            {
                while (!done)
                {
                    if ( clientUDP.Available> 0)
                    {
                        bytes = clientUDP.Receive(ref ipEp);
                        string[] cred = Encoding.ASCII.GetString(bytes, 0, bytes.Length).Split(',');
                        Person p = new Person(cred[0], cred[1], cred[2], cred[3], cred[4]);
                        luh.addUser(p);
                        done = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

       
        private void udpImOnline(Person p)
        {

            // Broadcast the message to the listener.
            BroadcastMessage(admin.getString());
        }

      

        static void BroadcastMessage(string message)
        {
             IPEndPoint endPoint;
            IPEndPoint ipEP = new IPEndPoint(IPAddress.Broadcast, senderPort);
            try
            {
                //Send multicast packets to the listener.
                clientUDP.Send(ASCIIEncoding.ASCII.GetBytes(message), ASCIIEncoding.ASCII.GetBytes(message).Length,ipEP);
                Console.WriteLine("Multicast data sent.....");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.ToString());
            }
        }

        public void receiveFile()
        {
            var listener = new TcpListener(admin.getIp(),admin.getPort());
            listener.Start();
            Thread.Sleep(2000);
            while (true)
            {
                using (var client = listener.AcceptTcpClient())
                using (var stream = client.GetStream())
                using (var output = File.Create("result.txt"))
                {
                    // read the file in chunks of 1KB
                    var buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
        public static string GetLocalIPAddress()
        {
            /*
             * Funzione per trovare il mio indirizzo IPv4
             */

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("indirizzo non trovato");
        }
    }
}
