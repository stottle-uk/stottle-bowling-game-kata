using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Data.Extensions
{
    public static class MyExtensions
    {
        public static TOut Then<TIn, TOut>(this TIn item, Func<TIn, TOut> fn) => fn(item);
    }
}
