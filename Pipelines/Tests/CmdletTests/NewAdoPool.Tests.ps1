BeforeAll {
    # Assuming the module needs to be imported or mocked
    # Import-Module 'Path\To\Your\Module.psm1'
}

Describe 'New-AdoPool Cmdlet Tests' {

    Context 'Parameter Tests' {
        It 'Should require a Name parameter' {
            { New-AdoPool -Name $null } | Should -Throw -ExpectedMessage "Cannot bind argument to parameter 'Name' because it is null."
        }

        It 'Should accept a Name parameter' {
            { New-AdoPool -Name 'ExamplePool' } | Should -Not -Throw
        }
    }

    Context 'Functionality Tests' {
        It 'Should return an object of type Pool' {
            $result = New-AdoPool -Name 'ExamplePool'
            $result | Should -BeOfType ModPosh.Pipelines.Ado.Pool
        }

        It 'Can have Demands parameter' {
            $demands = @('demand1', 'demand2')
            $result = New-AdoPool -Name 'ExamplePool' -Demands $demands

            # Check if the number of demands in the result is equal to the input
            $result.Demands.Count | Should -Be $demands.Length

            # Check each demand individually
            for ($i = 0; $i -lt $demands.Length; $i++) {
                $result.Demands[$i] | Should -Be $demands[$i]
            }
        }
    }
}