using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
namespace ApplicazioneCondivisione
{
    class Client
    {
        /*
         * Classe che gestirà le tasks del client
        */
        private static IPAddress mcastAddress;
        private static int mcastPort;
        private static Socket mcastSocket;
        private static MulticastOption mcastOption;
        private static ListUserHandler luh;
        public static IPAddress clientlocalip=IPAddress.Parse(GetLocalIPAddress());
        public static int clientlocalport=2000;

        public void entryPoint(ListUserHandler luhandler)
        {
            luh = luhandler;
            Thread.Sleep(5000);
            mcastAddress = IPAddress.Parse("224.168.100.2");
            mcastPort = 11000;

            // Start a multicast group.
            StartMulticast();

            // Display MulticastOption properties.
            MulticastOptionProperties();

            // Receive broadcast messages.
            ReceiveBroadcastMessages();
            Person p = new Person("Luca", "Verdi", "online");
            luh.addUser(p);
        }

        private static void MulticastOptionProperties()
        {
           // Console.WriteLine("Current multicast group is: " + mcastOption.Group);
           // Console.WriteLine("Current multicast local address is: " + mcastOption.LocalAddress);
        }


        private static void StartMulticast()
        {

            try
            {
                mcastSocket = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Dgram,
                                         ProtocolType.Udp);

               // Console.Write("Enter the local IP address: ");

               // IPAddress localIPAddr = IPAddress.Parse(Console.ReadLine());

                //IPAddress localIP = IPAddress.Any;
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

        private static void ReceiveBroadcastMessages()
        {
            bool done = false;
            byte[] bytes = new Byte[100];
            IPEndPoint groupEP = new IPEndPoint(mcastAddress, mcastPort);
            EndPoint remoteEP = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
            Dictionary<string, string> lista = new Dictionary<string, string>();

            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for multicast packets.......");
                    Console.WriteLine("Enter ^C to terminate.");

                    mcastSocket.ReceiveFrom(bytes, ref remoteEP);
                    string[] cred = Encoding.ASCII.GetString(bytes, 0, bytes.Length).Split(',');
                    Console.WriteLine("Received broadcast from {0} :\n {1}\n",
                      groupEP.ToString(),
                      Encoding.ASCII.GetString(bytes, 0, bytes.Length));
                    Console.WriteLine("first argoment {0}\nsecond argoment {1}\nthird argoment", cred[0], cred[1], cred[2]);
                    // lista.Add(cred[0], cred[1]);
                    Person p = new Person(cred[0], cred[1],cred[2]);
                   luh.addUser(p);
                    // Establish the local endpoint for the socket.
                    IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                    IPAddress ipAddr = ipHost.AddressList[0];
                    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(cred[1]), int.Parse(cred[2]));

                    // Create a TCP socket.
                    Socket client = new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream, ProtocolType.Tcp);

                    // Connect the socket to the remote endpoint.
                    client.Connect(ipEndPoint);

                    // Send file fileName to the remote host with preBuffer and postBuffer data.
                    // There is a text file test.txt located in the root directory.
                    string fileName = "C:\\Users\\bitri\\Desktop\\canzone.txt";

                    // Create the preBuffer data.
                    string string1 = String.Format("This is text data that precedes the file.{0}", Environment.NewLine);
                    byte[] preBuf = Encoding.ASCII.GetBytes(string1);

                    // Create the postBuffer data.
                    string string2 = String.Format("This is text data that will follow the file.{0}", Environment.NewLine);
                    byte[] postBuf = Encoding.ASCII.GetBytes(string2);

                    //Send file fileName with buffers and default flags to the remote device.
                    Console.WriteLine("Sending {0} with buffers to the host.{1}", fileName, Environment.NewLine);
                    client.SendFile(fileName, preBuf, postBuf, TransmitFileOptions.UseDefaultWorkerThread);

                    // Release the socket.
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();


                }

                mcastSocket.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static string GetLocalIPAddress()
        {

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach(var ip in host.AddressList)
            {
                if(ip.AddressFamily== AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("indirizzo non trovato");
        }
    }
}
