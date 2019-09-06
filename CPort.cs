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
            for (int i = 0; i < cnt; i++)
            {
                Console.WriteLine(Port.ReadByte());
            }

            Console.ReadLine();
        }
    }
}
