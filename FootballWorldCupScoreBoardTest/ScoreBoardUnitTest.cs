using FootballWorldCupScoreBoard;
using FootballWorldCupScoreBoard.Entities;
using System.Reflection;

namespace FootballWorldCupScoreBoardTest
{
    [TestFixture]
    public class ScoreBoardUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }
        #region StartMatch
        [Test]
        public void StartMatch_ShouldThrowArgumentException_WhenAwayTeamIsNull()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            Assert.Throws<ArgumentNullException>(() => scoreBoard.StartMatch(new Team("Mexico"), null));
        }
        [Test]
        public void StartMatch_ShouldThrowArgumentException_WhenHomeTeamIsNull()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            Assert.Throws<ArgumentNullException>(() => scoreBoard.StartMatch(null, new Team("Canada")));
        }
        #endregion
        #region FinishMatch
        [Test]
        public void FinishMatch_ShouldThrowArgumentException_WhenMatchFinishIsNull()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            Assert.Throws<ArgumentNullException>(() => scoreBoard.FinishMatch(null));
        }

        [Test]
        public void FinishMatch_ScoreBoardMatchesShouldBeTheSame_WhenAMatchCanNotBeNotFound()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.StartMatch(new Team("Mexico"), new Team("Canada"));
            Match matchFinished = new Match(-1, new Team("Spain"), new Team("Brazil"));

            int matchesBeforeFinishMatch = scoreBoard.Matches.Count();

            scoreBoard.FinishMatch(matchFinished);

            Assert.That(matchesBeforeFinishMatch, Is.EqualTo(scoreBoard.Matches.Count()));
        }
        [Test]
        public void FinishMatch_ScoreBoardMatchesShouldHaveALessMatch_WhenAMatchIsFinished()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.StartMatch(new Team("Mexico"), new Team("Canada"));
            Match matchFinished = scoreBoard.Matches[0];
            scoreBoard.UpdateMatch(matchFinished, 0, 5);

            int matchesBeforeFinishMatch = scoreBoard.Matches.Count();

            scoreBoard.FinishMatch(matchFinished);

            Assert.Less(scoreBoard.Matches.Count(), matchesBeforeFinishMatch);
        }
        #endregion
        #region UpdateMatch
        [TestCase(2, 1, 3)]
        [TestCase(0, 2, 2)]
        [TestCase(3, 0, 3)]
        [TestCase(0, 0, 0)]
        public void UpdateMatch_UpdateScoreOfMatchAndTotalScore_WhenHomeAndAwayScoreIsSent(int homeScore, int awayScore, int expected)
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.StartMatch(new Team("Mexico"), new Team("Canada"));
            Match matchToUpdate = scoreBoard.Matches[0];
            scoreBoard.UpdateMatch(matchToUpdate, homeScore, awayScore);

            Assert.That(matchToUpdate.Score.totalScore(), Is.EqualTo(expected));
        }
        #endregion
        #region GetMatchesSummary
        [TestCase(4, 0)]
        [TestCase(2, 1)]
        [TestCase(1, 2)]
        [TestCase(5, 3)]
        [TestCase(3, 4)]
        public void GetMatchesSummary_ScoreBoardMatchesReturnMatchesOrdered_WhenSummaryIsDemanded(int matchId, int expected)
        {
            Match match1 = new Match(1, new Team("Mexico"), new Team("Canada"));
            Match match2 = new Match(2, new Team("Spain"), new Team("Brazil"));
            Match match3 = new Match(3, new Team("Germany"), new Team("France"));
            Match match4 = new Match(4, new Team("Uruguay"), new Team("Italy"));
            Match match5 = new Match(5, new Team("Argentina"), new Team("Australia"));
            ScoreBoard scoreBoard = new ScoreBoard
            {
                Matches = { match1, match2, match3, match4, match5 }
            };

            scoreBoard.UpdateMatch(match1, 0, 5);
            scoreBoard.UpdateMatch(match2, 10, 2);
            scoreBoard.UpdateMatch(match3, 2, 2);
            scoreBoard.UpdateMatch(match4, 6, 6);
            scoreBoard.UpdateMatch(match5, 3, 1);

            List<Match> result = scoreBoard.GetMatchesSummary();

            int matchOrderedIndex = result.IndexOf(result.SingleOrDefault(m => m.Id.Equals(matchId)));

            Assert.That(matchOrderedIndex, Is.EqualTo(expected));
        }
        #endregion
    }
}