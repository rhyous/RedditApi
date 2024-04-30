namespace Rhyous.Reddit
{
    internal interface IObjectFactory<T>
    {
        T Create();
    }
}