using System;
using System.Collections.Generic;
using System.Linq;


using FootballTeamGenerator.Models;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private readonly List<Team> teams;
        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(';');

                if (commandArgs[0] == "Team")
                {
                    string teamName = commandArgs[1];
                    try
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (commandArgs[0] == "Add")
                {
                    string teamName = commandArgs[1];
                    string playerName = commandArgs[2];
                    int endurance = int.Parse(commandArgs[3]);
                    int sprint = int.Parse(commandArgs[4]);
                    int dribble = int.Parse(commandArgs[5]);
                    int passing = int.Parse(commandArgs[6]);
                    int shooting = int.Parse(commandArgs[7]);

                    try
                    {
                        ValidateTeam(teamName);
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        Team currTeam = teams.First(t => t.Name == teamName);
                        currTeam.AddPlayer(player);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }


                }
                else if (commandArgs[0] == "Remove")
                {
                    string teamName = commandArgs[1];
                    string playerName = commandArgs[2];

                    try
                    {
                        ValidateTeam(teamName);
                        Team team = teams.First(t => t.Name == teamName);
                        team.RemovePlayer(teamName, playerName);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }

                else if (commandArgs[0] == "Rating")
                {
                    string teamName = commandArgs[1];
                    try
                    {
                        ValidateTeam(teamName);
                        Team team = teams.First(t => t.Name == teamName);
                        Console.WriteLine(team);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }

            }
        }

        private void ValidateTeam(string teamName)
        {
            if (!teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException(String.Format(GlobalConstans.MissingTeamExcMsg, teamName));
            }
        }
    }
}
