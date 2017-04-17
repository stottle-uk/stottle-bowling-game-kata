using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling.Data.Score;
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
        public void ShouldGetScoreForMixedItems()
        {
            var score = _scoreBuilder.GetScore(new int[] { 10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1 });
            Assert.AreEqual(167, score);
        }

        [TestMethod]
        public void ShouldGetScoreForPerfectGame()
        {
            var score = _scoreBuilder.GetScore(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 });
            Assert.AreEqual(300, score);
        }
    }
}
