using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint dcsv = new IPEndPoint(IPAddress.Parse("127.0.1"), 1234);
            sk.Connect(dcsv);
            NetworkStream ns = new NetworkStream(sk);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.WriteLine("hello server");
            sw.Flush();

            Console.WriteLine(sr.ReadLine());

            while (true)
            {
                Console.WriteLine("Nhap vao 2 so:");
                string data = Console.ReadLine();
                sw.WriteLine(data);
                sw.Flush();
                if (data.Equals("bye"))
                {
                    Console.WriteLine("exit");
                    break;
                }
                Console.WriteLine(sr.ReadLine());

            }
            sw.Close();
            sr.Close();
            ns.Close();
            sk.Close();

            Console.ReadLine();

        }
    }
}
