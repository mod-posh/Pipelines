using ModPosh.Pipelines.Ado;
using System.Management.Automation;

namespace ModPosh.Pipelines.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AdoPool", HelpUri = "https://github.com/mod-posh/Pipelines/blob/v2.0.0.0/docs/New-AdoPool.md#new-adopool")]
    [OutputType(typeof(Pool))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewAdoPool : PSCmdlet
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