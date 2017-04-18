using Bowling.Data.Score;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Bowling.Data.Tests.Convert
{
    [TestClass]
    public class ScoreBuilderTests
    {
        private IScoreBuilder<IEnumerable<int>, int> _scoreBuilder;

        [TestInitialize]
        public void Initialize()
        {
            _scoreBuilder = new ScoreBuilder();
        }

        [TestMethod]
        public void ShouldReturn167ForMixedItems()
        {
            var score = _scoreBuilder.GetScore(new int[] { 10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1 });
            Assert.AreEqual(167, score);
        }

        [TestMethod]
        public void ShouldReturn300ForPerfectGame()
        {
            var score = _scoreBuilder.GetScore(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 });
            Assert.AreEqual(300, score);
        }

        [TestMethod]
        public void ShouldReturn150ForGameOfSpares()
        {
            var score = _scoreBuilder.GetScore(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 });
            Assert.AreEqual(150, score);
        }

        [TestMethod]
        public void ShouldReturn90ForGameOfSpares()
        {
            var score = _scoreBuilder.GetScore(new int[] { 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 0 });
            Assert.AreEqual(90, score);
        }
    }
}
