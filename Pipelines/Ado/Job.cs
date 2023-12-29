using ModPosh.Pipelines.Serializers;
using System.Text;

namespace ModPosh.Pipelines.Ado
{
    public class Job
    {
        public string Name { get; set; } = string.Empty;
        public Pool Pool { get; set; } = new Pool();
        public Dictionary<string,string> Variables { get; set; } = new Dictionary<string, string>();
        public List<Template> Steps { get; set; } = new List<Template>();
        public Job() { }
        public Job(string name)
        {
            Name = name;
        }
        public Job(string name, Pool pool)
        {
            Name = name;
            Pool = pool;
        }
        public Job(string name, Pool pool, Dictionary<string,string> variables)
        {
            Name = name;
            Pool = pool;
            Variables = variables;
        }
        public Job(string name, Pool pool, Dictionary<string,string> variables, List<Template> steps)
        {
            Name = name;
            Pool = pool;
            Variables = variables;
            Steps = steps;
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