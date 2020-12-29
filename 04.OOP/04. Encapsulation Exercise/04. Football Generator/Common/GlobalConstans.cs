using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Common
{
    public static class GlobalConstans
    {
        public const string InvalidNameExcMsg = "A name should not be empty.";

        public const string InvalidStatsExcMsg = "{0} should be between 0 and 100.";

        public const string MissingPlayerExcMsg = "Player {0} is not in {1} team.";

        public const string  MissingTeamExcMsg = "Team {0} does not exist.";
    }
}
