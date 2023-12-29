# CSharp Modules

Enclosed are the files I use to build and deploy PowerShell CSharp modules. The basic file structure is included so you have an idea of what it should look like. There are several Modules that are required and the Tasks will check for them at the start. This project assumes that you have placed your code in a subfolder named after your project (there is a checkbox for this during the project creation in Visual Studio).

If your project is not in a subfolder but directly in the root of the project you will need to uncomment the Source variable that doesn't include the ProjectName.

## Dependencies

You will need to have the following modules installed :

 1. BuildHelpers        : This is used to help build the Module Manifest as well as the Module file
 2. PowerShellForGitHub : This is used for the ReleaseNotes task
 3. PlatyPS             : This is used to set up and build the help documents
 4. Pester              : This is the testing framework

Please see the [psakefile](psakefile.ps1) for the versions currently used.

## Supporting Files

There are several files used to help authenticate to various services and depending on your needs you may not need them or you may need something different. You can use them as is, but you will need to populate the various tokens and keys yourself. Also if there is not something you need you can use them as a template.

### ado.json

This file is used to authenticate into the Azure DevOps Rest API, you will need a token for this so please consult the [Documentation](https://learn.microsoft.com/en-us/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate?view=azure-devops&tabs=Windows). I include three items :

1. Orgname    : The name of the Azure DevOps organization
2. Token      : The PAT Token
3. Expiration : The expiration date

I include the Expiration so I can get a visual indication of how long before I need to renew the token, there is logic within the psakefile to display that out when you run it.

### discord.json

This file is used to post a message to Discord, I have a server that I set up and I post updates to channels for each of the modules that I use. If you wish to use the Post2Discord you will need to have a Discord account, set up a personal server and get the webhook url, please consult the [Documentation](https://support.discord.com/hc/en-us/articles/228383668-Intro-to-Webhooks).

### github.json

This file is used to authenticate into the Github API, you will need to set up a token for this so please consult the [Documentation](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token). This is used for the ReleaseNotes task.

### nuget.config

This file was originally setup to publish to nuget.org and the PowerShell Gallery, I've left it as is, as I use the same file for publishing some of my code to nuget.org. You will need to create an API Key for this, please consult the [Documentation](https://learn.microsoft.com/en-us/powershell/scripting/gallery/concepts/publishing-guidelines?view=powershell-7.3).

## PsakeFile

This is the main file from which all automation is kicked off. I will go through the basic usage of this file, but for details on setting up for your use, please refer to the file itself. The Psakefile contains a collection of Tasks for more details on how to setup and use Psake please consult the [Documentation](https://psake.readthedocs.io/en/latest/). I will cover the basic tasks that I use so you have an understanding of how they work.

### Localuse

This task is run regularly, this is used to compile the module after local changes so I can test functionality. It basically runs a Build but does not do any of the testing that would normally go along with it.

### Build

This task runs LocalUse but also runs the PesterTests, so make sure you have some of those, otherwise remove the reference to the PesterTest Task. For more information on setting up Tests please refer to the [Documentation](https://pester.dev/docs/quick-start).

### Package

This task builds the help files, packages them up for deployment as well as updates the README.

### Deploy

This task will check to make sure we have checked out the Deployment Branch, the deployment should fail if we are not in the deployment branch. It will then create the Realease Notes, these are compiled from the Github Milestones, if you are not using them remove the reference to this task. It will then Publish the module to the PowerShellGallery, create and push a Tagged release as well are create the Github Release, and finally post a message to Discord, if you are not using Discord remove the reference to this task.
