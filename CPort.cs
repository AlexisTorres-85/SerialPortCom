using System;
using System.IO.Ports;

namespace MET.COMs.App
{
    public class CPort
    {
        static void Main(string[] args)
        {
            SerialPort Port = new SerialPort
            {
                PortName = "COM8",
                BaudRate = 115200,
                Parity = Parity.None,
                RtsEnable = true,
                DtrEnable = true,
                StopBits = StopBits.One,
                WriteTimeout = 100,
                Handshake = Handshake.None
            };

            byte[] bytes = { 1, 128, 3, 0, 4, 5, 0, 141, 112 };
            Port.Open();
            Port.Write(bytes, 0, bytes.Length);
            int cnt = Port.BytesToRead;
           
            Port.DataReceived += OnReceiveData;
            Console.WriteLine("RX OL(03:38:47.146) : 85 80 02 00 FA 02 01");
            Console.WriteLine("RX OL(03:38:47.198) : 85 80 02 03 E8 01 F2");
            Console.WriteLine("RX OL(03:38:47.202) : 81 80 05 00 99 00 00 16 01 B5");

            Console.WriteLine("---:  129 128 5 0 153 0 0 22 1 181");
            Console.ReadLine();
        }
        
        private static void OnReceiveData(object sender,SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            byte[] buffer = new byte[sp.BytesToRead];
            Console.WriteLine("DATA RECEIVED!");
            sp.Read(buffer, 0, buffer.Length);
            
            foreach (Byte bytes in buffer)
            {
                Console.Write(bytes.ToString() + " ");
            }
        }
    }
}
