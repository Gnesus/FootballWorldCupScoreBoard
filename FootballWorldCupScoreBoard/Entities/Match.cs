using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoard.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Score Score { get; set; }

        /// <summary>
        /// Create new Match on default score 0 - 0
        /// </summary>
        /// <param name="id">ID of match</param>
        /// <param name="homeTeam">Home team name</param>
        /// <param name="awayTeam">Away team name</param>
        public Match(int id,Team homeTeam, Team awayTeam)
        {
            Id = id;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Score = new Score();
        }
    }
}
