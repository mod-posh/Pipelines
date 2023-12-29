using ModPosh.Pipelines.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModPosh.Pipelines.Ado
{
    public class Pipeline
    {
        public string Name { get; set; } = string.Empty;
        public List<Stage> Stages { get; set; } = new List<Stage>();
        public Pipeline () { }
        public Pipeline (string name)
        {
            Name = name;
        }
        public Pipeline (string name, List<Stage> stages)
        {
            Name = name;
            Stages = stages;
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