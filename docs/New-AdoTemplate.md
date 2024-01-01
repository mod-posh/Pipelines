---
external help file: Pipelines.dll-Help.xml
Module Name: Pipelines
online version:
schema: 2.0.0
---

# New-AdoTemplate

## SYNOPSIS

This Cmdlet creates an Ado Template object

## SYNTAX

```powershell
New-AdoTemplate [-Name] <String> [[-Parameters] <Hashtable>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION

Templates let you define reusable content, logic, and parameters in YAML pipelines.
To work with templates effectively, you'll need to have a basic understanding of
Azure Pipelines key concepts such as stages, steps, and jobs.

## EXAMPLES

### Example 1

```powershell
PS C:\> New-AdoTemplate -Name 'template.yml' -Parameters @{'Environment'='$(Environment)'}

Name         Parameters
----         ----------
template.yml {[Environment, $(Environment)]}
```

This creates a template object on the Command line.

## PARAMETERS

### -Name

Required as first property. Reference to a template for this deployment.

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

### -Parameters

You can specify parameters and their data types in a template and reference
those parameters in a pipeline. With templateContext, you can also pass
properties to stages, steps, and jobs that are used as parameters in a template.

```yaml
Type: System.Collections.Hashtable
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

### ModPosh.Pipelines.Ado.Template

## NOTES

## RELATED LINKS

[Templates](https://learn.microsoft.com/en-us/azure/devops/pipelines/process/templates?view=azure-devops&pivots=templates-includes)

[Template Parameters](https://learn.microsoft.com/en-us/azure/devops/pipelines/process/template-parameters?view=azure-devops)
