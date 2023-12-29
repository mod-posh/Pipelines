using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Management.Automation;
using ModPosh.Pipelines.Ado;

namespace ModPosh.Pipelines.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Pool", HelpUri = "https://github.com/mod-posh/Pipelines/blob/v1.5.0.0/docs/New-Pool.md#new-pool")]
    [OutputType(typeof(Pool))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewPool : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public string Name { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "Default")]
        public string[] Demands { get; set; } = Array.Empty<string>();

        protected override void BeginProcessing()
        {
            Pool pool = new Pool(Name);
            if (Demands.Length > 0)
                pool.Demands = Demands;
            WriteObject(pool);
        }
    }
}