using ModPosh.Pipelines.Serializers;
using System.Text;

namespace ModPosh.Pipelines.Ado
{
    public class Pool
    {
        public string Name { get; set; } = string.Empty;
        public string[] Demands { get; set; } = Array.Empty<string>();
        public Pool() { }
        public Pool(string name)
        {
            Name = name;
        }
        public Pool(string name, string[] demands)
        {
            Name = name;
            Demands = demands;
        }
        public override string ToString()
        {
            ISerializer serializer = new YamlSerializer();
            try
            {
                return serializer.Serialize(this);
            }
            catch (Exception ex)
            {
                return $"Error during serialization: {ex.Message}";
            }
        }
    }
}