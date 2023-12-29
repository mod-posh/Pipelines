namespace ModPosh.Pipelines.Serializers
{
    public interface ISerializer
    {
        string Serialize<T>(T obj);
    }
}
