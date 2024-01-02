BeforeAll {
    # Import the module or mock the cmdlet if needed
    # Import-Module 'Path\To\Your\Module.psm1'
}

Describe 'New-GhaWorkflow Cmdlet Tests' {

    Context 'Parameter Tests' {
        It 'Should require a Name parameter' {
            { New-GhaWorkflow -Name $null } | Should -Throw -ExpectedMessage "Cannot bind argument to parameter 'Name' because it is null."
        }

        It 'Should accept a Name parameter' {
            { New-GhaWorkflow -Name 'ExampleWorkflow' } | Should -Not -Throw
        }
    }

    Context 'Functionality Tests' {
        It 'Should return an object of type Workflow' {
            $result = New-GhaWorkflow -Name 'ExampleWorkflow'
            $result | Should -BeOfType ModPosh.Pipelines.Gha.Workflow
        }

        It 'Can have a RunName parameter' {
            $runName = 'MyWorkflowRun'
            $result = New-GhaWorkflow -Name 'ExampleWorkflow' -RunName $runName
            $result.RunName | Should -Be $runName
        }

        It 'Can have Jobs parameter' {
            $jobs = @([ModPosh.Pipelines.Gha.Job]::new('Job1'), [ModPosh.Pipelines.Gha.Job]::new('Job2'))
            $result = New-GhaWorkflow -Name 'ExampleWorkflow' -Jobs $jobs
            $result.Jobs.Count | Should -Be $jobs.Length
        }
    }
}
