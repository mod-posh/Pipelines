using ModPosh.Pipelines.Serializers;

namespace ModPosh.Pipelines.Ado
{
    public class Template
    {
        public string Name { get; set; } = string.Empty;
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        public Template() { }
        public Template(string name)
        {
            Name = name;
        }
        public Template(string name, Dictionary<string, string> parameters)
        {
            Name = name;
            Parameters = parameters;
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