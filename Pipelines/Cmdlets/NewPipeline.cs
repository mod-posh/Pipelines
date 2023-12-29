using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Management.Automation;
using ModPosh.Pipelines.Ado;

namespace ModPosh.Pipelines.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Pipeline", HelpUri = "https://github.com/mod-posh/Pipelines/blob/v1.4.0.0/docs/New-Pipeline.md#new-pipeline")]
    [OutputType(typeof(Pipeline))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewPipeline : PSCmdlet
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