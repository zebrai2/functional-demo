using System;
using System.Collections.Generic;
using System.Text;

namespace Handler.Functional
{
    public class Option<T>
    {
        public static implicit operator Option<T>(T some)
            => new Some<T>(some);

        public static implicit operator Option<T>(None none)
            => new None<T>();


    }

    public class Some<T> : Option<T>
    {
        private T _content;
        public Some(T some)
        {
            _content = some;
        }

        public static implicit operator T(Some<T> some)
            => some._content;
    }

    public class None<T> : Option<T>
    {

    }

    public class None { }
}
