using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Common
{
   public static class ExceptionMsg
    {
        public const string NotEnougnFuel = "{0} needs refueling";
        public const string WrongAmountFuel = "Cannot fit {0} fuel in the tank";
        public const string NegativeAmountFuel = "Fuel must be a positive number";

    }
}
