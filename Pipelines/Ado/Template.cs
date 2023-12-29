using System.Text;

namespace ModPosh.Pipelines.Ado
{
    public class Template
    {
        public string Name { get; set; } = string.Empty;
        public Dictionary<string,string> Parameters { get; set; } = new Dictionary<string, string>();
        public Template() { }
        public Template(string name)
        {
            Name = name;
        }
        public Template(string name, Dictionary<string,string> parameters)
        {
            Name = name;
            Parameters = parameters;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- template: {Name}");
            if (Parameters.Count > 0)
            {
                sb.AppendLine($"  parameters:");
                foreach (var parameter in Parameters)
                {
                    if (parameter.Value.StartsWith("$"))
                        sb.AppendLine($"    {parameter.Key}: {parameter.Value}");
                    else
                        sb.AppendLine($"    {parameter.Key}: \"{parameter.Value}\"");
                }
            }
            return sb.ToString();
        }
    }
}