using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Common;
using Telephony.Interfaces;

namespace Telephony.Models
{
    class SmartPhone : IBrowsable
    {

        public void Browse(string url)
        {
            if (url.Any(x=>char.IsDigit(x)))
            {
                throw new ArgumentException(GlobalMessages.InvalidSiteExcMsg);
            }
            Console.WriteLine($"Browsing: {url}!");
        }


        public void Call(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new ArgumentException(GlobalMessages.InvalidNumberExcMsg);
            }
            Console.WriteLine($"Calling... {number}");

        }
    }
}
