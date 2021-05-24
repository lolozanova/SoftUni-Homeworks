using System;
using WildFarm.Core;
using WildFarm.Models.Animals;
using WildFarm.Models.Food;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Engine engine = new Engine();

            engine.Run();
            
        }
    }
}
