using FootballWorldCupScoreBoard.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoard
{
    public class ScoreBoard
    {
        public List<Match> Matches { get; set; } = new List<Match>();

        /// <summary>
        /// Start a match
        /// </summary>
        /// <param name="homeTeam">Home team</param>
        /// <param name="awayTeam">Away team</param>
        /// <exception cref="ArgumentNullException">Argument is null</exception>
        public void StartMatch(Team homeTeam, Team awayTeam)
        {
            if (homeTeam == null) throw new ArgumentNullException(nameof(homeTeam));
            if (awayTeam == null) throw new ArgumentNullException(nameof(awayTeam));

            Matches.Add(new Match(Matches.Count + 1, homeTeam, awayTeam));
        }
        /// <summary>
        /// Finish a match
        /// </summary>
        /// <param name="match">Match to finish</param>
        /// <exception cref="ArgumentNullException">Argument is null</exception>
        public void FinishMatch(Match match)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));

            if (Matches.Any())
            {
                Match matchToFinish = Matches.Where(m => m.Id.Equals(match.Id))
                    .First();

                if (matchToFinish != null)
                {
                    Matches.Remove(matchToFinish);
                }
            }
        }
        /// <summary>
        /// Updates scores of a match
        /// </summary>
        /// <param name="match">Match to update</param>
        /// <param name="homeScore">Home score</param>
        /// <param name="awayScore">Away score</param>
        /// <exception cref="ArgumentNullException">Argument is null</exception>
        public void UpdateMatch(Match match, int homeScore, int awayScore)
        {
            if (match == null) throw new ArgumentNullException(nameof(match));

            if (Matches.Any())
            {
                Match matchToUpdate = Matches.Where(m => m.Id.Equals(match.Id))
                    .First();

                if (matchToUpdate != null)
                {
                    matchToUpdate.Score.HomeScore = homeScore;
                    matchToUpdate.Score.AwayScore = awayScore;
                }

            }

        }
        /// <summary>
        /// Get matches summary ordered by total score,id
        /// </summary>
        /// <returns>Matches ordered by score,id</returns>
        public List<Match> GetMatchesSummary()
        {
            List<Match> orderedMatches = new List<Match>();

            if (Matches.Any())
            {
                orderedMatches = Matches.OrderByDescending(m => m.Score.totalScore())
                    .ThenByDescending(m => m.Id)
                    .ToList();
            }

            return orderedMatches;
        }
    }
}
