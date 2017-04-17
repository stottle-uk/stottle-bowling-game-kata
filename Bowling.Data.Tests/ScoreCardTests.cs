using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Bowling.Data.Convert;
using Bowling.Data.Score;

namespace Bowling.Data.Tests
{
    [TestClass]
    public class ScoreCardTests
    {
        private ScoreCard _scoreCard;

        [TestInitialize]
        public void Initialize()
        {
            _scoreCard = new ScoreCard(new Converter(), new ScoreBuilder());
        }

        [TestMethod]
        public void ShouldScore167()
        {
            Assert.AreEqual(167, _scoreCard.GetScore("X|7/|9-|X|-8|8/|-6|X|X|X||81"));
        }

        [TestMethod]
        public void ShouldScore300()
        {
            Assert.AreEqual(300, _scoreCard.GetScore("X|X|X|X|X|X|X|X|X|X||XX"));
        }

        [TestMethod]
        public void ShouldScore150()
        {
            Assert.AreEqual(150, _scoreCard.GetScore("5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5"));
        }

        [TestMethod]
        public void ShouldScore90()
        {
            Assert.AreEqual(90, _scoreCard.GetScore("9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||"));
        }

        [TestMethod]
        public void ShouldScore48()
        {
            Assert.AreEqual(48, _scoreCard.GetScore("X|7/|9-|--|--|--|--|--|--|--||"));
        }

        [TestMethod]
        public void ShouldScore19()
        {
            Assert.AreEqual(19, _scoreCard.GetScore("--|--|--|--|--|--|--|--|--|X||81"));
        }
    }
}
