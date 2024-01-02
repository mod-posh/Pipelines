using ModPosh.Pipelines.Ado;
using System.Text;

namespace ModPosh.Pipelines.Serializers
{
    public class YamlSerializer : ISerializer
    {
        public string Serialize<T>(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "Cannot serialize a null object.");
            try
            {
                if (obj is Stage stage)
                {
                    return SerializeTemplate(stage);
                }
                if (obj is Ado.Job adojob)
                {
                    return SerializeTemplate(adojob);
                }
                if (obj is Template template)
                {
                    return SerializeTemplate(template);
                }
                if (obj is Pool pool)
                {
                    return SerializeTemplate(pool);
                }
                if (obj is Ado.Pipeline pipeline)
                {
                    return SerializeTemplate(pipeline);
                }
                if (obj is Gha.Workflow workflow)
                {
                    return SerializeTemplate(workflow);
                }
                if (obj is Gha.Job ghajob)
                {
                    return SerializeTemplate(ghajob);
                }
                if (obj is Gha.Step step)
                {
                    return SerializeTemplate(step);
                }
            }
            catch (Exception ex)
            {
                throw new SerializationException($"Failed to serialize object of type {typeof(T).Name}", ex);
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
            return sb.ToString().Trim();
        }
        private string SerializeTemplate(Ado.Job job)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- job: {job.Name}");
            sb.AppendLine($"  pool: ");

            string[] lines = job.Pool.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].PadLeft(lines[i].Length + 4);
            }
            sb.AppendLine($"{new StringBuilder(string.Join(Environment.NewLine, lines))}");

            if (job.Variables.Count > 0)
            {
                sb.AppendLine($"  variables:");
                foreach (var variable in job.Variables)
                {
                    if (variable.Value.StartsWith("$"))
                        sb.AppendLine($"    {variable.Key}: {variable.Value}");
                    else
                        sb.AppendLine($"    {variable.Key}: \"{variable.Value}\"");
                }
            }
            if (job.Steps.Count > 0)
            {
                sb.AppendLine($"  steps:");
                foreach (Template template in job.Steps)
                {
                    lines = template.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        lines[i] = lines[i].PadLeft(lines[i].Length + 2);
                    }
                    sb.AppendLine($"{new StringBuilder(string.Join(Environment.NewLine, lines))}");
                }
            }
            return sb.ToString().Trim();
        }
        private string SerializeTemplate(Template template)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- template: {template.Name}");
            if (template.Parameters.Count > 0)
            {
                sb.AppendLine($"  parameters:");
                foreach (var parameter in template.Parameters)
                {
                    if (parameter.Value.StartsWith("$"))
                        sb.AppendLine($"    {parameter.Key}: {parameter.Value}");
                    else
                        sb.AppendLine($"    {parameter.Key}: \"{parameter.Value}\"");
                }
            }
            return sb.ToString().Trim();
        }
        private string SerializeTemplate(Pool pool)
        {
            StringBuilder sb = new StringBuilder();
            if (pool.Name.Contains(' '))
                sb.AppendLine($"name: \"{pool.Name}\"");
            else
                sb.AppendLine($"name: {pool.Name}");
            if (pool.Demands.Count() > 0)
            {
                if (pool.Demands.Count() == 1)
                {
                    sb.Append($"demands: {pool.Demands[0]}");
                }
                else
                {
                    sb.AppendLine($"demands:");
                    foreach (string Demand in pool.Demands)
                    {
                        sb.AppendLine($"- {Demand}");
                    }
                }
            }
            return sb.ToString().Trim();
        }
        private string SerializeTemplate(Ado.Pipeline pipeline)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"name: {pipeline.Name}");
            sb.AppendLine("stages:");
            foreach (Stage stage in pipeline.Stages)
            {
                sb.AppendLine(stage.ToString());
            }
            return sb.ToString().Trim();
        }
        private string SerializeTemplate(Gha.Workflow workflow)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"name: {workflow.Name}");
            if (string.IsNullOrEmpty(workflow.RunName) == false)
                sb.AppendLine($"run-name: {workflow.RunName}");
            sb.AppendLine("on:");
            sb.AppendLine("jobs:");
            foreach (Gha.Job job in workflow.Jobs)
            {
                sb.AppendLine(job.ToString());
            }
            return sb.ToString().Trim();
        }
        private string SerializeTemplate(Gha.Job job)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{job.Id}:");
            sb.AppendLine($"  name: {job.Name}");
            if (string.IsNullOrEmpty(job.If) == false)
                sb.AppendLine($"  if: {job.If}");
            if (string.IsNullOrEmpty(job.RunsOn) == false)
                sb.AppendLine($"  runs-on: {job.RunsOn}");
            if (job.Steps.Count > 0)
            {
                sb.AppendLine($"  steps:");
                foreach (Gha.Step step in job.Steps)
                {
                    string[] lines = step.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        lines[i] = lines[i].PadLeft(lines[i].Length + 2);
                    }
                    sb.AppendLine($"{new StringBuilder(string.Join(Environment.NewLine, lines))}");
                }
            }
            return sb.ToString().Trim();
        }
        private string SerializeTemplate(Gha.Step step)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{step.Id}:");
            if (string.IsNullOrEmpty(step.If) == false)
                sb.AppendLine($"  if: {step.If}");
            if (string.IsNullOrEmpty(step.Name) == false)
                sb.AppendLine($"  name: {step.Name}");
            if (string.IsNullOrEmpty(step.Uses) == false)
                sb.AppendLine($"  uses: {step.Uses}");
            if (string.IsNullOrEmpty(step.Run) == false)
                sb.AppendLine($"  run: {step.Run}");
            if (step.With.Count > 0)
            {
                sb.AppendLine($"  with:");
                foreach (var with in step.With)
                {
                    if (with.Value.StartsWith("$"))
                        sb.AppendLine($"    {with.Key}: {with.Value}");
                    else
                        sb.AppendLine($"    {with.Key}: \"{with.Value}\"");
                }
            }
            return sb.ToString().Trim();
        }
    }
    public class SerializationException : Exception
    {
        public SerializationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}