# pipelines

## about_pipelines

# SHORT DESCRIPTION

How to use the cmdlets to create a pipeline

# LONG DESCRIPTION

The purpose of this module to make creation of customized pipelines as easy as
possible. You should be able to create a pipeline as part of any process you
desire. We will walk through a very quick tutorial on how to do this.

Once you have installed and imported the module into your environment, you will
want to create your first pipeline. This process is very straightforward.

```powershell
$Pipeline = New-Pipeline -Name 'MyPipelines'
```

You now have a pipeline object, but there are no stages currently setup, so we
need to create a stage.

```powershell
$Stage = New-Stage -Name MyStage -Variables @{'ServiceAccountName'='sa'} `
-DependsOn @('OtherStage') -Condition "eq(variables['BuildSuccess'], 'TRUE')"
```

We now have a stage object called MyStage that contains a variable, some
dependencies and a condition. The stage has no jobs, so let's create the rest
of the objects we need.

```powershell
$Pool = New-Pool -Name 'MyPool'

$Template = New-Template -Name 'template.yml' `
-Parameters @{'Environment'='$(Environment)'}

$Job = New-Job -Name MyJob -Pool $Pool -Variables `
@{'Environment'="Development"} -Steps $Template
```

We now have a job object that contains a template and pool object. This can now
be added to the stage, and then the pipeline.

```powershell
$Stage.Jobs.Add($Job)

$Pipeline.Stages.Add($Stage)
```
There are now two ways you can output this pipeline, either use the ToString()
or the Write-Host cmdlet.

```powershell
$Pipeline.ToString()
name: MyPipelines
stages:
- stage: MyStage
  dependsOn:
  - OtherStage
  condition: eq(variables['BuildSuccess'], 'TRUE')
  variables:
    ServiceAccountName: 'sa'
  jobs:
  - job: MyJob
    pool:
      name: MyPool

    variables:
      Environment: "Development"
    steps:
    - template: template.yml
      parameters:
        Environment: $(Environment)
```

# NOTE

This is a very basic walk-through but should allow you to get started working
with pipelines in PowerShell very quickly. This module only creates the pipeline
it does not perform any validation or checking, this may come in future versions
but at this time that is not possible.

# SEE ALSO

Here are some links that may be useful

[Azure Devops Pipelines](https://learn.microsoft.com/en-us/azure/devops/pipelines/?view=azure-devops)

[Azure Devops YAML Schema](https://learn.microsoft.com/en-us/azure/devops/pipelines/yaml-schema/?view=azure-pipelines&viewFallbackFrom=azure-devops)

# KEYWORDS

- {{ create pipeline }}
