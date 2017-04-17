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
                    total += getBonus(rolls, rollIndex);
                    rollIndex++;
                }
                else if (isSpare(rolls, rollIndex))
                {
                    total += getBonus(rolls, rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    total += rolls.ElementAt(rollIndex) + rolls.ElementAt(rollIndex + 1);
                    rollIndex += 2;
                }
            }
            return total;
        }

        private bool isStrike(IEnumerable<int> rolls, int rollIndex) =>
            rolls.ElementAt(rollIndex) == 10;

        private bool isSpare(IEnumerable<int> rolls, int rollIndex) =>
            rolls.ElementAt(rollIndex) + rolls.ElementAt(rollIndex + 1) == 10;

        private int getBonus(IEnumerable<int> rolls, int rollIndex) =>
            rolls
            .Skip(rollIndex)
            .Take(3)
            .Sum();
    }
}
