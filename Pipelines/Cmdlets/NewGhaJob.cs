using ModPosh.Pipelines.Gha;
using System.Collections;
using System.Management.Automation;

namespace ModPosh.Pipelines.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "GhaJob", HelpUri = "https://github.com/mod-posh/Pipelines/blob/v2.0.0.0/docs/New-GhaJob.md#new-ghajob")]
    [OutputType(typeof(Gha.Job))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewGhaJob : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public string Id { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "Default")]
        public string Name { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "Default")]
        public string If { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "Default")]
        public string RunsOn { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "Default")]
        public Step[] Steps { get; set; } = Array.Empty<Step>();

        protected override void BeginProcessing()
        {
            Gha.Job job = new Gha.Job(Id);
            if (string.IsNullOrEmpty(Name) == false)
                job.Name = Name;
            if (string.IsNullOrEmpty(If) == false)
                job.If = If;
            if (string.IsNullOrEmpty(RunsOn) == false)
                job.RunsOn = RunsOn;
            if (Steps.Length > 0)
                job.Steps = Steps.ToList();
            WriteObject(job);
        }
    }
}