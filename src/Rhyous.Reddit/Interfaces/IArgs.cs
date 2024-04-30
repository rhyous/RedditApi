using Rhyous.SimpleArgs;

namespace Rhyous.Reddit
{
    internal interface IArgs
    {
        Argument Get(string name);
        string Value(string name);
    }
}