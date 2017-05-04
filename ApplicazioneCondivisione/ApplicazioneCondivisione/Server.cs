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
        private static IPAddress mcastAddress;
        private static int mcastPort;
        private static Socket mcastSocket;
        private static MulticastOption mcastOption;
        private static ListUserHandler luh;
        private Person admin;
        public static IPAddress clientlocalip = IPAddress.Parse(GetLocalIPAddress());
        public static int clientlocalport = 2000;

        public Server(Person a, ListUserHandler luhandler)
        {
            this.admin = a;
            luh = luhandler;
        }

        public void entryPoint()
        {
            mcastAddress = IPAddress.Parse("224.168.100.2");
            mcastPort = 11000;

            // Start a multicast group.
            

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
            // Join the listener multicast group.
            JoinMulticastGroup();

            while (true)
            {
                udpImOnline(this.admin);
            }

            mcastSocket.Close();
        }

        public void entryListen()
        {
            StartMulticast();
            while(true)
                // Receive broadcast messages.
                ReceiveBroadcastMessages();

            mcastSocket.Close();
        }

        public void entryTCP()
        {
            while (admin.isOnline())
            {
                receiveFile();
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

        private static void ReceiveBroadcastMessages()
        {
            /*
             * Funzione per ricevere un messaggio in broadcast
            */

            bool done = false;
            byte[] bytes = new Byte[100];
            IPEndPoint groupEP = new IPEndPoint(mcastAddress, mcastPort);
            EndPoint remoteEP = (EndPoint)new IPEndPoint(IPAddress.Any, 0);

            try
            {
                while (!done)
                {
                    var a = mcastSocket.Available;
                    if ( a> 0)
                    {
                        mcastSocket.ReceiveFrom(bytes, ref remoteEP);
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

        private static void StartMulticast()
        {
            /*
             * Mi aggiungo il gruppo multicast
            */

            try
            {
                mcastSocket = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Dgram,
                                         ProtocolType.Udp);

                EndPoint localEP = (EndPoint)new IPEndPoint(clientlocalip, mcastPort);

                mcastSocket.Bind(localEP);

                // Define a MulticastOption object specifying the multicast group 
                // address and the local IPAddress.
                // The multicast group address is the same as the address used by the server.
                mcastOption = new MulticastOption(mcastAddress, clientlocalip);

                mcastSocket.SetSocketOption(SocketOptionLevel.IP,
                                            SocketOptionName.AddMembership,
                                            mcastOption);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void udpImOnline(Person p)
        {
            mcastAddress = IPAddress.Parse("224.168.100.2");
            mcastPort = 11000;

            // Broadcast the message to the listener.
            BroadcastMessage(admin.getString());
        }

        public void JoinMulticastGroup()
        {
            try
            {
                // Create a multicast socket.
                mcastSocket = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Dgram,
                                         ProtocolType.Udp);

                // Get the local IP address used by the listener and the sender to
                // exchange multicast messages. 
                Console.Write("\nEnter local IPAddress for sending multicast packets: ");
                IPAddress localIPAddr = this.admin.getIp();

                // Create an IPEndPoint object. 
                IPEndPoint IPlocal = new IPEndPoint(localIPAddr, 0);

                // Bind this endpoint to the multicast socket.
                mcastSocket.Bind(IPlocal);

                // Define a MulticastOption object specifying the multicast group 
                // address and the local IP address.
                // The multicast group address is the same as the address used by the listener.
                MulticastOption mcastOption;
                mcastOption = new MulticastOption(mcastAddress, localIPAddr);

                mcastSocket.SetSocketOption(SocketOptionLevel.IP,
                                            SocketOptionName.AddMembership,
                                            mcastOption);

            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.ToString());
            }
        }

        static void BroadcastMessage(string message)
        {
            IPEndPoint endPoint;

            try
            {
                //Send multicast packets to the listener.
                endPoint = new IPEndPoint(mcastAddress, mcastPort);
                mcastSocket.SendTo(ASCIIEncoding.ASCII.GetBytes(message), endPoint);
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
    }
}
