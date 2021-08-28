using System;
using System.Threading.Tasks;
using AristovaHttp.Models;
using AristovaHttp.Services;
using Newtonsoft.Json;

namespace AristovaHttp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string token = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoi0JHQvtCz0LTQsNC9IiwidGVuYW50IjoiNzI5IiwibmJmIjoxNjMwMTQ1MjYxLCJleHAiOjE2MzAyMzE2NjEsImlzcyI6IlRlc3QtQmFja2VuZC0xIiwiYXVkIjoiQmFza2V0QmFsbENsdWJTYW1wbGUifQ.i1Gd8kgAbJYiWJwrReDgy5ldjCy7MQ3CgNsbyVbOMiI";

            TeamService teamService = new TeamService(token);

            Team team = new Team()
            {
                Name = "Liverpool",
                FoundationYear = 1998,
                Division = "ghvj",
                Conference = "klj",
                ImageUrl = "myImage"
            };

            await teamService.Add(team);
            var dataTeams=teamService.GetTeams().Result.Data;

            Player player = new Player()
            {
                Name = "Davids",
                Number = 11,
                Position = "Forward",
                Team = 530,
                Birthday=Convert.ToDateTime("11.05.1975"),
                Height=191,
                Weight=75,
                AvatarUrl="myUrl"
             };

            PlayerService playerService = new PlayerService(token);
            await playerService.Add(player);
            var dataPlayers = playerService.GetPlayers().Result.Data;
        }
    }
}
