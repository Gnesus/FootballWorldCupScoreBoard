using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoard.Entities
{
    public class Team
    {
        public string Name { get; set; }

        /// <summary>
        /// Create new Team with provided name
        /// </summary>
        /// <param name="name">Name of team</param>
        public Team(string name)
        {
            Name = name;
        }
    }
}
