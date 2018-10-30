using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpiderCardGame.Data;

namespace SpiderCardGame.UnitTest
{
    [TestClass]
    public class ScoreTest
    {
        [TestMethod]
        public void ScoreConstructorTest()
        {
            Score score = new Score();
            
            Assert.AreEqual(500, score.Scores);
        }

        [TestMethod]
        public void GetMovePenaltyTest()
        {
            Score score = new Score();

            score.GetMovePenalty();

            Assert.AreEqual(499, score.Scores);
            Assert.AreEqual(1, score.MoveCount);
        }

        [TestMethod]
        public void GetHintPenaltyTest()
        {
            Score score = new Score();

            score.GetHintPenalty();

            Assert.AreEqual(499, score.Scores);
        }

        [TestMethod]
        public void GetOneCardSetScoreTest()
        {
            Score score = new Score();

            score.GetOneCardSetScore();

            Assert.AreEqual(600, score.Scores);
            Assert.AreEqual(1, score.CardSetCount);
        }

        [TestMethod]
        public void IsGameOverTest()
        {
            Score score = new Score();

            bool b1 = score.IsGameOver();

            score.Scores = 0;
            bool b2 = score.IsGameOver();

            Assert.AreEqual(b1, false);
            Assert.AreEqual(b2, true);
        }
    }
}
