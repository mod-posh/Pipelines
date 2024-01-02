BeforeAll {
    # Import the module or mock the cmdlet if needed
    # Import-Module 'Path\To\Your\Module.psm1'
}

Describe 'New-GhaJob Cmdlet Tests' {

    Context 'Parameter Tests' {
        It 'Should require an Id parameter' {
            { New-GhaJob -Id $null} | Should -Throw -ExpectedMessage "Cannot bind argument to parameter 'Id' because it is null."
        }

        It 'Should accept an Id parameter' {
            { New-GhaJob -Id 'job1' } | Should -Not -Throw
        }
    }

    Context 'Functionality Tests' {
        It 'Should return an object of type Gha.Job' {
            $result = New-GhaJob -Id 'job1'
            $result | Should -BeOfType ModPosh.Pipelines.Gha.Job
        }

        It 'Can have a Name parameter' {
            $name = 'ExampleJobName'
            $result = New-GhaJob -Id 'job1' -Name $name
            $result.Name | Should -Be $name
        }

        It 'Can have an If parameter' {
            $if = 'success()'
            $result = New-GhaJob -Id 'job1' -If $if
            $result.If | Should -Be $if
        }

        It 'Can have a RunsOn parameter' {
            $runsOn = 'ubuntu-latest'
            $result = New-GhaJob -Id 'job1' -RunsOn $runsOn
            $result.RunsOn | Should -Be $runsOn
        }

        It 'Can have Steps parameter' {
            $steps = @([ModPosh.Pipelines.Gha.Step]::new(), [ModPosh.Pipelines.Gha.Step]::new())
            $result = New-GhaJob -Id 'job1' -Steps $steps
            $result.Steps.Count | Should -Be $steps.Length
        }
    }
}