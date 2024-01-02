BeforeAll {
    # Define the path to the module and the help info file
    $modulePath = (Get-Item .\Pipelines.psd1).FullName
    $helpInfoPath = (Get-Item .\cabs\Pipelines_cff00216-d0d0-4565-af27-31d9c0400884_HelpInfo.xml).FullName
    $projectVersionFilePath = (Get-Item .\Pipelines\Pipelines.csproj).FullName

    # Read the project version
    [xml]$project = Get-Content $projectVersionFilePath -Raw
    $projectVersion = $project.Project.PropertyGroup.Version;

    # Import the module manifest
    $moduleManifest = Import-PowerShellDataFile -Path $modulePath

    [xml]$helpInfo = Get-Content -Path $helpInfoPath
    $helpVersion = $helpInfo.HelpInfo.SupportedUICultures.UICulture.UICultureVersion
}

Describe 'Module Version Checks' {
    It 'Module manifest version should match project version' {
        $moduleManifest['ModuleVersion'] | Should -BeExactly $projectVersion
    }

    It 'HelpInfo.xml version should match project version' {
        $helpVersion | Should -BeExactly $projectVersion
    }
}