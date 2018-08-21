using System;
using System.Collections.Generic;
using System.Text;

namespace Handler.Functional
{
    public static class Switches
    {
        public static Either<TLeft, TRight> Switch<TLeft, TRight>(this Either<TLeft, TRight> either, Func<TRight, Option<TLeft>> swtch)
            => either is Right<TLeft, TRight> right
                    && swtch(right) is Some<TLeft> left
                ? (TLeft)left
                : either;

    }
}
