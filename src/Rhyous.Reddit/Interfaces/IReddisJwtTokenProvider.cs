
using Rhyous.Reddit.Models;

namespace Rhyous.Reddit
{
    internal interface IReddisJwtTokenProvider
    {
        Task<TokenResponse> GetAccessToken(string code);
    }
}