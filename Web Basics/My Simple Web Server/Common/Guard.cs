using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebServerServer.Common
{
    public class Guard
    {

        public static void AgainstNull(object value, string name = null)
        {
            if (value == null)
            {
               
                 throw new ArgumentException("Value cannot be null.");
            }
        }
    }
}
