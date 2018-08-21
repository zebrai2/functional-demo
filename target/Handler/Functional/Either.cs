using System;
using System.Collections.Generic;
using System.Text;

namespace Handler.Functional
{
    public class Either<TLeft, TRight>
    {
        public static implicit operator Either<TLeft, TRight>(TLeft left)
            => new Left<TLeft, TRight>(left);

        public static implicit operator Either<TLeft, TRight>(TRight right)
            => new Right<TLeft, TRight>(right);
    }

    public class Left<TLeft, TRight> :
        Either<TLeft, TRight>
    {
        private TLeft _content;
        public Left(TLeft left)
        {
            _content = left;
        }

        public static implicit operator TLeft(Left<TLeft, TRight> left)
            => left._content;

    }

    public class Right<TLeft, TRight> :
        Either<TLeft, TRight>
    {
        private TRight _content;
        public Right(TRight right)
        {
            _content = right;
        }

        public static implicit operator TRight(Right<TLeft, TRight> right)
            => right._content;
    }

}
