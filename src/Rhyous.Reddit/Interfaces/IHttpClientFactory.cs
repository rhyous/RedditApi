namespace Rhyous.Reddit
{
    public interface IHttpClientFactory
    {
        IHttpClient GetHttpClient(string url = null);
    }
}