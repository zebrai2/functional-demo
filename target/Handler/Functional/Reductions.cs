using System;
using System.Collections.Generic;
using System.Text;

namespace Handler.Functional
{
    public static class Reductions
    {
        public static Either<TLeft, TRight> Reduce<TLeft, TRight>(this Either<TLeft, TRight> either, Func<TRight> reduce, Func<TLeft, bool> filter)
            => either is Left<TLeft, TRight> left
                    && filter(left)
                ? (Right<TLeft, TRight>)reduce()
                : either;
    }
}
