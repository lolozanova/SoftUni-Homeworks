using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;



        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get
            {
                return name;
            }
           private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstans.InvalidNameExcMsg);
                }
                name = value;
            }
        }

        public int Endurance
        {
            get
            {
                return endurance;
            }
            private set
            {
                ValidateStat(nameof(Endurance), value);

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return sprint;
            }

            private set
            {
                ValidateStat(nameof(Sprint), value);
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return dribble;
            }

           private set
            {
                ValidateStat(nameof(Dribble), value);
                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return passing;
            }
            private set
            {
                ValidateStat(nameof(Sprint), value);
                passing = value;
            }
        }

        public int Shooting 
        {
            get
            {
                return shooting;
            }
            private set 
            {
                ValidateStat(nameof(Shooting), value);
                shooting = value; 

            }
        }

       public double SkillLevel {
            get
            { 
                return (endurance + sprint + dribble + passing + shooting) / 5.0;
            }
        }
        private void ValidateStat(string name, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException(String.Format(GlobalConstans.InvalidStatsExcMsg, name));
            }
        }
    }
}
