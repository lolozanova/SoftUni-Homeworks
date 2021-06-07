using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServerServer.HTTP
{
   public abstract class HttpResponse
    {

        public HttpResponse(HttpStatusCode httpStatus)
        {
            this.Statuscode = httpStatus;
            this.Headers.Add("Server", "My Web Server");
            this.Headers.Add("Date", $"{DateTime.UtcNow:r}");

        }
        public HttpStatusCode Statuscode { get; protected set; }

        public HttpHeaderCollection Headers { get; protected set; } = new HttpHeaderCollection();

        public string Content { get; protected set; }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"HTTP/1.1 {(int)this.Statuscode} {this.Statuscode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }

            if (!string.IsNullOrEmpty(this.Content))
            {
                result.AppendLine();

                result.Append(this.Content);
            }
            

            return result.ToString();
        }
    }
}
