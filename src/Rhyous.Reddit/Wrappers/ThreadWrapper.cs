namespace Rhyous.Reddit
{
    public class ThreadWrapper : IThread
    {
        private readonly Action _ThreadMethod;
        Thread _Thread;

        public ThreadWrapper(Action threadMethod)
        {
            _ThreadMethod = threadMethod;
        }
        public bool IsStarted { get; internal set; }

        public void Start()
        {
            if (!IsStarted)
            {
                IsStarted = true;
                if (_Thread == null)
                    _Thread = new Thread(ThreadMethod);
                _Thread.Start();
            }
        }

        public void Stop()
        {
            IsStarted = false;
            _Thread = null;
        }

        private void ThreadMethod()
        {
            while (IsStarted)
            {
                _ThreadMethod.Invoke();
                Thread.Sleep(1500); // Todo: Get this from response
            }
        }
    }
}
