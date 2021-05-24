using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
   public class Warrior : BaseHero
    {
        private const int power = 100; 
        public Warrior(string name) : base(name)
        {
        }

        public override int Power => power;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
