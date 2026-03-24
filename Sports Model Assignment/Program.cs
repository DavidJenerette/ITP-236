using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using SportsModel;

namespace SportsModelAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Team.MyNameIs);
            Console.WriteLine("*************************");
            XDocument doc = XDocument.Load("SportsModel.xml");
            List<Team> teams;
            List<Player> players;
            List<Roster> rosters;

            teams = doc.Descendants("Team")
                .Select(t => new Team
                {
                    TeamId = (int)t.Element("TeamId"),
                    Name = (string)t.Element("Name"),
                    ShortName = (string)t.Element("ShortName")
                }).ToList();

            rosters = doc.Descendants("Roster")
                .Select(r => new Roster
                {
                    RosterId = (int)r.Element("RosterId"),
                    TeamId = (int)r.Parent.Parent.Element("TeamId"),
                    PlayerId = (int)r.Element("PlayerId")
                }).ToList();

            players = doc.Descendants("Player")
                .Select(p => new Player
                {
                    PlayerId = (int)p.Element("PlayerId"),
                    FirstName = (string)p.Element("FirstName"),
                    LastName = (string)p.Element("LastName"),
                    IsActivePlayer = (int)p.Element("IsActivePlayer") == 1,
                    Email = (string)p.Element("Email"),
                    Phone = (string)p.Element("Phone"),
                    NickName = (string)p.Element("NickName"),
                    IsOptInEmail = (int)p.Element("IsOptInEmail") == 1,
                    BirthDate = (DateTime?)p.Element("BirthDate"),
                    City = (string)p.Element("City"),
                    ZipCode = (string)p.Element("ZipCode")
                })
                .GroupBy(p => p.PlayerId)   // remove duplicates
                .Select(g => g.First())
                .ToList();

            foreach (var roster in rosters)
            {
                roster.Team = teams.FirstOrDefault(t => t.TeamId == roster.TeamId);
                roster.Player = players.FirstOrDefault(p => p.PlayerId == roster.PlayerId);
            }

            foreach (var team in teams)
            {
                team.Rosters = rosters
                    .Where(r => r.TeamId == team.TeamId)
                    .ToList();
            }

            foreach (var player in players)
            {
                player.Rosters = rosters
                    .Where(r => r.PlayerId == player.PlayerId)
                    .ToList();
            }

            var results = teams
                .Select(t => new
                {
                    Team = t,
                    Players = t.Rosters.Select(r => r.Player)
                });

            foreach (var item in results)
            {
                Console.WriteLine($"Team: {item.Team.Name}");

                foreach (var player in item.Players)
                {
                    Console.WriteLine($"   - {player.FirstName} {player.LastName}");
                }

                Console.WriteLine();
            }            
            Console.WriteLine("Press Any Key to End Program");
            Console.ReadKey();

        }
    }
}