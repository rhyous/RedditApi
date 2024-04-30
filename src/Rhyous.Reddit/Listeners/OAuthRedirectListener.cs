using Rhyous.Reddit.Interfaces;
using System.Diagnostics;
using System.Text;

namespace Rhyous.Reddit
{
    internal class OAuthRedirectListener : IOAuthRedirectListener
    {
        private readonly IRandomStringGenerator _RandomStringGenerator;
        private readonly IRedditSettings _RedditSettings;
        private readonly IObjectFactory<IHttpListener> _HttpListenerFactory;
        private readonly ILogger _Logger;

        public OAuthRedirectListener(IRandomStringGenerator randomStringGenerator,
                                     IRedditSettings redditSettings,
                                     IObjectFactory<IHttpListener> httpListenerFactory,
                                     ILogger logger)
        {
            _RandomStringGenerator = randomStringGenerator;
            _RedditSettings = redditSettings;
            _HttpListenerFactory = httpListenerFactory;
            _Logger = logger;
        }
        public async Task<string> ListenAsync(string state)
        {
            LaunchWebPageForUser(state);
            using (IHttpListener listener = _HttpListenerFactory.Create())
            {
                listener.Prefixes.Add(_RedditSettings.RedirectUrl.TrimEnd('/') + '/'); // Always end with /
                listener.Start();

                // Asynchronously wait for the incoming connection
                var context = await listener.GetContextAsync();

                // Extract the code from the incoming request
                var response = context.Response;
                string code = context.Request.QueryString["code"];
                string incomingState = context.Request.QueryString["state"];

                if (state != incomingState)
                {
                    _Logger.Write(LogLevel.Debug, "Invalid state. Possible Cross-Site Request Forgery.");
                }
                else
                {
                    _Logger.Write(LogLevel.Debug, "Auth code: ", code);
                }

                // Send a response back to the browser
                string responseString = "<html><head></head><body>Please return to the app.</body></html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                var responseOutput = response.OutputStream;
                await responseOutput.WriteAsync(buffer, 0, buffer.Length);
                responseOutput.Close();

                listener.Stop();
                return code;
            }
        }

        private void LaunchWebPageForUser(string state)
        {
            string authorizationUrl = $"https://www.reddit.com/api/v1/authorize?client_id={_RedditSettings.AppId}&response_type=code&state={state}&redirect_uri={_RedditSettings.RedirectUrl}&duration=permanent&scope=read";
            Process.Start(new ProcessStartInfo(authorizationUrl) { UseShellExecute = true });
        }
    }
}
