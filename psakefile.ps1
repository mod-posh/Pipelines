$script:ModuleName = 'Pipelines';                                                               # The name of your PowerShell module
$script:ProjectName = "Pipelines";                                                              # The name of your C# Project
$script:DotnetVersion = "net7.0";                                                               # The version of .Net the project is targeted to
$script:GithubOrg = 'mod-posh'                                                                  # This could be your github username if you're not working in a Github Org
$script:Repository = "https://github.com/$($script:GithubOrg)";                                 # This is the Github Repo
$script:DeployBranch = 'main';                                                                  # The branch that we deploy from, typically master or main
$script:Root = $PSScriptRoot;                                                                   # This will be the root of your Module Project, not the Repository Root
$script:Source = Join-Path $PSScriptRoot $script:ModuleName;                                    # This will be the root of your Module Project, not the Repository Root
$script:Output = Join-Path $PSScriptRoot 'output';                                              # The module will be output into this folder
$script:Docs = Join-Path $PSScriptRoot 'docs';                                                  # The root folder for the PowerShell Module
$script:Destination = Join-Path $Output $script:ModuleName;                                     # The PowerShell module folder that contains the manifest and other files
$script:ModulePath = "$Destination\$script:ModuleName.dll";                                     # The main PowerShell Module file
$script:ManifestPath = "$Destination\$script:ModuleName.psd1";                                  # The main PowerShell Module Manifest
$script:TestFile = ("TestResults_$(Get-Date -Format s).xml").Replace(':', '-');                 # The Pester Test output file
$script:DiscordChannel = "https://discord.com/channels/1044305359021555793/1044305781627035811" # Discord Channel
$script:PoshGallery = "https://www.powershellgallery.com/packages/$($script:ModuleName)"        # The PowerShell Gallery URL
$script:Fwlink = "https://raw.githubusercontent.com/$($script:GithubOrg)/$($script:ModuleName)/main/cabs/"

$BuildHelpers = Get-Module -ListAvailable | Where-Object -Property Name -eq BuildHelpers;
if ($BuildHelpers)
{
 Write-Host -ForegroundColor Blue "Info: BuildHelpers Version $($BuildHelpers.Version) Found";
 Write-Host -ForegroundColor Blue "Info: This automation built with BuildHelpers Version 2.0.16";
 Import-Module BuildHelpers;
}
else
{
 throw "Please Install-Module -Name BuildHelpers";
}
$PowerShellForGitHub = Get-Module -ListAvailable | Where-Object -Property Name -eq PowerShellForGitHub;
if ($PowerShellForGitHub)
{
 Write-Host -ForegroundColor Blue "Info: PowerShellForGitHub Version $($PowerShellForGitHub.Version) Found";
 Write-Host -ForegroundColor Blue "Info: This automation built with PowerShellForGitHub Version 0.16.1";
 Import-Module PowerShellForGitHub;
}
else
{
 throw "Please Install-Module -Name PowerShellForGitHub";
}
$PlatyPS = Get-Module -ListAvailable | Where-Object -Property Name -eq PlatyPS;
if ($PlatyPS)
{
 Write-Host -ForegroundColor Blue "Info: PowerShellForGitHub Version $($PlatyPS.Version) Found";
 Write-Host -ForegroundColor Blue "Info: This automation built with PowerShellForGitHub Version 0.14.2";
 Import-Module PlatyPS;
}
else
{
 throw "Please Install-Module -Name PlatyPS";
}
$Pester = Get-Module -ListAvailable | Where-Object -Property Name -eq Pester;
if ($Pester)
{
 Write-Host -ForegroundColor Blue "Info: PowerShellForGitHub Version $($Pester.Version) Found";
 Write-Host -ForegroundColor Blue "Info: This automation built with PowerShellForGitHub Version 3.4.0";
 Import-Module Pester;
}
else
{
 throw "Please Install-Module -Name Pester";
}

Write-Host -ForegroundColor Green "ModuleName     : $($script:ModuleName)";
Write-Host -ForegroundColor Green "ProjectName    : $($script:ProjectName)";
Write-Host -ForegroundColor Green "DotnetVersion  : $($script:DotnetVersion)";
Write-Host -ForegroundColor Green "GithubOrg      : $($script:GithubOrg)";
Write-Host -ForegroundColor Green "Root           : $($script:Root)";
Write-Host -ForegroundColor Green "Source         : $($script:Source)";
Write-Host -ForegroundColor Green "Output         : $($script:Output)";
Write-Host -ForegroundColor Green "Docs           : $($script:Docs)";
Write-Host -ForegroundColor Green "Destination    : $($script:Destination)";
Write-Host -ForegroundColor Green "ModulePath     : $($script:ModulePath)";
Write-Host -ForegroundColor Green "ManifestPath   : $($script:ManifestPath)";
Write-Host -ForegroundColor Green "TestFile       : $($script:TestFile)";
Write-Host -ForegroundColor Green "Repository     : $($script:Repository)";
Write-Host -ForegroundColor Green "DiscordChannel : $($script:DiscordChannel)";
Write-Host -ForegroundColor Green "PoshGallery    : $($script:PoshGallery)";
Write-Host -ForegroundColor Green "DeployBranch   : $($script:DeployBranch)";
Write-Host -ForegroundColor Green "FwLink         : $($script:Fwlink)";

Task default -depends LocalUse

Task LocalUse -Description "Setup for local use and testing" -depends Clean, BuildProject, CopyModuleFiles

Task Build -depends LocalUse, PesterTest
Task Package -depends CreateExternalHelp, CreateCabFile, UpdateReadme
Task Deploy -depends CheckBranch, ReleaseNotes, PublishModule, NewTaggedRelease, Post2Discord, Post2Bluesky

Task Clean -depends CleanProject {
 $null = Remove-Item $Output -Recurse -ErrorAction Ignore
 $null = New-Item -Type Directory -Path $Destination -ErrorAction Ignore
 $null = Remove-Item "$($script:Root)\TestResults*.xml"
}

Task UpdateReadme -Description "Update the README file" -Action {
 $readMe = Get-Item .\README.md

 $TableHeaders = "| Latest Version | PowerShell Gallery | Issues | License | Discord |"
 $Columns = "|-----------------|----------------|----------------|----------------|----------------|"
 $VersionBadge = "[![Latest Version](https://img.shields.io/github/v/tag/$($script:GithubOrg)/$($script:ModuleName))]($($script:Repository)/$($script:ModuleName)/tags)"
 $GalleryBadge = "[![Powershell Gallery](https://img.shields.io/powershellgallery/dt/$($script:ModuleName))](https://www.powershellgallery.com/packages/$($script:ModuleName))"
 $IssueBadge = "[![GitHub issues](https://img.shields.io/github/issues/$($script:GithubOrg)/$($script:ModuleName))]($($script:Repository)/$($script:ModuleName)/issues)"
 $LicenseBadge = "[![GitHub license](https://img.shields.io/github/license/$($script:GithubOrg)/$($script:ModuleName))]($($script:Repository)/$($script:ModuleName)/blob/master/LICENSE)"
 $DiscordBadge = "[![Discord Server](https://assets-global.website-files.com/6257adef93867e50d84d30e2/636e0b5493894cf60b300587_full_logo_white_RGB.svg)]($($script:DiscordChannel))"

 if (!(Get-Module -Name $script:ModuleName )) { Import-Module -Name $script:Destination }

 Write-Output $TableHeaders | Out-File $readMe.FullName -Force
 Write-Output $Columns | Out-File $readMe.FullName -Append
 Write-Output "| $($VersionBadge) | $($GalleryBadge) | $($IssueBadge) | $($LicenseBadge) | $($DiscordBadge) |" | Out-File $readMe.FullName -Append

 Get-Content "$($script:Docs)\$($script:ModuleName).md" | Select-Object -Skip 8 | ForEach-Object { $_.Replace('(', '(docs/') } | Out-File $readMe.FullName -Append
 Write-Output "" | Out-File $readMe.FullName -Append
}

Task NewTaggedRelease -Description "Create a tagged release" -Action {
 $Github = (Get-Content -Path "$($PSScriptRoot)\github.json") | ConvertFrom-Json
 $Credential = New-Credential -Username ignoreme -Password $Github.Token
 Set-GitHubAuthentication -Credential $Credential
 if (!(Get-Module -Name $script:ModuleName )) { Import-Module -Name "$($script:Output)\$($script:ModuleName)" }
 $Version = (Get-Module -Name $script:ModuleName | Select-Object -Property Version).Version.ToString()
 git add .
 git commit . -m "Updated ExternalHelp for $($Version) Release"
 git push
 git tag -a v$version -m "$($script:ModuleName) Version $($Version)"
 git push origin v$version
 New-GitHubRelease -OwnerName $script:GithubOrg -RepositoryName $script:ModuleName -Tag "v$($Version)" -Name "v$($Version)"
}

Task Post2Discord -Description "Post a message to discord" -Action {
 $version = (Get-Module -Name $($script:ModuleName) | Select-Object -Property Version).Version.ToString()
 $Discord = Get-Content -Path "$($PSScriptRoot)\discord.json" | ConvertFrom-Json
 $Discord.message.content = "Version $($version) of $($script:ModuleName) released. Please visit Github ($($script:Repository)/$($script:ModuleName)) or PowershellGallery ($($script:PoshGallery)) to download."
 Invoke-RestMethod -Uri $Discord.uri -Body ($Discord.message | ConvertTo-Json -Compress) -Method Post -ContentType 'application/json; charset=UTF-8'
}

Task Post2Bluesky -Description "Post a message to bsky.app" -Action {
 $version = (Get-Module -Name $($script:ModuleName) | Select-Object -Property Version).Version.ToString()
 $createdAt = Get-Date -Format "yyyy-MM-ddTHH:mm:ss.ffffffZ"
 # Authenticate
 $AuthBody = Get-Content -Path "$($PSScriptRoot)\bluesky.json"
 $Handle = $AuthBody |ConvertFrom-Json |Select-Object -ExpandProperty Identifier
 $Headers = @{}
 $Headers.Add('Content-Type','application/json')
 $Response = Invoke-RestMethod -Uri "https://bsky.social/xrpc/com.atproto.server.createSession" -Method Post -Body $AuthBody -Headers $Headers
 # Create post
 $Headers.Add('Authorization',"Bearer $($Response.accessJwt)")
 $Record = New-Object -TypeName psobject -Property @{
  '$type'="app.bsky.feed.post"
  'text'="Version $($version) of $($script:ModuleName) released. Please visit Github ($($script:Repository)/$($script:ModuleName)) or PowershellGallery ($($script:PoshGallery)) to download."
  "createdAt"=$createdAt
 }
 $Post = New-Object -TypeName psobject -Property @{
  'repo'=$Handle
  'collection'='app.bsky.feed.post'
  record=$Record
 }

 Invoke-RestMethod -Uri "https://bsky.social/xrpc/com.atproto.repo.createRecord" -Method Post -Body ($Post |ConvertTo-Json -Compress) -Headers $Headers
}

Task CleanProject -Description "Clean the project before building" -Action {
 dotnet clean "$($PSScriptRoot)\$($script:ProjectName)\$($script:ProjectName).csproj"
}

Task BuildProject -Description "Build the project" -Action {
 dotnet build "$($PSScriptRoot)\$($script:ProjectName)\$($script:ProjectName).csproj" -c Release
}

Task CopyModuleFiles -Description "Copy files for the module" -Action {
 Copy-Item "$($PSScriptRoot)\$($script:ProjectName)\bin\Release\$($script:DotnetVersion)\*.dll" $script:Destination -Force
 Copy-Item "$($PSScriptRoot)\$($script:ModuleName).psd1" $script:Destination -Force
}

Task CreateHelp -Description "Create the help documentation" -depends Build -Action {
 if (!(Get-Module -Name $script:ModuleName )) { Import-Module -Name $script:Destination }
 $Version = (Get-Module -Name $script:ModuleName | Select-Object -Property Version).Version.ToString()
 New-MarkdownHelp -Module $script:ModuleName -AlphabeticParamsOrder -OutputFolder $script:Docs -UseFullTypeName -WithModulePage -HelpVersion $Version -FwLink $script:Fwlink
}

Task CreateExternalHelp -Description "Create external help file" -Action {
 New-ExternalHelp -Path $script:Docs -OutputPath $script:Destination -Force
}

Task CreateCabFile -Description "Create cab file for download" -Action {
 New-ExternalHelpCab -CabFilesFolder $script:Destination -LandingPagePath "$($script:Docs)\$($script:ModuleName).md" -OutputFolder "$($PSScriptRoot)\cabs\"
}

Task PesterTest -description "Test module" -action {
 if (!(Get-Module -Name $script:ModuleName )) { Import-Module -Name $script:Destination }
 $pesterConfig = New-PesterConfiguration @{
  Run = @{
      Path = "$($script:Source)\Tests\CmdletTests"
  }
  Output = @{
      Verbosity = 'Detailed'
  }
  TestResult = @{
      Enabled = $true
      OutputPath = "$($PSScriptRoot)\$($script:TestFile)"
      TestResultFormat = 'NUnitXml'
  }
}
 $TestResults = Invoke-Pester -Configuration $pesterConfig
 if ($TestResults.FailedCount -gt 0)
 {
  Write-Error "Failed [$($TestResults.FailedCount)] Pester tests"
 }
}

Task CheckBranch -Description "A test that should fail if we deploy while not on master" -Action {
 $branch = git branch --show-current
 if ($branch -ne $script:DeployBranch)
 {
  [System.Net.WebSockets.WebSocketException]$Exception = "You are not on the deployment branch: $($script:DeployBranch)"
  [string]$ErrorId = "Git.WrongBranch"
  [System.Management.Automation.ErrorCategory]$Category = [System.Management.Automation.ErrorCategory]::InvalidOperation
  $PSCmdlet.ThrowTerminatingError(
   [System.Management.Automation.ErrorRecord]::new(
    $Exception,
    $ErrorId,
    $Category,
    $null
   )
  )
 }
}

Task ReleaseNotes -Description "Create release notes file for module manifest" -Action {
 $Github = (Get-Content -Path "$($PSScriptRoot)\github.json") | ConvertFrom-Json
 $Credential = New-Credential -Username ignoreme -Password $Github.Token
 Set-GitHubAuthentication -Credential $Credential
 $Milestone = (Get-GitHubMilestone -OwnerName $script:GithubOrg -RepositoryName $script:ModuleName -State Closed | Sort-Object -Property ClosedAt)[0]
 if ($Milestone)
 {
  [System.Text.StringBuilder]$stringbuilder = [System.Text.StringBuilder]::new()
  [void]$stringbuilder.AppendLine( "# $($Milestone.title)" )
  [void]$stringbuilder.AppendLine( "$($Milestone.description)" )
  $i = Get-GitHubIssue -OwnerName $script:GithubOrg -RepositoryName $script:ModuleName -RepositoryType All -Filter All -State Closed -MilestoneNumber $Milestone.Number;
  $headings = $i | ForEach-Object { $_.Labels.Name } | Sort-Object -Unique;
  foreach ($heading in $headings)
  {
   [void]$stringbuilder.AppendLine( "" )
   [void]$stringbuilder.AppendLine( "## $($heading.ToUpper())" )
   [void]$stringbuilder.AppendLine( "" )
   $issues = $i | ForEach-Object { if ($_.Labels.Name -eq $Heading) { $_ } }
   foreach ($issue in $issues)
   {
    [void]$stringbuilder.AppendLine( "* $($issue.title) #$($issue.issuenumber)" )
   }
  }
  Out-File -FilePath "$($PSScriptRoot)\RELEASE.md" -InputObject $stringbuilder.ToString() -Encoding ascii -Force
 }
}

Task PublishModule -Description "Publish module to PowerShell Gallery" -Action {
 $config = [xml](Get-Content "$($PSScriptRoot)\nuget.config");
 [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
 $Parameters = @{
  Path        = $script:Destination
  NuGetApiKey = "$($config.configuration.apikeys.add.value)"
 }
 Publish-Module @Parameters;
}