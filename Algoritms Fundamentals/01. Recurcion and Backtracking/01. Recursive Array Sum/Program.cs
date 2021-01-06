using System;
using System.Linq;

namespace _01._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine( CalculateSum(array, 0));
        }

        public static int CalculateSum(int [] array, int index)
        {
            if (index == array.Length-1)
            {
                return array[index];
            }
           int result = array[index] + CalculateSum(array, index+1);
            return result;
        }
    }
}
