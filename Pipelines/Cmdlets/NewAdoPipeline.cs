using ModPosh.Pipelines.Ado;
using System.Management.Automation;

namespace ModPosh.Pipelines.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AdoPipeline", HelpUri = "https://github.com/mod-posh/Pipelines/blob/v2.0.0.0/docs/New-AdoPipeline.md#new-adopipeline")]
    [OutputType(typeof(Pipeline))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewAdoPipeline : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public string Name { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "Default")]
        public Stage[] Stages { get; set; } = Array.Empty<Stage>();
        protected override void BeginProcessing()
        {
            Pipeline pipeline = new Pipeline(Name);
            if (Stages.Length > 0)
                pipeline.Stages = Stages.ToList();
            WriteObject(pipeline);
        }
    }
}