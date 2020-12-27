using System;

namespace _04._CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList myList = new RandomList() { "mihgyutxe", "byuftrt", "byguyv", "buyfyc" };
            Console.WriteLine(myList.RandomString());
        }
    }
}
