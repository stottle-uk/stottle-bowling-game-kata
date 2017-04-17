using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling.Data.Convert;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Data.Tests.Convert
{
    [TestClass]
    public class ConverterTests
    {
        private IConverter<string, IEnumerable<int>> _converter;

        [TestInitialize]
        public void Initialize()
        {
            _converter = new Converter();
        }

        [TestMethod]
        public void ShouldConvertScoreCardOfMixedItems()
        {
            var items = _converter.Convert("X|7/|9-|X|-8|8/|-6|X|X|X||81");
            var result = new List<int>() { 10,7,3,9,0,10,0,8,8,2,0,6,10,10,10,8,1 };

            for (int i = 0; i < items.Count(); i++)
            {
                Assert.AreEqual(result.ElementAt(i), items.ElementAt(i));
            }
        }

        [TestMethod]
        public void ShouldConvertPerfectScoreCard()
        {
            var items = _converter.Convert("X|X|X|X|X|X|X|X|X|X||XX");

            for (int i = 0; i < items.Count(); i++)
            {
                Assert.AreEqual(10, items.ElementAt(i));
            }
        }

        [TestMethod]
        public void ShouldConvertScoreCardOfSpares()
        {
            var items = _converter.Convert("5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5");

            for (int i = 0; i < items.Count(); i++)
            {
                Assert.AreEqual(5, items.ElementAt(i));
            }
        }

        [TestMethod]
        public void ShouldConvertScoreCardOf9()
        {
            var items = _converter.Convert("9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||");

            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                    Assert.AreEqual(9, items.ElementAt(i));
                else
                    Assert.AreEqual(0, items.ElementAt(i));
            }

            Assert.AreEqual(0, items.ElementAt(20));
        }
    }
}
