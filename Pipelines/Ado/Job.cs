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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- job: {Name}");
            sb.AppendLine($"  pool: ");

            string[] lines = Pool.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].PadLeft(lines[i].Length + 4);
            }
            sb.AppendLine($"{new StringBuilder(string.Join(Environment.NewLine, lines))}");

            if (Variables.Count > 0)
            {
                sb.AppendLine($"  variables:");
                foreach (var variable in Variables)
                {
                    if (variable.Value.StartsWith("$"))
                        sb.AppendLine($"    {variable.Key}: {variable.Value}");
                    else
                        sb.AppendLine($"    {variable.Key}: \"{variable.Value}\"");
                }
            }
            if (Steps.Count > 0)
            {
                sb.AppendLine($"  steps:");
                foreach (Template template in Steps)
                {
                    lines = template.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        lines[i] = lines[i].PadLeft(lines[i].Length + 2);
                    }
                    sb.AppendLine($"{new StringBuilder(string.Join(Environment.NewLine, lines))}");
                }
            }
            return sb.ToString();
        }
    }
}