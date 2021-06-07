using MyWebServerServer.Common;
using MyWebServerServer.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServerServer.Results
{
    public class TextResponse : HttpResponse
    {
        public TextResponse(string text, string contentType) 
            : base(HttpStatusCode.OK)
        {
            Guard.AgainstNull(text);

            this.Headers.Add("Content-Type", contentType);
            this.Headers.Add("Content - Length",  Encoding.UTF8.GetByteCount(text).ToString());

            this.Content = text;
        }

        public TextResponse(string text)
            :this(text, "text/plain' charset=UTF-8")
        {
            
        }
    }
}
