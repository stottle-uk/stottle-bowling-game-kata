using System.Collections.Generic;
using System.Linq;

namespace Bowling.Data.Score
{
    public class ScoreBuilder : IScoreBuilder<IEnumerable<int>, int>
    {
        public int GetScore(IEnumerable<int> rolls)
        {
            var total = 0;
            var rollIndex = 0;
            for (var i = 0; i < 10; i++)
            {
                if (isStrike(rolls, rollIndex))
                {
                    total += getPoints(rolls, rollIndex, 3);
                    rollIndex++;
                }
                else if (isSpare(rolls, rollIndex))
                {
                    total += getPoints(rolls, rollIndex, 3);
                    rollIndex += 2;
                }
                else
                {
                    total += getPoints(rolls, rollIndex, 2);
                    rollIndex += 2;
                }
            }
            return total;
        }

        private bool isStrike(IEnumerable<int> rolls, int rollIndex) =>
            rolls.ElementAt(rollIndex) == 10;

        private bool isSpare(IEnumerable<int> rolls, int rollIndex) =>
            rolls.ElementAt(rollIndex) + rolls.ElementAt(rollIndex + 1) == 10;

        private int getPoints(IEnumerable<int> rolls, int rollIndex, int take) =>
            rolls
            .Skip(rollIndex)
            .Take(take)
            .Sum();
    }
}
