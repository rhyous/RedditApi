namespace Rhyous.Reddit
{
    internal class ThreadFactory : IThreadFactory
    {
        public IThread Create(Action method)
        {
            return new ThreadWrapper(method);
        }
    }
}
