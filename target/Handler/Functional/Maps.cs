using System;
using System.Collections.Generic;
using System.Text;

namespace Handler.Functional
{
    public static class Maps
    {
        public static Either<TLeft, TNewRight> Map<TLeft, TRight, TNewRight>(this Either<TLeft, TRight> either, Func<TRight, TNewRight> map)
        {
            if (either is Right<TLeft, TRight> right)
            {
                return map(right);
            }
            return (TLeft)(Left<TLeft, TRight>)either;
        }
    }
}
