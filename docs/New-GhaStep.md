---
external help file: Pipelines.dll-Help.xml
Module Name: Pipelines
online version: https://github.com/mod-posh/Pipelines/blob/v2.0.0.0/docs/New-GhaStep.md#new-ghastep
schema: 2.0.0
---

# New-GhaStep

## SYNOPSIS

A job contains a sequence of tasks called steps. Steps can run commands, run
setup tasks, or run an action in your repository, a public repository, or an
action published in a Docker registry. Not all steps run actions, but all
actions run as a step. Each step runs in its own process in the runner
environment and has access to the workspace and filesystem. Because steps run in
their own process, changes to environment variables are not preserved between
steps. GitHub provides built-in steps to set up and complete a job.

## SYNTAX

```powershell
New-GhaStep [-Id] <String> [[-Name] <String>] [[-Uses] <String>] [[-Run] <String>] [[-With] <Hashtable>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

A job contains a sequence of tasks called steps. Steps can run commands, run
setup tasks, or run an action in your repository, a public repository, or an
action published in a Docker registry. Not all steps run actions, but all
actions run as a step. Each step runs in its own process in the runner
environment and has access to the workspace and filesystem. Because steps run in
their own process, changes to environment variables are not preserved between
steps. GitHub provides built-in steps to set up and complete a job.

## EXAMPLES

### Example 1

```powershell
PS C:\> New-GhaStep -Id 'myStep' -Name 'my_step'

Id   : myStep
If   :
Name : my_step
Uses :
Run  :
With : {}
```

This creates a Step object on the Command line.

## PARAMETERS

### -Id

A unique identifier for the step. You can use the id to reference the step in
contexts. For more information, see "Contexts."

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

### -Name

A name for your step to display on GitHub.

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

### -Run

Runs command-line programs using the operating system's shell. If you do not
provide a name, the step name will default to the text specified in the run
command.

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

### -Uses

Selects an action to run as part of a step in your job. An action is a reusable
unit of code. You can use an action defined in the same repository as the
workflow, a public repository, or in a published Docker container image.

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

### -With

A map of the input parameters defined by the action. Each input parameter is a
key/value pair. Input parameters are set as environment variables. The variable
is prefixed with INPUT_ and converted to upper case.

```yaml
Type: System.Collections.Hashtable
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

### ModPosh.Pipelines.Gha.Step

## NOTES

## RELATED LINKS

[Steps](https://docs.github.com/en/actions/using-workflows/workflow-syntax-for-github-actions#jobsjob_idsteps)

[Uses](https://docs.github.com/en/actions/using-workflows/workflow-syntax-for-github-actions#jobsjob_idstepsuses)

[Runs](https://docs.github.com/en/actions/using-workflows/workflow-syntax-for-github-actions#jobsjob_idstepsrun)

[With](https://docs.github.com/en/actions/using-workflows/workflow-syntax-for-github-actions#jobsjob_idstepswith)
