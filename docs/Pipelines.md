---
Module Name: Pipelines
Module Guid: cff00216-d0d0-4565-af27-31d9c0400884
Download Help Link: https://raw.githubusercontent.com/mod-posh/Pipelines/main/cabs/
Help Version: 1.4.0.0
Locale: en-US
---

# Pipelines Module

## Description

A PowerShell module for working with ADO/Github pipelines

## Pipelines Cmdlets

### [New-Job](New-Job.md)

This Cmdlet creates an Ado Job object

You can organize your pipeline into jobs. Every pipeline has at least one job.
A job is a series of steps that run sequentially as a unit. In other words, a
job is the smallest unit of work that can be scheduled to run.

Azure Pipelines does not support job priority for YAML pipelines. To control
when jobs run, you can specify conditions and dependencies.

### [New-Pipeline](New-Pipeline.md)

This Cmdlet creates an Ado Pipeline object

A pipeline defines the continuous integration and deployment process for your
app. It's made up of one or more stages. It can be thought of as a workflow that
defines how your test, build, and deployment steps are run.

### [New-Pool](New-Pool.md)

This Cmdlet creates an Ado Pool object

The pool keyword specifies which pool to use for a job of the pipeline. A pool
specification also holds information about the job's strategy for running.

### [New-Stage](New-Stage.md)

This Cmdlet creates an Ado Stage object

A stage is a logical boundary in the pipeline. It can be used to mark separation
of concerns (for example, Build, QA, and production). Each stage contains one or
more jobs. When you define multiple stages in a pipeline, by default, they run
one after the other.

### [New-Template](New-Template.md)

This Cmdlet creates an Ado Template object

Templates let you define reusable content, logic, and parameters in YAML pipelines.
To work with templates effectively, you'll need to have a basic understanding of
Azure Pipelines key concepts such as stages, steps, and jobs.