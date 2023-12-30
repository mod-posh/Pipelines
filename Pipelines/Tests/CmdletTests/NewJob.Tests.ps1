BeforeAll {
    # Import the module or mock the cmdlet if needed
    # Import-Module 'Path\To\Your\Module.psm1'
}

Describe 'New-Job Cmdlet Tests' {

    Context 'Parameter Tests' {
        It 'Should require a Name parameter' {
            { New-Job -Name $null } | Should -Throw -ExpectedMessage "Cannot bind argument to parameter 'Name' because it is null."
        }

        It 'Should accept a Name parameter' {
            { New-Job -Name 'ExampleJob' } | Should -Not -Throw
        }
    }

    Context 'Functionality Tests' {
        It 'Should return an object of type Ado.Job' {
            $result = New-Job -Name 'ExampleJob'
            $result | Should -BeOfType ModPosh.Pipelines.Ado.Job
        }

        It 'Can have a Pool parameter' {
            $pool = [ModPosh.Pipelines.Ado.Pool]::new()
            $result = New-Job -Name 'ExampleJob' -Pool $pool
            $result.Pool | Should -Be $pool
        }

        It 'Can have Variables parameter' {
            $variables = @{ Variable1 = 'Value1'; Variable2 = 'Value2' }
            $result = New-Job -Name 'ExampleJob' -Variables $variables

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

        It 'Can have Steps parameter' {
            $steps = @([ModPosh.Pipelines.Ado.Template]::new(), [ModPosh.Pipelines.Ado.Template]::new())
            $result = New-Job -Name 'ExampleJob' -Steps $steps
            $result.Steps.Count | Should -Be $steps.Length
        }
    }
}