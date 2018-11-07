using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketTcpServer
{
    class Server
    {

        TcpListener Listener;  //Object, accepting TCP client

        // Server start
        public Server(int Port)
        {            
            //Create a "listener" for the specified port
            Listener = new TcpListener(IPAddress.Any, Port);
            Listener.Start(); 
            
            while (true)
            {
                // We accept a new customer
                TcpClient Client = Listener.AcceptTcpClient();

                // Create thread
                Thread Thread = new Thread(new ParameterizedThreadStart(ClientThread));
                //Run thread and give him Client
                Thread.Start(Client);                
            }
        }

        // Server stop
        ~Server()
        {
            // Delete Listener
            if (Listener != null)
            {
                //Stop him
                Listener.Stop();
            }
        }

        static void ClientThread(Object StateInfo)
        {
            byte[] Buffer = new byte[1024];
            new Client((TcpClient)StateInfo, Encoding.ASCII.GetString(Buffer, 0, sizeof(char) * 9));
        }

        static void Main(string[] args)
        {            
            // Define the required max number of threads (4 for each processor)           
            int MaxThreadsCount = Environment.ProcessorCount * 4;
            // Set the maximum number of worker threads
            ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);
            //Set the minimum number of worker threads
            ThreadPool.SetMinThreads(2, 2);
            // Create new server
            new Server(8005);
        }    
    }

    
    class Client
    {        
        public Client(TcpClient Client, string Number)
        {
            // String for Request from client
            string Request = "";
            // Input data Buffer array
            byte[] Buffer = new byte[1024];
            // Byte count
            int Count;
            
            Console.WriteLine("Client Number: " + Number);
            try
            {

                while ((Count = Client.GetStream().Read(Buffer, 0, Buffer.Length)) > 0)
                {                    
                    // Convert this data to string and add to Request variable
                    Request += Encoding.ASCII.GetString(Buffer, 0, Count);


                    //We have answer
                    if (Request.IndexOf("Ctrl") >= 0 || Request.IndexOf("q") >= 0 || Request.Length > 4096)                       
                    {
                       
                        Console.WriteLine(Request);                        
                        Console.WriteLine("Get Your Message");
                        Request = Console.ReadLine();   
                       // Console.WriteLine(Request);
                        
                        Buffer = Encoding.ASCII.GetBytes(Request);
                        Client.GetStream().Write(Buffer, 0, Request.Length);                        
                        Request = "";
                    }

                }
            } 
            catch (Exception e)
            {
                Console.WriteLine("Client: " + Number + " is offline");
                Console.WriteLine(e.ToString());
            }         
        }


        /* Check answer from server and return mess type
         *  Input: Request - message from module
         *  Output: 1 - System data type
         *          2 - Action data type
         *          0 - Error
         */
        static int Data_CheckAnswerMess(String Request)
        {
            //we have system data answer
            if (Request.IndexOf('e', Request.IndexOf('q')) == 0)
            {
                return 1;
            }    //we have action message answer
            else if (Request.IndexOf('w', Request.IndexOf('q')) == 0)
            {
                return 2;
            }
            else
                return 0;            
        }
    }
}