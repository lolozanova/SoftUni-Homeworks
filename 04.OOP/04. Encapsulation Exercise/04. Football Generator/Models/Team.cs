using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private readonly ICollection<Player> players;

        public Team(string name)
        {
            this.players = new List<Player>();
            this.Name = name;

        }
        

        public string Name
        {
            get
            {
                return this.name;
            }
           private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstans.InvalidNameExcMsg);
                }

                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (players.Count>0)
                {
                    return (int)Math.Round(this.players.Average(p => p.SkillLevel));
                }

                return 0;
                
            }
        }  
        
        public void AddPlayer (Player player)
        {
            
            players.Add(player);
        }

        public void RemovePlayer(string teamName, string playerName)
        {
           

            if (players.Any(p => p.Name == playerName))

            {
                Player player = this.players.FirstOrDefault(p => p.Name == playerName);
                this.players.Remove(player);
            }
            else
            {
                throw new InvalidOperationException(String.Format(GlobalConstans.MissingPlayerExcMsg, playerName, teamName));
            }


        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
