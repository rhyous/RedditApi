namespace Rhyous.Reddit.Interfaces
{
    internal interface IOAuthRedirectListener
    {
        Task<string> ListenAsync(string state);
    }
}