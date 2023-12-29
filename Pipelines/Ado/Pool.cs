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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"name: {Name}");
            if (Demands.Count() > 0)
            {
                if (Demands.Count() == 1)
                {
                    sb.Append($"demands: {Demands[0]}");
                }
                else
                {
                    sb.AppendLine($"demands:");
                    foreach (string Demand in Demands)
                    {
                        sb.AppendLine($"- {Demand}");
                    }
                }
            }
            return sb.ToString();
        }
    }
}