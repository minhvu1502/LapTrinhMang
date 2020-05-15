using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MinMax
{
    class Program
    {
        static void Main(string[] args)
        {
            //2. TCP listener, min max 2 so
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.1"), 1234);
            TcpListener listener = new TcpListener(iPEndPoint);
            listener.Start();
            Socket sk = listener.AcceptSocket();

            NetworkStream ns = new NetworkStream(sk);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            String dl = sr.ReadLine();
            Console.WriteLine(dl);

            sw.WriteLine("hello client");
            sw.Flush();
            while (true)
            {
                String result;
                String haiSo = sr.ReadLine();
                if (haiSo.Equals("bye"))
                {
                    Console.WriteLine("exit");
                    break;
                }
                Int16 a = Int16.Parse(haiSo.Split()[0]);
                Int16 b = Int16.Parse(haiSo.Split()[1]);
                if (a > b)
                {
                    result = "Max: " + a + ", Min: " + b;
                }
                else
                {
                    result = "Max: " + b + ", Min: " + a;
                }
                Console.WriteLine(result);
                sw.WriteLine(result);
                sw.Flush();
            }
            sw.Close();
            sr.Close();
            ns.Close();
            sk.Close();
            
            Console.ReadLine();
        }
    }
}
