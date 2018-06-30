using System;

namespace Kelson.Common.Builders
{
    public abstract class ComposableBuilder<T> : IComposableBuilder<T>
    {
        public IComposableBuilder<T> Parent { get; }
        public Func<T, T> Transform { get; }        

        protected ComposableBuilder(Func<T> source = null)
        {
            Parent = null;
            if (source != null)
                Transform = (_ => source());
            else
                Transform = (_ => Activator.CreateInstance<T>());
        }

        protected ComposableBuilder(IComposableBuilder<T> parent, Func<T, T> transform)
        {
            Parent = parent;
            Transform = transform;
        }

        public virtual T Build()
        {            
            if (Parent != null)
                return Transform(Parent.Build());
            else
                return Transform(default);
        }
    }
}
