---
external help file: Pipelines.dll-Help.xml
Module Name: Pipelines
online version: https://github.com/mod-posh/Pipelines/blob/v2.0.0.0/docs/New-GhaWorkflow.md#new-ghaworkflow
schema: 2.0.0
---

# New-GhaWorkflow

## SYNOPSIS

A workflow is a configurable automated process made up of one or more jobs. You must create a YAML file to define your
workflow configuration.

## SYNTAX

```powershell
New-GhaWorkflow [-Name] <String> [[-RunName] <String>] [[-Jobs] <Job[]>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION

A workflow is a configurable automated process made up of one or more jobs. You must create a YAML file to define your
workflow configuration.

## EXAMPLES

### Example 1

```powershell
PS C:\> New-GhaWorkflow -Name 'MyWorkflow' -RunName 'my_workflow'

Name       RunName     Jobs
----       -------     ----
MyWorkflow my_workflow {}
```

This creates a Workflow object on the Command line.

## PARAMETERS

### -Jobs

A workflow run is made up of one or more jobs, which run in parallel by default.
To run jobs sequentially, you can define dependencies on other jobs using the
jobs.<job_id>.needs keyword.

Each job runs in a runner environment specified by runs-on.

```yaml
Type: ModPosh.Pipelines.Gha.Job[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name

The name of the workflow. GitHub displays the names of your workflows under your
repository's "Actions" tab. If you omit name, GitHub displays the workflow file
path relative to the root of the repository.

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

### -RunName

The name for workflow runs generated from the workflow. GitHub displays the
workflow run name in the list of workflow runs on your repository's "Actions"
tab. If run-name is omitted or is only whitespace, then the run name is set to
event-specific information for the workflow run. For example, for a workflow
triggered by a push or pull_request event, it is set as the commit message.

```yaml
Type: System.String
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

### ModPosh.Pipelines.Gha.Workflow

## NOTES

## RELATED LINKS

[Workflows](https://docs.github.com/en/actions/using-workflows/workflow-syntax-for-github-actions#about-yaml-syntax-for-workflows)

[Jobs](https://docs.github.com/en/actions/using-workflows/workflow-syntax-for-github-actions#jobs)
