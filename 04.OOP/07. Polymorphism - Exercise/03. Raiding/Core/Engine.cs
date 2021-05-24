using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine
    {
        private readonly List<BaseHero> raidGroup;
        BaseHero currHero = null;

        public Engine()
        {
            raidGroup = new List<BaseHero>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            while (raidGroup.Count < n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                if (heroType == "Druid")
                {
                    BaseHero currHero = new Druid(heroName);
                    raidGroup.Add(currHero);

                }
                else if (heroType == "Paladin")
                {
                    BaseHero currHero = new Paladin(heroName);
                    raidGroup.Add(currHero);

                }
                else if (heroType == "Rogue")
                {
                    BaseHero currHero = new Rogue(heroName);
                    raidGroup.Add(currHero);

                }
                else if (heroType == "Warrior")
                {
                    BaseHero currHero = new Warrior(heroName);
                    raidGroup.Add(currHero);

                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }

            }

            int bossPower = int.Parse(Console.ReadLine());
            int totalPower = 0;
            foreach (BaseHero hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                totalPower += hero.Power;
            }

            if (totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
