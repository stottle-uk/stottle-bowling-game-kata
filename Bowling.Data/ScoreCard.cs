using Bowling.Data.Converter;
using Bowling.Data.Extensions;
using Bowling.Data.Score;
using System;
using System.Collections.Generic;

namespace Bowling.Data
{
    public class ScoreCard
    {
        private readonly IScoreConverter<string, IEnumerable<int>> _converter;
        private readonly IScoreBuilder<IEnumerable<int>, int> _scoreBuilder;

        public ScoreCard(IScoreConverter<string, IEnumerable<int>> converter, IScoreBuilder<IEnumerable<int>, int> scoreBuilder)
        {
            _converter = converter ?? throw new ArgumentNullException("converter");
            _scoreBuilder = scoreBuilder ?? throw new ArgumentNullException("scoreBuilder");
        }

        public int GetScore(string scoreCard)
        {
            if (scoreCard == null)
                throw new ArgumentNullException("scoreCard");

            return scoreCard
                .Then(_converter.Convert)
                .Then(_scoreBuilder.GetScore);
        }
    }
}
