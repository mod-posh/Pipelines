BeforeAll {
    # Assuming the module needs to be imported or mocked
    # Import-Module 'Path\To\Your\Module.psm1'
    # or define Mocks if necessary
}

Describe 'New-Stage Cmdlet Tests' {

    Context 'Parameter Tests' {
        It 'Should require a Name parameter' {
            { New-Stage -Name $null } | Should -Throw -ExpectedMessage "Cannot bind argument to parameter 'Name' because it is null."
        }

        It 'Should accept a Name parameter' {
            { New-Stage -Name 'ExampleStage' } | Should -Not -Throw
        }
    }

    Context 'Functionality Tests' {
        BeforeAll {
            # Common setup for this context, if needed
        }

        It 'Should return an object of type Stage' {
            $result = New-Stage -Name 'ExampleStage'
            $result | Should -BeOfType ModPosh.Pipelines.Ado.Stage
        }

        It 'Can have a DisplayName parameter' {
            $displayName = 'StageDisplayName'
            $result = New-Stage -Name 'ExampleStage' -DisplayName $displayName
            $result.DisplayName | Should -Be $displayName
        }

        It 'Can have DependsOn parameter' {
            $dependsOn = @('Stage1', 'Stage2')
            $result = New-Stage -Name 'ExampleStage' -DependsOn $dependsOn
            $result.DependsOn | Should -Be $dependsOn
        }

        It 'Can have a Condition parameter' {
            $condition = 'success()'
            $result = New-Stage -Name 'ExampleStage' -Condition $condition
            $result.Condition | Should -Be $condition
        }

        It 'Can have Variables parameter' {
            $variables = @{ Variable1 = 'Value1'; Variable2 = 'Value2' }
            $result = New-Stage -Name 'ExampleStage' -Variables $variables

            # Ensure $result.Variables contains all keys from $variables
            foreach ($key in $variables.Keys) {
                $result.Variables.ContainsKey($key) | Should -Be $true
                $result.Variables[$key] | Should -Be $variables[$key]
            }

            # Ensure $result.Variables does not contain extra keys
            foreach ($key in $result.Variables.Keys) {
                $variables.ContainsKey($key) | Should -Be $true
            }
}
        It 'Can have Jobs parameter' {
            $jobs = @([ModPosh.Pipelines.Ado.Job]::new(), [ModPosh.Pipelines.Ado.Job]::new())
            $result = New-Stage -Name 'ExampleStage' -Jobs $jobs
            $result.Jobs.Count | Should -Be $jobs.Length
        }

        AfterAll {
            # Cleanup for this context, if needed
        }
    }

    AfterAll {
        # Global cleanup, if needed
    }
}