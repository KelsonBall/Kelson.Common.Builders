using System;
using System.Collections.Generic;
using System.Text;

namespace Kelson.Common.Builders
{
    public interface IComposableBuilder<T>
    {
        IComposableBuilder<T> Parent { get; }
        Func<T, T> Transform { get; }
        T Build();
    }
}
