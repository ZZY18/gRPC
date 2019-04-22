using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Google.Protobuf;
using GRPCDemo;
using gRPCDemo;


namespace client
{
    
    class newproto : gRPC.gRPCBase
    
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }

        public override Task<list1> Getlsit(HelloRequest request, ServerCallContext context)
        {
            ByteString bytestring1 = ByteString.CopyFrom("123",Encoding.Default);
            return Task.FromResult(new list1 { Listbyte=bytestring1 });
        }
    }
    class Program
    {
        const int port = 12321;
        static void Main(string[] args)
        {
            Server server = new Server {
                Services = { gRPC.BindService(new newproto()) },
                Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
            };
            Console.WriteLine("进入服务");
            server.Start();

            Console.WriteLine("gRPC server listening on port " + port);
            Console.WriteLine("任意键退出...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();

        }
    }
}
