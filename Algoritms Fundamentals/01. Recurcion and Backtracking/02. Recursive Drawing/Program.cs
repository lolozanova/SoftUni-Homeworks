using System;

namespace _02._Recursive_Drawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Print(n);
        }

        public static void Print(int n)
            {
            if (n<=0)
            {
                return;
            }
            Console.WriteLine(new string('*', n));
            Print(n - 1);
            Console.WriteLine(new string('#', n));
        }
    }
}
