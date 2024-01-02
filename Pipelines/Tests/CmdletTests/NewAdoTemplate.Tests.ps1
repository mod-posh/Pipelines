BeforeAll {
    # Import the module or mock the cmdlet if needed
    # Import-Module 'Path\To\Your\Module.psm1'
}

Describe 'New-AdoTemplate Cmdlet Tests' {

    Context 'Parameter Tests' {
        It 'Should require a Name parameter' {
            { New-AdoTemplate -Name $null } | Should -Throw -ExpectedMessage "Cannot bind argument to parameter 'Name' because it is null."
        }

        It 'Should accept a Name parameter' {
            { New-AdoTemplate -Name 'ExampleTemplate' } | Should -Not -Throw
        }
    }

    Context 'Functionality Tests' {
        It 'Should return an object of type Template' {
            $result = New-AdoTemplate -Name 'ExampleTemplate'
            $result | Should -BeOfType ModPosh.Pipelines.Ado.Template
        }

        It 'Can have Parameters parameter' {
            $parameters = @{ Param1 = 'Value1'; Param2 = 'Value2' }
            $result = New-AdoTemplate -Name 'ExampleTemplate' -Parameters $parameters

            # Check if all keys and values in the input hashtable match those in the result dictionary
            foreach ($key in $parameters.Keys) {
                $result.Parameters.ContainsKey($key) | Should -Be $true
                $result.Parameters[$key] | Should -Be $parameters[$key]
            }

            # Check if there are no extra keys in the result dictionary
            foreach ($key in $result.Parameters.Keys) {
                $parameters.ContainsKey($key) | Should -Be $true
            }
        }
    }
}