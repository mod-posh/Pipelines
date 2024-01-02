using ModPosh.Pipelines.Ado;
using ModPosh.Pipelines.Gha;
using System.Collections;
using System.Management.Automation;

namespace ModPosh.Pipelines.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "GhaStep", HelpUri = "https://github.com/mod-posh/Pipelines/blob/v2.0.0.0/docs/New-GhaStep.md#new-ghastep")]
    [OutputType(typeof(Step))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewGhaStep : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public string Id { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "Default")]
        public string Name { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "Default")]
        public string Uses { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "Default")]
        public string Run { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "Default")]
        public Hashtable With { get; set; } = new Hashtable();

        protected override void BeginProcessing()
        {
            Step step = new Step(Id);
            if (string.IsNullOrEmpty(Name) == false)
                step.Name = Name;
            if (string.IsNullOrEmpty(Uses) == false)
                step.Uses = Uses;
            if (string.IsNullOrEmpty(Run) == false)
                step.Run = Run;
            if (With != null)
            {
                step.With = With
                    .Cast<DictionaryEntry>()
                    .Where(entry => entry.Key != null && entry.Value != null)
                    .ToDictionary(entry => (string)entry.Key!, entry => (string)entry.Value!);
            }
            WriteObject(step);
        }
    }
}