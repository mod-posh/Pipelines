using ModPosh.Pipelines.Gha;
using System.Collections;
using System.Management.Automation;

namespace ModPosh.Pipelines.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "GhaWorkflow", HelpUri = "https://github.com/mod-posh/Pipelines/blob/v2.0.0.0/docs/New-GhaWorkflow.md#new-ghaworkflow")]
    [OutputType(typeof(Workflow))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewGhaWorkflow : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public string Name { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "Default")]
        public string RunName { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "Default")]
        public Gha.Job[] Jobs { get; set; } = Array.Empty<Gha.Job>();

        protected override void BeginProcessing()
        {
            Workflow workflow = new Workflow(Name);
            if (RunName != null)
                workflow.RunName = RunName;
            if (Jobs.Length > 0)
                workflow.Jobs = Jobs.ToList();
            WriteObject(workflow);
        }
    }
}