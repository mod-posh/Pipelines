# Changelog

All changes to this module should be reflected in this document.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [[1.5.0.0]](https://github.com/mod-posh/Pipelines/releases/tag/v1.5.0.0) - 2023-12-29

This release added error handling and validation to inputs across the module.

What's changed:

1. Added regex to handle name validation in Stage [Issue #19](https://github.com/mod-posh/Pipelines/issues/19)
2. Added regex to handle name validation in Pool
3. Added logic to handle spaces in Pool name [Issue #26](https://github.com/mod-posh/Pipelines/issues/26)
4. Added regex to handle name validation in Job [Issue #27](https://github.com/mod-posh/Pipelines/issues/27)
5. Added logic to test dependsOn against regex  [Issue #28](https://github.com/mod-posh/Pipelines/issues/28)
6. Added error handling to YamlSerializer [Issue #29](https://github.com/mod-posh/Pipelines/issues/29)

---

## [[1.4.0.0]](https://github.com/mod-posh/Pipelines/releases/tag/v1.4.0.0) - 2023-12-29

This is the first working release published into the PowerShell Gallery. This release adds documentation to the module.

What's changed:

1. Added the initial help documents using PlatyPS [Issue #18](https://github.com/mod-posh/Pipelines/issues/18)
   1. Updated documentation for all Cmdlets [Issue #18](https://github.com/mod-posh/Pipelines/issues/18)
   2. Added About Help documentation [Issue #18](https://github.com/mod-posh/Pipelines/issues/18)
   3. Updated About Help [Issue #18](https://github.com/mod-posh/Pipelines/issues/18)
   4. Updated Online Uri to a versioned url [Issue #18](https://github.com/mod-posh/Pipelines/issues/18)

---

## [[1.3.0.0]](https://github.com/mod-posh/Pipelines/releases/tag/v1.3.0.0) - 2023-12-29

This release adds the YamlSerializer, and updates the classes to leverage the new serializer

What's changed:

1. Set Stage to be an optional parameter in the Cmdlet [Issue #12](https://github.com/mod-posh/Pipelines/issues/12)
2. Create the Serialization Interface [Issue #13](https://github.com/mod-posh/Pipelines/issues/13)
3. Create the YamlSerialization class [Issue #14](https://github.com/mod-posh/Pipelines/issues/14)
4. Move the code from the ToString override to the serializer [Issue #16](https://github.com/mod-posh/Pipelines/issues/16)
5. Implement the YamlSerializer in the Classes [Issue #15](https://github.com/mod-posh/Pipelines/issues/15)

---

## [[1.2.0.0]](https://github.com/mod-posh/Pipelines/releases/tag/v1.2.0.0) - 2023-12-29

This release adds the PowerShell Cmdlets

What's changed:

1. Adding NewPipeline Cmdlet for [Issue #5](https://github.com/mod-posh/Pipelines/issues/5)
   1. Added Pipeline class, Closes [Issue #5](https://github.com/mod-posh/Pipelines/issues/5)
2. Adding NewStage Cmdlet for [Issue #6](https://github.com/mod-posh/Pipelines/issues/6)
3. Adding NewJob Cmdlet for [Issue #7](https://github.com/mod-posh/Pipelines/issues/7)
4. Adding NewTemplate Cmdlet for [Issue #8](https://github.com/mod-posh/Pipelines/issues/8)
5. Adding NewPool Cmdlet for [Issue #9](https://github.com/mod-posh/Pipelines/issues/9)

---

## [[1.0.0.0]](https://github.com/mod-posh/Pipelines/releases/tag/v1.0.0.0) - 2023-12-29

Initial release of code, base models no functionality.

What's changed:

1. Adding Stage class for [Issue #1](https://github.com/mod-posh/Pipelines/issues/1)
2. Added Job class [Issue #2](https://github.com/mod-posh/Pipelines/issues2)
   1. Updated Job with Template Class [Issue #2](https://github.com/mod-posh/Pipelines/issues/2)
   2. Updated Job with Pool, Closes [Issue #2](https://github.com/mod-posh/Pipelines/issues/2)
3. Added Template Class [Issue #3](https://github.com/mod-posh/Pipelines/issues/3)
4. Added Pool class, Closes [Issue #4](https://github.com/mod-posh/Pipelines/issues/4)
5. Adding the module manifest

---
