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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"name: {Name}");
            sb.AppendLine("stages:");
            foreach (Stage stage in Stages)
            {
                sb.AppendLine(stage.ToString());
            }
            return sb.ToString();
        }
    }
}