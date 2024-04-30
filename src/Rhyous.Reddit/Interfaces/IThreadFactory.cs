
namespace Rhyous.Reddit
{
    internal interface IThreadFactory
    {
        IThread Create(Action method);
    }
}