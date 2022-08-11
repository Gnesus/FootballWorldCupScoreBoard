using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoard.Entities
{
    public class Score
    {
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        /// <summary>
        /// Create new Score on default values 0 - 0
        /// </summary>
        public Score()
        {
            HomeScore = 0;
            AwayScore = 0;
        }
        /// <summary>
        /// Get total scores
        /// </summary>
        /// <returns>Total score</returns>
        public int totalScore()
        {
            return HomeScore + AwayScore;
        }
    }
}
