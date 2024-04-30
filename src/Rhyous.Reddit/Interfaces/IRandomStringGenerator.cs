namespace Rhyous.Reddit
{
    internal interface IRandomStringGenerator
    {
        string Generate(int length = 12);
    }
}