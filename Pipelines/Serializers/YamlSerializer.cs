using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ModPosh.Pipelines.Ado;

namespace ModPosh.Pipelines.Serializers
{
    public class YamlSerializer : ISerializer
    {
        public string Serialize<T>(T obj)
        {
            if (obj is Stage stage)
            {
                return SerializeTemplate(stage);
            }
            if (obj is Job job)
            {
                return SerializeTemplate(job);
            }
            if (obj is Template template)
            {
                return SerializeTemplate(template);
            }
            if (obj is Pool pool)
            {
                return SerializeTemplate(pool);
            }
            if (obj is Pipeline pipeline)
            {
                return SerializeTemplate(pipeline);
            }

            throw new ArgumentException("Object type is not supported", nameof(obj));
        }

        private string SerializeTemplate(Stage stage)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- stage: {stage.Name}");
            if (string.IsNullOrEmpty(stage.DisplayName) == false)
                sb.AppendLine($"  displayName: {stage.DisplayName}");
            if (stage.DependsOn.Length > 0)
            {
                sb.AppendLine($"  dependsOn:");
                foreach (string Dependency in stage.DependsOn)
                {
                    sb.AppendLine($"  - {Dependency}");
                }
            }
            if (string.IsNullOrEmpty(stage.Condition) == false)
                sb.AppendLine($"  condition: {stage.Condition}");
            if (stage.Variables.Count > 0)
            {
                sb.AppendLine($"  variables:");
                foreach (var variable in stage.Variables)
                {
                    if (variable.Value.StartsWith("$"))
                        sb.AppendLine($"    {variable.Key}: {variable.Value}");
                    else
                        sb.AppendLine($"    {variable.Key}: '{variable.Value}'");
                }
            }
            sb.AppendLine($"  jobs:");
            foreach (Job job in stage.Jobs)
            {
                string[] lines = job.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].PadLeft(lines[i].Length + 2);
                }
                sb.AppendLine($"{new StringBuilder(string.Join(Environment.NewLine, lines))}");
            }
            return sb.ToString();
        }
        private string SerializeTemplate(Job job)
        {
            // Serialization logic here
        }
        private string SerializeTemplate(Template template)
        {
            // Serialization logic here
        }
        private string SerializeTemplate(Pool pool)
        {
            // Serialization logic here
        }
        private string SerializeTemplate(Pipeline pipeline)
        {
            // Serialization logic here
        }
    }
}
