using Bowling.Data;
using Bowling.Data.Convert;
using Bowling.Data.Score;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerScoreCard = GetPlayerScoreCard("X|7/|9-|X|-8|8/|-6|X|X|X||81");

            var converter = new ConverterLogger(
                CreateLogger<IConverter<string, IEnumerable<int>>>(LogLevel.Debug),
                new Converter()
                );

            var scoreBuilder = new ScoreBuilderLogger(
                CreateLogger<IScoreBuilder<IEnumerable<int>, int>>(LogLevel.Debug),
                new ScoreBuilder()
                );

            var score = new ScoreCard(converter, scoreBuilder)
                .GetScore(playerScoreCard);

            Console.WriteLine($"\n\nTotal Score: {score}");
            Console.ReadLine();
        }

        private static string GetPlayerScoreCard(string defaultScoreCard)
        {
            Console.WriteLine($"Enter score card - hit return for default: {defaultScoreCard}");
            var userInput = Console.ReadLine();
            return string.IsNullOrWhiteSpace(userInput) ? defaultScoreCard : userInput;
        }

        private static ILogger<T> CreateLogger<T>(LogLevel loggingLevel)
        {
            var loggerFactory = new LoggerFactory()
                .AddConsole(loggingLevel);

            return loggerFactory.CreateLogger<T>();
        }
    }
}
