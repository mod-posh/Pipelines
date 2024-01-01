---
external help file: Pipelines.dll-Help.xml
Module Name: Pipelines
online version:
schema: 2.0.0
---

# New-AdoStage

## SYNOPSIS

This Cmdlet creates an Ado Stage object

## SYNTAX

```powershell
New-AdoStage [-Name] <String> [[-DisplayName] <String>] [[-DependsOn] <String[]>] [[-Condition] <String>]
 [[-Variables] <Hashtable>] [[-Jobs] <Job[]>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

A stage is a logical boundary in the pipeline. It can be used to mark separation
of concerns (for example, Build, QA, and production). Each stage contains one or
more jobs. When you define multiple stages in a pipeline, by default, they run
one after the other.

## EXAMPLES

### Example 1

```powershell
PS C:\> New-AdoStage -Name MyStage -Variables @{'ServiceAccountName'='sa'} -DependsOn @('OtherStage') -Condition "eq(variables['BuildSuccess'], 'TRUE')"

Name        : MyStage
DisplayName :
DependsOn   : {OtherStage}
Condition   : eq(variables['BuildSuccess'], 'TRUE')
Variables   : {[ServiceAccountName, sa]}
Jobs        : {}
```

This creates a Stage object on the Command line.

## PARAMETERS

### -Condition

You can specify the conditions under which each stage runs with expressions.
By default, a stage runs if it doesn't depend on any other stage, or if all of
the stages that it depends on have completed and succeeded. You can customize
this behavior by forcing a stage to run even if a previous stage fails or by
specifying a custom condition.

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

### -DependsOn

When you define multiple stages in a pipeline, by default, they run sequentially
in the order in which you define them in the YAML file. The exception to this is
when you add dependencies. With dependencies, stages run in the order of the
dependsOn requirements.

Pipelines must contain at least one stage with no dependencies.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName

A friendly name to display in the UI

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

### -Jobs

Every pipeline has at least one job. A job is a series of steps that run
sequentially as a unit. In other words, a job is the smallest unit of work that
can be scheduled to run.

```yaml
Type: ModPosh.Pipelines.Ado.Job[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name

The name of the stage, A-Z, a-z, 0-9, and underscore

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

### -Variables

The variables keyword uses two syntax forms: variable list and mapping
(string dictionary).

In mapping syntax, all keys are variable names and their values are variable
values. To use variable templates, you must use list syntax. List syntax
requires you to specify whether you're mentioning a variable (name), a variable
group (group), or a template (template).

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

### ModPosh.Pipelines.Ado.Stage

## NOTES

## RELATED LINKS

[Stages](https://learn.microsoft.com/en-us/azure/devops/pipelines/yaml-schema/stages?view=azure-pipelines)

[Stages, Dependencies, Conditions](https://learn.microsoft.com/en-us/azure/devops/pipelines/process/stages?view=azure-devops&tabs=yaml)
