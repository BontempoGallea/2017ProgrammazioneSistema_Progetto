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
            bool isDIr = false;
            // Crea un TCP socket.
            Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

            // Connette il socket all'endpoint remoto
            client.Connect(ipEndPoint);

            // Manda fileName all'host remoto
            if((File.GetAttributes(Program.pathSend)& FileAttributes.Directory)== FileAttributes.Directory)
            {
                isDIr = true;
            }
            if (isDIr)
            {
                string fileName = Program.pathSend; // Prendo il primo path
                string[] files = Directory.GetFiles(fileName);

                Program.pathSend = string.Empty;
                client.SendBufferSize = 1024;
                string pacchettoInfo = Program.luh.getAdmin().getName() + "," + fileName + ",cartella,"+files.Count<String>();
                foreach(string b in files)
                {
                    
                    pacchettoInfo = pacchettoInfo + "," + b;
                }
                byte[] ansbyte = Encoding.ASCII.GetBytes("");
                byte[] richbyte = Encoding.ASCII.GetBytes(pacchettoInfo);
                client.ReceiveBufferSize = 2;
                client.Send(richbyte);
                client.Receive(ansbyte);
                string confermed = ASCIIEncoding.ASCII.GetString(ansbyte);
                if (confermed.CompareTo("ok") == 0)
                {
                    string string1 = String.Format(""); // Modifico qua se voglio aggiungere qualcosa prima del file
                    byte[] preBuf = Encoding.ASCII.GetBytes(string1);

                    string string2 = String.Format(""); // Modifico qua se voglio aggiungere qualcosa dopo il file
                    byte[] postBuf = Encoding.ASCII.GetBytes(string2);
                    foreach(string file in files)
                    {
                        client.SendFile(file, preBuf, postBuf, TransmitFileOptions.UseDefaultWorkerThread);
                         client.Receive(ansbyte);
                        if (Program.AnnullaBoolean)
                        {
                            client.Send(Encoding.ASCII.GetBytes("annulla"));
                            client.Shutdown(SocketShutdown.Both);
                            client.Close();
                            return;
                        }
                        else
                        {
                            client.Send(Encoding.ASCII.GetBytes("fine"));
                        }
                        // Faccio il free del socket
                       
                    }
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                    // Mando fileName con i buffers e i flag di default all'endpoint remoto
                    
                   
                }
            }
            else
            {
                string fileName = Program.pathSend; // Prendo il primo path
			    Program.pathSend = string.Empty;
			    client.SendBufferSize = 1024;
			    string richiesta = String.Format(Program.luh.getAdmin().getName()+","+fileName+",file", Environment.NewLine); // Stringa per avvisare chi sono, se lui mi accetta io mando il file
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
				    client.Receive(ansbyte);
				    if (Program.AnnullaBoolean)
				    {
					    client.Send(Encoding.ASCII.GetBytes("annulla"));
				    }
				    else
				    {
					    client.Send(Encoding.ASCII.GetBytes("fine"));
				    }
				    // Faccio il free del socket
				    client.Shutdown(SocketShutdown.Both);
				    client.Close();
			    }
            }
           
        }
    }
}
