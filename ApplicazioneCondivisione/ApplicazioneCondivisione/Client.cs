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
    class Client
    {
        /*
         * Classe che gestirà le tasks del client
        */
        public void entryPoint(string user)
        {
            // Ottengo indirizzo ip e porta della persona a cui voglio inviare il file
            string[] cred = user.Split(',');
            Person p = new Person();
            Program.luh.getList().TryGetValue(cred[1] + cred[0], out p);

            if (p.isOnline())
                SendFileTo(cred[2], cred[3]);
            else
                MessageBox.Show("La persona a cui vuoi inviare non è più online!");
        }

        private static void SendFileTo(string ip, string port)
        {
            // Stabilisce l'endpoint locale per il socket
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));

            // Crea un TCP socket.
            Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

            // Connette il socket all'endpoint remoto
            client.Connect(ipEndPoint);

            // Manda fileName all'host remoto
          
            string fileName = Program.pathSend.First(); // Prendo il primo path
            Program.pathSend.RemoveAt(0); // 1 o 0 ?
            client.SendBufferSize = 1024;
            string richiesta = String.Format(Program.luh.getAdmin().getName()+","+fileName, Environment.NewLine); // Stringa per avvisare chi sono, se lui mi accetta io mando il file
            byte[] ansbyte = Encoding.ASCII.GetBytes("");
            byte[] richbyte = Encoding.ASCII.GetBytes(richiesta);
            client.ReceiveBufferSize = 2;
            client.Send(richbyte);
            
            client.Receive(ansbyte);
            string confermed= ASCIIEncoding.ASCII.GetString(ansbyte);

            // Creo prebuffer e postbuffer per scrivere all'inizio e alla fine del file
            if (confermed.CompareTo("ok") == 0)
            {
                string string1 = String.Format(""); // Modifico qua se voglio aggiungere qualcosa prima del file
                byte[] preBuf = Encoding.ASCII.GetBytes(string1);

                string string2 = String.Format(""); // Modifico qua se voglio aggiungere qualcosa dopo il file
                byte[] postBuf = Encoding.ASCII.GetBytes(string2);

                // Mando fileName con i buffers e i flag di default all'endpoint remoto
                client.SendFile(fileName, preBuf, postBuf, TransmitFileOptions.UseDefaultWorkerThread);

                // Faccio il free del socket
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }
    }
}
