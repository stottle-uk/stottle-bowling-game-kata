using System.Collections.Generic;

namespace Bowling.Data.Convert
{
    public interface IConverter<TIn, TOut>
    {
        TOut Convert(TIn scoreCard);
    }
}