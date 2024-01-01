# Changelog

All changes to this module should be reflected in this document.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [[2.0.0.0]](https://github.com/mod-posh/Pipelines/releases/tag/v2.0.0.0) - 2023-12-30

Breaking Change: Renamed cmdlets to support similar object names between ADO and Github

1. Resolve name class between classes and cmdlets [Issue [#48](https://github.com/mod-posh/Pipelines/issues/48)]
   1. Renamed existing cmdlets to add a prefix Ado (will be Gha for Github)
   2. Renamed existing help documentation and urls to support this change
   3. Incremented major version to 2.0.0.0 as this is a breaking change

Adding limited support for Github Actions in this release

What's New:

1. Add Github Action Classes
   1. Add Workflow Class [Issue [#32](https://github.com/mod-posh/Pipelines/issues/32)]
   2. Add Job Class [Issue [#33](https://github.com/mod-posh/Pipelines/issues/33)]
   3. Add Step Class [Issue [#34](https://github.com/mod-posh/Pipelines/issues/34)]
2. Add Classes to YamlSerializer
   1. Add Workflow to Serializer [Issue [#35](https://github.com/mod-posh/Pipelines/issues/35)]
   2. Add Job to Serializer [Issue [#36](https://github.com/mod-posh/Pipelines/issues/36)]
   3. Add Step to Serializer [Issue [#37](https://github.com/mod-posh/Pipelines/issues/37)]
3. Add Github Action Cmdlets
   1. Add Workflow Cmdlet [Issue [#38](https://github.com/mod-posh/Pipelines/issues/38)]
   2. Add Job Cmdlet [Issue [#39](https://github.com/mod-posh/Pipelines/issues/39)]
   3. Add Step Cmdlet [Issue [#40](https://github.com/mod-posh/Pipelines/issues/40)]
4. Add Cmdlet Documentation
   1. Add Workflow Cmdlet Help [Issue [#41](https://github.com/mod-posh/Pipelines/issues/41)]
   2. Add Job Cmdlet Help [Issue [#42](https://github.com/mod-posh/Pipelines/issues/42)]
   3. Add Step Cmdlet Help [Issue [#43](https://github.com/mod-posh/Pipelines/issues/43)]
5. Add Pester Tests
   1. Add Workflow PesterTests [Issue [#44](https://github.com/mod-posh/Pipelines/issues/44)]
   2. Add Job PesterTests [Issue [#45](https://github.com/mod-posh/Pipelines/issues/45)]
   3. Add Step PesterTests [Issue [#46](https://github.com/mod-posh/Pipelines/issues/46)]

What's Changed:

1. Added New version to Changelog
2. Incremented Version Numbers
3. Renamed all existing cmdlets

---

## [[1.6.0.0]](https://github.com/mod-posh/Pipelines/releases/tag/v1.6.0.0) - 2023-12-30

This release added Pester Testing to the module

What's New:

1. Added Pester to NewPipeline [Issue #22](https://github.com/mod-posh/Pipelines/issues/22)
2. Added Pester to NewStage [Issue #24](https://github.com/mod-posh/Pipelines/issues/24)
3. Added Pester to NewJob [Issue #21](https://github.com/mod-posh/Pipelines/issues/21)
4. Added Pester to NewPool [Issue #23](https://github.com/mod-posh/Pipelines/issues/23)
5. Added Pester to NewTemplate [Issue #25](https://github.com/mod-posh/Pipelines/issues/25)
6. Updated Psakescript with the latest Pester version

---

## [[1.5.0.0]](https://github.com/mod-posh/Pipelines/releases/tag/v1.5.0.0) - 2023-12-29

This release added error handling and validation to inputs across the module.

What's New:

1. Added regex to handle name validation in Stage [Issue #19](https://github.com/mod-posh/Pipelines/issues/19)
2. Added regex to handle name validation in Pool
3. Added logic to handle spaces in Pool name [Issue #26](https://github.com/mod-posh/Pipelines/issues/26)
4. Added regex to handle name validation in Job [Issue #27](https://github.com/mod-posh/Pipelines/issues/27)
5. Added logic to test dependsOn against regex  [Issue #28](https://github.com/mod-posh/Pipelines/issues/28)
6. Added error handling to YamlSerializer [Issue #29](https://github.com/mod-posh/Pipelines/issues/29)

---

## [[1.4.0.0]](https://github.com/mod-posh/Pipelines/releases/tag/v1.4.0.0) - 2023-12-29

This is the first working release published into the PowerShell Gallery. This release adds documentation to the module.

What's New:

1. Added the initial help documents using PlatyPS [Issue #18](https://github.com/mod-posh/Pipelines/issues/18)
   1. Updated documentation for all Cmdlets [Issue #18](https://github.com/mod-posh/Pipelines/issues/18)
   2. Added About Help documentation [Issue #18](https://github.com/mod-posh/Pipelines/issues/18)
   3. Updated About Help [Issue #18](https://github.com/mod-posh/Pipelines/issues/18)
   4. Updated Online Uri to a versioned url [Issue #18](https://github.com/mod-posh/Pipelines/issues/18)

---

## [[1.3.0.0]](https://github.com/mod-posh/Pipelines/releases/tag/v1.3.0.0) - 2023-12-29

This release adds the YamlSerializer, and updates the classes to leverage the new serializer

What's New:

1. Set Stage to be an optional parameter in the Cmdlet [Issue #12](https://github.com/mod-posh/Pipelines/issues/12)
2. Create the Serialization Interface [Issue #13](https://github.com/mod-posh/Pipelines/issues/13)
3. Create the YamlSerialization class [Issue #14](https://github.com/mod-posh/Pipelines/issues/14)
4. Move the code from the ToString override to the serializer [Issue #16](https://github.com/mod-posh/Pipelines/issues/16)
5. Implement the YamlSerializer in the Classes [Issue #15](https://github.com/mod-posh/Pipelines/issues/15)

---

## [[1.2.0.0]](https://github.com/mod-posh/Pipelines/releases/tag/v1.2.0.0) - 2023-12-29

This release adds the PowerShell Cmdlets

What's New:

1. Adding NewPipeline Cmdlet for [Issue #5](https://github.com/mod-posh/Pipelines/issues/5)
   1. Added Pipeline class, Closes [Issue #5](https://github.com/mod-posh/Pipelines/issues/5)
2. Adding NewStage Cmdlet for [Issue #6](https://github.com/mod-posh/Pipelines/issues/6)
3. Adding NewJob Cmdlet for [Issue #7](https://github.com/mod-posh/Pipelines/issues/7)
4. Adding NewTemplate Cmdlet for [Issue #8](https://github.com/mod-posh/Pipelines/issues/8)
5. Adding NewPool Cmdlet for [Issue #9](https://github.com/mod-posh/Pipelines/issues/9)

---

## [[1.0.0.0]](https://github.com/mod-posh/Pipelines/releases/tag/v1.0.0.0) - 2023-12-29

Initial release of code, base models no functionality.

What's New:

1. Adding Stage class for [Issue #1](https://github.com/mod-posh/Pipelines/issues/1)
2. Added Job class [Issue #2](https://github.com/mod-posh/Pipelines/issues2)
   1. Updated Job with Template Class [Issue #2](https://github.com/mod-posh/Pipelines/issues/2)
   2. Updated Job with Pool, Closes [Issue #2](https://github.com/mod-posh/Pipelines/issues/2)
3. Added Template Class [Issue #3](https://github.com/mod-posh/Pipelines/issues/3)
4. Added Pool class, Closes [Issue #4](https://github.com/mod-posh/Pipelines/issues/4)
5. Adding the module manifest

---
