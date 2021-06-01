using MyWebServerServer.HTTP;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServerServer
{
   
    public class Server
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        TcpListener tcpListener;

        public Server(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.tcpListener = new TcpListener(this.ipAddress, port);

        }

        public async Task Start()
        {
            this.tcpListener.Start();

            while (true)
            {
                var client = await this.tcpListener.AcceptTcpClientAsync();


                using (var stream = client.GetStream())
                {

                    var requestString = await this.ReadRequest(stream);

                    Console.WriteLine(requestString);

                    var request = HttpRequest.Parse(requestString);

                    await this.WriteResponse(stream);
                }
            }

        }

        public async Task<string> ReadRequest(NetworkStream stream)
        {

            var buffer = new byte[1024];


            StringBuilder requestBuilder = new StringBuilder();

            while (stream.DataAvailable)
            {
                var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }

            return requestBuilder.ToString();
        }

        public async Task WriteResponse(NetworkStream stream)
        {

            var responseBody = "Добър ден!";

            var response = $"HTTP/1.1 200 Ok" + "\r\n" +
                $"Server: My Simple Server" + "\r\n" +
                $"Content-Length: {Encoding.UTF8.GetByteCount(responseBody)}" + "\r\n" +
                $"Content-Type: text/plain; charset=UTF-8"
              + "\r\n" + "\r\n" +
            responseBody;


            var responseBytes = Encoding.UTF8.GetBytes(response);

             stream.Write(responseBytes);

        }

    }
}
