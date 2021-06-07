using MyWebServerServer;
using MyWebServerServer.HTTP;
using MyWebServerServer.Results;
using System;
using System.Threading.Tasks;

namespace WebServer
{
    class StartUp
    {
        static async Task Main()
        {

            HttpServer server = new HttpServer(routes => routes
                .MapGet("/", new TextResponse("Welcome to my simple web site"))
                .MapGet("/Products", new TextResponse("These are my products")));

            await server.Start();

            

        }
    }
}
