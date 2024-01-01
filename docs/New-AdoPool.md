---
external help file: Pipelines.dll-Help.xml
Module Name: Pipelines
online version:
schema: 2.0.0
---

# New-AdoPool

## SYNOPSIS

This Cmdlet creates an Ado Pool object

## SYNTAX

```powershell
New-AdoPool [-Name] <String> [[-Demands] <String[]>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

The pool keyword specifies which pool to use for a job of the pipeline. A pool
specification also holds information about the job's strategy for running.

## EXAMPLES

### Example 1

```powershell
PS C:\> New-AdoPool -Name '$(poolName)' -Demands 'Agent.Name -equals $(AgentName)'

Name        Demands
----        -------
$(poolName) {Agent.Name -equals $(AgentName)}
```

This creates a Pool object on the Command line.

## PARAMETERS

### -Demands

Demands and capabilities are designed for use with self-hosted agents so that
jobs can be matched with an agent that meets the requirements of the job.
When using Microsoft-hosted agents, you select an image for the agent that
matches the requirements of the job, so although it is possible to add
capabilities to a Microsoft-hosted agent, you don't need to use capabilities
with Microsoft-hosted agents.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name

Name of a pool

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### ModPosh.Pipelines.Ado.Pool

## NOTES

## RELATED LINKS

[Pool](https://learn.microsoft.com/en-us/azure/devops/pipelines/yaml-schema/pool?view=azure-pipelines)

[Pool Demands](https://learn.microsoft.com/en-us/azure/devops/pipelines/yaml-schema/pool-demands?view=azure-pipelines)
