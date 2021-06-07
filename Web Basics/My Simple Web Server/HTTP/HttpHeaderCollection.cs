using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWebServerServer.HTTP
{
   public class HttpHeaderCollection : IEnumerable<HttpHeader>
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public int Count => this.headers.Count;

        public void Add(string name, string value)
        {
            var header = new HttpHeader(name, value);
            this.headers.Add(header.Name, header);
        }

        public bool Contains(string cookieName)
        {
            if (!headers.ContainsKey(cookieName))
            {
                return false;
            }
            
            return true;
        }

        public IEnumerator<HttpHeader> GetEnumerator()
        {
            return this.headers.Values.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
          return  this.GetEnumerator();
        }
    }
}
