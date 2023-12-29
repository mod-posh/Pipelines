using System.Text;

namespace ModPosh.Pipelines.Ado
{
    public class Stage
    {
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty; 
        public string[] DependsOn { get;set; } = Array.Empty<string>();
        public string Condition { get; set; } = string.Empty;
        public Dictionary<string,string> Variables { get; set; } = new Dictionary<string, string>();
        public string Jobs { get; set; } = string.Empty;
        public Stage() { }
        public Stage(string name)
        {
            Name = name;
        }
        public Stage(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }
        public Stage(string name, string displayName, string[] dependsOn)
        {
            Name = name;
            DisplayName = displayName;
            DependsOn = dependsOn;
        }
        public Stage(string name, string displayName, string[] dependsOn, string condition)
        {
            Name = name;
            DisplayName = displayName;
            DependsOn = dependsOn;
            Condition = condition;
        }
        public Stage(string name, string displayName, string[] dependsOn, string condition, Dictionary<string,string> variables)
        {
            Name = name;
            DisplayName = displayName;
            DependsOn = dependsOn;
            Condition = condition;
            Variables = variables;
        }
        public Stage(string name, string displayName, string[] dependsOn, string condition, Dictionary<string,string> variables, string jobs)
        {
            Name = name;
            DisplayName = displayName;
            DependsOn = dependsOn;
            Condition = condition;
            Variables = variables;
            Jobs = jobs;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- stage: {Name}");
            if (string.IsNullOrEmpty(DisplayName) == false)
                sb.AppendLine($"  displayName: {DisplayName}");
            if (DependsOn.Length > 0)
            {
                sb.AppendLine($"  dependsOn:");
                foreach (string Dependency in DependsOn)
                {
                    sb.AppendLine($"  - {Dependency}");
                }
            }
            if (string.IsNullOrEmpty(Condition) == false)
                sb.AppendLine($"  condition: {Condition}");
            if (Variables.Count > 0)
            {
                sb.AppendLine($"  variables:");
                foreach (var variable in Variables)
                {
                    if (variable.Value.StartsWith("$"))
                        sb.AppendLine($"    {variable.Key}: {variable.Value}");
                    else
                        sb.AppendLine($"    {variable.Key}: '{variable.Value}'");
                }
            }
            sb.AppendLine($"  jobs:");
            return sb.ToString();
        }
    }
}