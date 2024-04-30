using Rhyous.StringLibrary;
using System.Diagnostics.CodeAnalysis;

namespace Rhyous.Reddit
{
    [ExcludeFromCodeCoverage]
    internal class RandomStringGenerator : IRandomStringGenerator
    {
        public string Generate(int length = 12)
        {
            return CryptoRandomString.GetCryptoRandomBase64String(length);
        }
    }
}
