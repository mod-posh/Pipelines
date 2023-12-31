﻿using ModPosh.Pipelines.Ado;
using System.Collections;
using System.Management.Automation;

namespace ModPosh.Pipelines.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AdoTemplate", HelpUri = "https://github.com/mod-posh/Pipelines/blob/v2.0.0.0/docs/New-AdoTemplate.md#new-adotemplate")]
    [OutputType(typeof(Template))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewAdoTemplate : PSCmdlet
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