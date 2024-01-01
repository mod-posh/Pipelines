---
external help file: Pipelines.dll-Help.xml
Module Name: Pipelines
online version:
schema: 2.0.0
---

# New-AdoJob

## SYNOPSIS

This Cmdlet creates an Ado Job object

## SYNTAX

```powershell
New-AdoJob [-Name] <String> [[-Pool] <Pool>] [[-Variables] <Hashtable>] [[-Steps] <Template[]>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

You can organize your pipeline into jobs. Every pipeline has at least one job.
A job is a series of steps that run sequentially as a unit. In other words, a
job is the smallest unit of work that can be scheduled to run.

Azure Pipelines does not support job priority for YAML pipelines. To control
when jobs run, you can specify conditions and dependencies.

## EXAMPLES

### Example 1

```powershell
PS C:\> New-AdoJob -Name MyJob -Pool $Pool -Variables @{'Environment'="$[ stageDependencies.DetermineEnvironment.GetVariables.outputs['SetVariables.Environment'] ]"}

Name      : MyJob
Pool      : name: $(poolName)
            demands: Agent.Name -equals $(AgentName)
Variables : {[Environment, $[ stageDependencies.DetermineEnvironment.GetVariables.outputs['SetVariables.Environment'] ]]}
Steps     : {}
```

This creates a Job object on the Command line.

## PARAMETERS

### -Name

Required as first property. ID of the job.

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

### -Pool

Pool where this job will run.

```yaml
Type: ModPosh.Pipelines.Ado.Pool
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Steps

A list of steps to run.

```yaml
Type: ModPosh.Pipelines.Ado.Template[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Variables

Job-specific variables.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### ModPosh.Pipelines.Ado.Job

## NOTES

## RELATED LINKS

[Jobs in pipeline](https://learn.microsoft.com/en-us/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml)

[Jobs](https://learn.microsoft.com/en-us/azure/devops/pipelines/yaml-schema/jobs?view=azure-pipelines)

[Job](https://learn.microsoft.com/en-us/azure/devops/pipelines/yaml-schema/jobs-job?view=azure-pipelines)

[Steps](https://learn.microsoft.com/en-us/azure/devops/pipelines/yaml-schema/steps?view=azure-pipelines)

[Variables](https://learn.microsoft.com/en-us/azure/devops/pipelines/yaml-schema/variables?view=azure-pipelines)
