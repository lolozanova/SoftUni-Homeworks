using MyWebServerServer.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServerServer.Routing
{
   public interface IRoutingTable
    {

        IRoutingTable Map(string url,HttpMethod httpMethod, HttpResponse httpResponse);

        IRoutingTable MapGet(string url, HttpResponse response);
    }
}
