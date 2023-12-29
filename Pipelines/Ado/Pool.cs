using ModPosh.Pipelines.Serializers;
using System.Text;
using System.Text.RegularExpressions;

namespace ModPosh.Pipelines.Ado
{
    public class Pool
    {
        private static readonly Regex NameRegex = new Regex(@"^[A-Za-z0-9_]+$", RegexOptions.Compiled);
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                if (!NameRegex.IsMatch(value))
                {
                    throw new ArgumentException("Name can only contain A-Z, a-z, 0-9, and underscore.");
                }
                _name = value;
            }
        }
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