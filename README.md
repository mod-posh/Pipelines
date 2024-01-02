| Latest Version | PowerShell Gallery | Issues | License | Discord |
|-----------------|----------------|----------------|----------------|----------------|
| [![Latest Version](https://img.shields.io/github/v/tag/mod-posh/Pipelines)](https://github.com/mod-posh/Pipelines/tags) | [![Powershell Gallery](https://img.shields.io/powershellgallery/dt/Pipelines)](https://www.powershellgallery.com/packages/Pipelines) | [![GitHub issues](https://img.shields.io/github/issues/mod-posh/Pipelines)](https://github.com/mod-posh/Pipelines/issues) | [![GitHub license](https://img.shields.io/github/license/mod-posh/Pipelines)](https://github.com/mod-posh/Pipelines/blob/master/LICENSE) | [![Discord Server](https://assets-global.website-files.com/6257adef93867e50d84d30e2/636e0b5493894cf60b300587_full_logo_white_RGB.svg)](https://discord.com/channels/1044305359021555793/1044305781627035811) |
# Pipelines Module

## Description

A PowerShell module for working with ADO/Github pipelines

## Pipelines Cmdlets

### [New-AdoJob](docs/New-AdoJob.md)

This Cmdlet creates an Ado Job object

You can organize your pipeline into jobs. Every pipeline has at least one job.
A job is a series of steps that run sequentially as a unit. In other words, a
job is the smallest unit of work that can be scheduled to run.

Azure Pipelines does not support job priority for YAML pipelines. To control
when jobs run, you can specify conditions and dependencies.

### [New-AdoPipeline](docs/New-AdoPipeline.md)

This Cmdlet creates an Ado Pipeline object

A pipeline defines the continuous integration and deployment process for your
app. It's made up of one or more stages. It can be thought of as a workflow that
defines how your test, build, and deployment steps are run.

### [New-AdoPool](docs/New-AdoPool.md)

This Cmdlet creates an Ado Pool object

The pool keyword specifies which pool to use for a job of the pipeline. A pool
specification also holds information about the job's strategy for running.

### [New-AdoStage](docs/New-AdoStage.md)

This Cmdlet creates an Ado Stage object

A stage is a logical boundary in the pipeline. It can be used to mark separation
of concerns (docs/for example, Build, QA, and production). Each stage contains one or
more jobs. When you define multiple stages in a pipeline, by default, they run
one after the other.

### [New-AdoTemplate](docs/New-AdoTemplate.md)

This Cmdlet creates an Ado Template object

Templates let you define reusable content, logic, and parameters in YAML pipelines.
To work with templates effectively, you'll need to have a basic understanding of
Azure Pipelines key concepts such as stages, steps, and jobs.

### [New-GhaJob](docs/New-GhaJob.md)

A workflow run is made up of one or more jobs, which run in parallel by default.
To run jobs sequentially, you can define dependencies on other jobs using the
jobs.<job_id>.needs keyword.

Each job runs in a runner environment specified by runs-on.

### [New-GhaStep](docs/New-GhaStep.md)

A job contains a sequence of tasks called steps. Steps can run commands, run
setup tasks, or run an action in your repository, a public repository, or an
action published in a Docker registry. Not all steps run actions, but all
actions run as a step. Each step runs in its own process in the runner
environment and has access to the workspace and filesystem. Because steps run in
their own process, changes to environment variables are not preserved between
steps. GitHub provides built-in steps to set up and complete a job.

### [New-GhaWorkflow](docs/New-GhaWorkflow.md)

A workflow is a configurable automated process made up of one or more jobs. You
must create a YAML file to define your workflow configuration.

