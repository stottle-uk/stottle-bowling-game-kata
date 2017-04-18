using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bowling.Data.Converter
{
    public class ScoreConverterLogger : IScoreConverter<string, IEnumerable<int>>
    {
        private readonly ILogger<IScoreConverter<string, IEnumerable<int>>> _logger;
        private readonly IScoreConverter<string, IEnumerable<int>> _converter;

        public ScoreConverterLogger(
            ILogger<IScoreConverter<string, IEnumerable<int>>> logger,
            IScoreConverter<string, IEnumerable<int>> converter)
        {
            _logger = logger ?? throw new ArgumentNullException("logger");
            _converter = converter ?? throw new ArgumentNullException("converter");
        }

        public IEnumerable<int> Convert(string scoreCard)
        {
            try
            {
                _logger.LogDebug($"Converting score card [{scoreCard}]");
                var roles = _converter.Convert(scoreCard);
                _logger.LogDebug($"Converted score card [{scoreCard}] to {JsonConvert.SerializeObject(roles)}:");
                return roles;
            }
            catch (Exception e)
            {
                _logger.LogError(new EventId(), e, $"Converting score card [{scoreCard}] failed");
                throw;
            }
        }
    }
}
