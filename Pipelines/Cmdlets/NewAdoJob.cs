using ModPosh.Pipelines.Ado;
using System.Collections;
using System.Management.Automation;

namespace ModPosh.Pipelines.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AdoJob", HelpUri = "https://github.com/mod-posh/Pipelines/blob/v2.0.0.0/docs/New-AdoJob.md#new-adojob")]
    [OutputType(typeof(Ado.Job))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewAdoJob : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public string Name { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "Default")]
        public Pool Pool { get; set; } = new Pool();
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "Default")]
        public Hashtable Variables { get; set; } = new Hashtable();
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "Default")]
        public Template[] Steps { get; set; } = Array.Empty<Template>();

        protected override void BeginProcessing()
        {
            Ado.Job job = new Ado.Job(Name);
            if (Pool != null)
                job.Pool = Pool;
            if (Variables != null)
            {
                job.Variables = Variables
                    .Cast<DictionaryEntry>()
                    .Where(entry => entry.Key != null && entry.Value != null)
                    .ToDictionary(entry => (string)entry.Key!, entry => (string)entry.Value!);
            }
            if (Steps.Length > 0)
                job.Steps = Steps.ToList();
            WriteObject(job);
        }
    }
}