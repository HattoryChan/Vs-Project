using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Ozone_Meas_system__concole_
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort port;
            string[] ports = SerialPort.GetPortNames();

            Console.WriteLine("Choose your port:");

            for (int i = 0; i < ports.Length; i++)
                Console.WriteLine("[" + i.ToString() + "]" + ports[i].ToString());

            port = new SerialPort();

            string n = Console.ReadLine();
            int num = int.Parse(n);

            try
            {
                // настройки порта
                port.PortName = ports[num];
                port.BaudRate = 1200;
                port.DataBits = 8;
                port.Parity = System.IO.Ports.Parity.None;
                port.StopBits = System.IO.Ports.StopBits.One;
                port.ReadTimeout = 1000;
                port.WriteTimeout = 1000;
                port.ReadBufferSize = 256;
                port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                port.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: невозможно открыть порт:" + e.ToString());
                return;
            }
            SendDataCOM(port);

            Console.WriteLine();
            // Console.WriteLine($"Port {ports[num].ToString()} Close");
            System.Threading.Thread.Sleep(1000);
           



            Console.WriteLine("Success!");
            Console.ReadKey();

        }
        public static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
              System.Threading.Thread.Sleep(100);
              SerialPort port = (SerialPort)sender;            
              int bufferSize = port.BytesToRead;
              var buffer = new char[bufferSize];

              port.Read(buffer, 0, bufferSize);            
        }
        public static void SendDataCOM(SerialPort port)
        {
            // Send data part
            var buffer = new char[12];
            Console.Write("\nEnter 10 sending symbol: ");
            for (int i = 0; i < 10; i++)
            { 
                buffer[i] = Convert.ToChar(Console.Read());
                Console.Write(buffer[i]);
            }
            Console.Write("\n");
            
            int CRCVal = '0';
            for (int i = 0; i < 10; i++)
                CRCVal = (CRCVal + buffer[i] * 211) / 123;

            buffer[10] = (char)CRCVal;
            buffer[11] = (char)CRCVal;

            for (int i = 0; i < 12; i++)
            {
                Console.Write(buffer[i]);
                port.Write(buffer, 0, buffer.Length);
            }

        }
    }
}
