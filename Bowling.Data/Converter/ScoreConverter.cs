using System.Collections.Generic;
using System.Linq;

namespace Bowling.Data.Converter
{
    public class ScoreConverter : IScoreConverter<string, IEnumerable<int>>
    {
        public IEnumerable<int> Convert(string scoreCard)
        {
            return scoreCard
                .Split('|')
                .Where(notRecordCreatedByDoublePipes)
                .Select(mapToIntegers)
                .SelectMany(i => i);
        }

        private bool notRecordCreatedByDoublePipes(string score, int index) => 
            index != 10;

        private IEnumerable<int> mapToIntegers(string score)
        {
            if (score == string.Empty)
                return new int[] { 0 };

            if (score.Length == 2)
            {
                var roll1 = getScore(score[0]);
                var roll2 = getScore(score[1]);
                return new int[] { roll1, getScoreIfSpare(roll1, roll2) };
            }

            return new int[] { getScore(score[0]) };
        }

        private static int getScoreIfSpare(int roll1, int roll2) => 
            roll2 == -1 ? 10 - roll1 : roll2;

        private int getScore(char score)
        {
            if (score == 'X') return 10;
            if (score == '/') return -1;
            if (score == '-') return 0;
            if (int.TryParse(score.ToString(), out int n)) return n; //C# 7 syntax
            return 0;
        }
    }
}
