namespace Bowling.Data.Converter
{
    public interface IScoreConverter<TIn, TOut>
    {
        TOut Convert(TIn scoreCard);
    }
}