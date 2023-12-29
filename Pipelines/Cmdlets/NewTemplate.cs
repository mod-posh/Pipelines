using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Management.Automation;
using ModPosh.Pipelines.Ado;

namespace ModPosh.Pipelines.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Template", HelpUri = "https://github.com/mod-posh/Pipelines/blob/v1.4.0.0/docs/New-Template.md#new-template")]
    [OutputType(typeof(Template))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewTemplate : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Default")]
        public string Name { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "Default")]
        public Hashtable Parameters { get; set; } = new Hashtable();

        protected override void BeginProcessing()
        {
            Template template = new Template(Name);
            if (Parameters != null)
            {
                template.Parameters = Parameters
                    .Cast<DictionaryEntry>()
                    .Where(entry => entry.Key != null && entry.Value != null)
                    .ToDictionary(entry => (string)entry.Key!, entry => (string)entry.Value!);
            }
            WriteObject(template);
        }
    }
}