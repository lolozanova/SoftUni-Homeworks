using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Common;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        

        public void Call(string number)
        {
            if (!number.All(x=>char.IsDigit(x)))
            {
                throw new ArgumentException(GlobalMessages.InvalidNumberExcMsg);
                
            }
            Console.WriteLine($"Dialing... {number}");

        }
    }
}
