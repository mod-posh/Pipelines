---
external help file: Pipelines.dll-Help.xml
Module Name: Pipelines
online version: https://github.com/mod-posh/Pipelines/blob/v2.0.0.0/docs/New-AdoPipeline.md#new-adopipeline
schema: 2.0.0
---

# New-AdoAdoPipeline

## SYNOPSIS

This Cmdlet creates an Ado Pipeline object

## SYNTAX

```powershell
New-AdoAdoPipeline [-Name] <String> [[-Stages] <Stage[]>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

A pipeline defines the continuous integration and deployment process for your
app. It's made up of one or more stages. It can be thought of as a workflow that
defines how your test, build, and deployment steps are run.

## EXAMPLES

### Example 1

```powershell
PS C:\> New-AdoAdoPipeline -Name 'Sample'

Name   Stages
----   ------
Sample {}
```

This creates a Pipeline object on the Command line.

## PARAMETERS

### -Name

Pipeline run number.

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

### -Stages

Stages are groups of jobs that can run without human intervention.

```yaml
Type: ModPosh.Pipelines.Ado.Stage[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### ModPosh.Pipelines.Ado.Pipeline

## NOTES

## RELATED LINKS

[Pipelines](https://learn.microsoft.com/en-us/azure/devops/pipelines/yaml-schema/pipeline?view=azure-pipelines)

[Stages](https://learn.microsoft.com/en-us/azure/devops/pipelines/yaml-schema/stages?view=azure-pipelines)
