BeforeAll {
    # Assuming the module needs to be imported or mocked
    # Import-Module 'Path\To\Your\Module.psm1'
    # or define Mocks if necessary
}

Describe 'New-AdoPipeline Cmdlet Tests' {

    Context 'Parameter Tests' {
        It 'Should require a Name parameter' {
            { New-AdoPipeline -Name $null } | Should -Throw -ExpectedMessage "Cannot bind argument to parameter 'Name' because it is null."
        }

        It 'Should accept a Name parameter' {
            { New-AdoPipeline -Name 'ExamplePipeline' } | Should -Not -Throw
        }
    }

    Context 'Functionality Tests' {
        BeforeAll {
            # Common setup for this context, if needed
        }

        It 'Should return an object of type Pipeline' {
            $result = New-AdoPipeline -Name 'ExamplePipeline'
            $result | Should -BeOfType ModPosh.Pipelines.Ado.Pipeline
        }

        It 'Should have an empty Stages list by default' {
            $result = New-AdoPipeline -Name 'ExamplePipeline'
            $result.Stages.Count | Should -Be 0
        }

        It 'Should accept Stages parameter' {
            $stages = @([ModPosh.Pipelines.Ado.Stage]::new(), [ModPosh.Pipelines.Ado.Stage]::new())
            $result = New-AdoPipeline -Name 'ExamplePipeline' -Stages $stages
            $result.Stages.Count | Should -Be $stages.Length
        }

        AfterAll {
            # Cleanup for this context, if needed
        }
    }

    AfterAll {
        # Global cleanup, if needed
    }
}
