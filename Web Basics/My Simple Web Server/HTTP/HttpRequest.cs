using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWebServerServer.HTTP
{
    public class HttpRequest
    {
        private const string NewLine = "\r\n";

        
        public HttpMethod Method { get; private set; }

        public string Path { get; private set; }

        public HttpHeaderCollection Headers { get; private set; }

        public string Body { get; private set; }


        public static HttpRequest Parse(string request)
        {
            var lines = request.Split(NewLine);

            var startLine = lines[0].Split(" ");

            var method = ParseMethod(startLine[0]);

            var url = startLine[1];

            var headers = ParseHttpHeaderCollection(lines.Skip(1));

            var bodyLines = lines.Skip(headers.Count + 2).ToArray();

            var body = string.Join(NewLine, bodyLines);

            return new HttpRequest
            {
                Method = method,
                Path = url,
                Headers = headers,
                Body = body
            };


        }

        private static HttpMethod ParseMethod(string method)
        {
            switch (method.ToLower())
            {
                case "get":
                    return HttpMethod.Get;

                case "post":
                    return HttpMethod.Post;

                case "put":
                    return HttpMethod.Put;
                case "delete":
                    return HttpMethod.Delete;
                default:
                    throw new System.InvalidOperationException();

            }

        }

        private static HttpHeaderCollection ParseHttpHeaderCollection(IEnumerable<string> headerLines)
        {
            var headers = new HttpHeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(": ");
                var header = new HttpHeader
                {
                    Name = headerParts[0],
                    Value = headerParts[1]
                };

                headers.Add(header);
            }

            return headers;
           
        }
        //   private static string[] GetStartLine
    }
}
