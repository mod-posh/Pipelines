using ModPosh.Pipelines.Ado;
using System.Collections;
using System.Management.Automation;

namespace ModPosh.Pipelines.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Stage", HelpUri = "https://github.com/mod-posh/Pipelines/blob/v1.5.0.0/docs/New-Stage.md#new-stage")]
    [OutputType(typeof(Stage))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewStage : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public string Name { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "Default")]
        public string DisplayName { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "Default")]
        public string[] DependsOn { get; set; } = Array.Empty<string>();
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "Default")]
        public string Condition { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "Default")]
        public Hashtable Variables { get; set; } = new Hashtable();
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "Default")]
        public Ado.Job[] Jobs { get; set; } = Array.Empty<Ado.Job>();

        protected override void BeginProcessing()
        {
            Stage stage = new Stage(Name);
            if (string.IsNullOrEmpty(DisplayName) == false)
                stage.DisplayName = DisplayName;
            if (DependsOn.Length > 0)
                stage.DependsOn = DependsOn;
            if (string.IsNullOrEmpty(Condition) == false)
                stage.Condition = Condition;
            if (Variables != null)
            {
                stage.Variables = Variables
                    .Cast<DictionaryEntry>()
                    .Where(entry => entry.Key != null && entry.Value != null)
                    .ToDictionary(entry => (string)entry.Key!, entry => (string)entry.Value!);
            }
            if (Jobs.Length > 0)
                stage.Jobs = Jobs.ToList();
            WriteObject(stage);
        }
    }
}