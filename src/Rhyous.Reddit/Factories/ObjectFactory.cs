using Autofac;

namespace Rhyous.Reddit
{
    internal class ObjectFactory<T> : IObjectFactory<T>
    {
        private readonly ILifetimeScope _Scope;

        public ObjectFactory(ILifetimeScope scope)
        {
            _Scope = scope;
        }

        public T Create() => _Scope.Resolve<T>();
    }
}
