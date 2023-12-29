using System.Text;

namespace ModPosh.Pipelines.Ado
{
    public class Job
    {
        public string Name { get; set; } = string.Empty;
        public string Pool { get; set; } = string.Empty;
        public Dictionary<string,string> Variables { get; set; } = new Dictionary<string, string>();
        public string[] Steps { get; set; } = Array.Empty<string>();
        public Job() { }
        public Job(string name)
        {
            Name = name;
        }
        public Job(string name, string pool)
        {
            Name = name;
            Pool = pool;
        }
        public Job(string name, string pool, Dictionary<string,string> variables)
        {
            Name = name;
            Pool = pool;
            Variables = variables;
        }
        public Job(string name, string pool, Dictionary<string,string> variables, string[] steps)
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
            return sb.ToString();
        }
    }
}