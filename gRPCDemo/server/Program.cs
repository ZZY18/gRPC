using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gRPCDemo;
using Grpc.Core;
using GRPCDemo;
using Google.Protobuf;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channle = new Channel("127.0.0.1:12321", ChannelCredentials.Insecure);
            var client = new gRPC.gRPCClient(channle);
            var result = client.SayHello(new HelloRequest { Name = "niming" }) as HelloReply;
            var result1 = client.Getlsit(new HelloRequest { Name="123456"}) as list1;
            string a = result1.Listbyte.ToString(Encoding.Default);
            Console.WriteLine(a);

            channle.ShutdownAsync().Wait();
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}
