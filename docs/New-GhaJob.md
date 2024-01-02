---
external help file: Pipelines.dll-Help.xml
Module Name: Pipelines
online version: https://github.com/mod-posh/Pipelines/blob/v2.0.0.0/docs/New-GhaJob.md#new-ghajob
schema: 2.0.0
---

# New-GhaJob

## SYNOPSIS

A workflow run is made up of one or more jobs, which run in parallel by default.
To run jobs sequentially, you can define dependencies on other jobs using the
jobs.<job_id>.needs keyword.

## SYNTAX

```powershell
New-GhaJob [-Id] <String> [[-Name] <String>] [[-If] <String>] [[-RunsOn] <String>] [[-Steps] <Step[]>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

A workflow run is made up of one or more jobs, which run in parallel by default.
To run jobs sequentially, you can define dependencies on other jobs using the
jobs.<job_id>.needs keyword.

## EXAMPLES

### Example 1

```powershell
PS C:\> New-GhaJob -Id 'myJob' -Name 'my_job'

Id     : myJob
Name   : my_job
If     :
RunsOn :
Steps  : {}
```

This creates a Job object on the Command line.

## PARAMETERS

### -Id

Use jobs.<job_id> to give your job a unique identifier. The key job_id is a
string and its value is a map of the job's configuration data. You must replace
<job_id> with a string that is unique to the jobs object. The <job_id> must
start with a letter or _ and contain only alphanumeric characters, -, or _.

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

### -If

You can use the jobs.<job_id>.if conditional to prevent a job from running
unless a condition is met. You can use any supported context and expression
to create a conditional. For more information on which contexts are supported
in this key, see "Contexts.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name

Use jobs.<job_id>.name to set a name for the job, which is displayed in the
GitHub UI.

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

### -RunsOn

se jobs.<job_id>.runs-on to define the type of machine to run the job on.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Steps

A job contains a sequence of tasks called steps. Steps can run commands, run
setup tasks, or run an action in your repository, a public repository, or an
action published in a Docker registry. Not all steps run actions, but all
actions run as a step. Each step runs in its own process in the runner
environment and has access to the workspace and filesystem. Because steps run in
their own process, changes to environment variables are not preserved between
steps. GitHub provides built-in steps to set up and complete a job.

```yaml
Type: ModPosh.Pipelines.Gha.Step[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### ModPosh.Pipelines.Gha.Job

## NOTES

## RELATED LINKS

[Job](https://docs.github.com/en/actions/using-workflows/workflow-syntax-for-github-actions#jobs)

[If](https://docs.github.com/en/actions/using-workflows/workflow-syntax-for-github-actions#jobsjob_idif)

[Runs-On](https://docs.github.com/en/actions/using-workflows/workflow-syntax-for-github-actions#jobsjob_idruns-on)

[Steps](https://docs.github.com/en/actions/using-workflows/workflow-syntax-for-github-actions#jobsjob_idsteps)
