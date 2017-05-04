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
    class Client
    {
        /*
         * Classe che gestirà le tasks del client
        */
        private static ListUserHandler luh;

        public Client(ListUserHandler luhandler)
        {
            luh = luhandler;
        }

        public void entryPoint(string user)
        {
            string[] cred = user.Split(',');
            if(luh.getlist().ContainsKey(cred[1]+cred[0]))
            SendFileTo(cred[2], cred[3]);
        }

        private static void SendFileTo(string ip, string port)
        {
            // Establish the local endpoint for the socket.
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));

            // Create a TCP socket.
            Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint.
            client.Connect(ipEndPoint);

            // Send file fileName to the remote host with preBuffer and postBuffer data.
            // There is a text file test.txt located in the root directory.
            string fileName = "C:\\Users\\bitri\\Desktop\\canzone.txt"; // Da fare dinamico

            // Create the preBuffer data.
            string string1 = String.Format("This is text data that precedes the file.{0}", Environment.NewLine);
            byte[] preBuf = Encoding.ASCII.GetBytes(string1);

            // Create the postBuffer data.
            string string2 = String.Format("This is text data that will follow the file.{0}", Environment.NewLine);
            byte[] postBuf = Encoding.ASCII.GetBytes(string2);

            //Send file fileName with buffers and default flags to the remote device.
            client.SendFile(fileName, preBuf, postBuf, TransmitFileOptions.UseDefaultWorkerThread);

            // Release the socket.
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}
