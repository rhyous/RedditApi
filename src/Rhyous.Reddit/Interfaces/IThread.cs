namespace Rhyous.Reddit
{
    public interface IThread
    {
        void Start();
        void Stop();
        public bool IsStarted { get; }
    }
}
