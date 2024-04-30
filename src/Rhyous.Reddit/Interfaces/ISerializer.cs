namespace Rhyous.Reddit
{
    public interface ISerializer
    {
        public T Deserialize<T>(string json) where T : class, new();
        public string Serialize(object o);
    }
}
