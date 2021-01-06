using System;
using Telephony.Models;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            for (int i = 0; i < numbers.Length; i++)
            {
                string currNumber = numbers[i];

                try
                {
                    if (currNumber.Length == 7)
                    {
                        StationaryPhone stationaryPhone = new StationaryPhone();
                        stationaryPhone.Call(currNumber);
                    }
                    else if (currNumber.Length == 10)
                    {
                        SmartPhone smartPhone = new SmartPhone();
                        smartPhone.Call(currNumber);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message); ;
                }
            }

            string[] sites = Console.ReadLine().Split();

            for (int i = 0; i < sites.Length; i++)
            {
                string url = sites[i];
                try
                {
                    SmartPhone smartPhone = new SmartPhone();
                    smartPhone.Browse(url);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message); 
                }
                
            }
        }
    }
}
