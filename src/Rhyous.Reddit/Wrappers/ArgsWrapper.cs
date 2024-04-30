using Rhyous.SimpleArgs;
using System.Diagnostics.CodeAnalysis;

namespace Rhyous.Reddit
{
    [ExcludeFromCodeCoverage] // No reason to unit test wrappers
    internal class ArgsWrapper : IArgs
    {
        public Argument Get(string name) => Args.Get(name);
        public string Value(string name) => Args.Value(name);
    }
}
