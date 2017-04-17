namespace Bowling.Data.Score
{
    public interface IScoreBuilder<TIn, TOut>
    {
        TOut GetScore(TIn rolls);
    }
}