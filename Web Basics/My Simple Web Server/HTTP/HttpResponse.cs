using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServerServer.HTTP
{
   public class HttpResponse
    {
        public HttpStatus Statuscode { get; private set; }

        public HttpHeaderCollection Headers { get; private set; }

        public string Content { get; private set; }

        public HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
        }
    }
}
