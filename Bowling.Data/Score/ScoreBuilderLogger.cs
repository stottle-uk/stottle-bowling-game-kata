using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bowling.Data.Score
{
    public class ScoreBuilderLogger : IScoreBuilder<IEnumerable<int>, int>
    {
        private readonly ILogger<IScoreBuilder<IEnumerable<int>, int>> _logger;
        private readonly IScoreBuilder<IEnumerable<int>, int> _scoreBuilder;

        public ScoreBuilderLogger(
            ILogger<IScoreBuilder<IEnumerable<int>, int>> logger,
            IScoreBuilder<IEnumerable<int>, int> scoreBuilder)
        {
            _logger = logger ?? throw new ArgumentNullException("logger");
            _scoreBuilder = scoreBuilder ?? throw new ArgumentNullException("scoreBuilder");
        }

        public int GetScore(IEnumerable<int> rolls)
        {
            try
            {
                _logger.LogDebug($"Building score from rolls {JsonConvert.SerializeObject(rolls)}");
                var score = _scoreBuilder.GetScore(rolls);
                _logger.LogDebug($"Built score from rolls {JsonConvert.SerializeObject(rolls)} - score is {score}");
                return score;
            }
            catch (Exception e)
            {
                _logger.LogError(new EventId(), e, $"Building score from rolls failed {JsonConvert.SerializeObject(rolls)}");
                throw;
            }
        }
    }
}
