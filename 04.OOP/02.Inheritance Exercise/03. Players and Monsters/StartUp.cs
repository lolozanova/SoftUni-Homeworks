using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Elf elf = new Elf("Liz", 15);

         Console.WriteLine(elf);

            BladeKnight knight = new BladeKnight("Dark" , 45);
            Console.WriteLine(knight);
        }
    }
}