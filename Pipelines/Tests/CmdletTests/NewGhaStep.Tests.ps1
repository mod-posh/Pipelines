BeforeAll {
    # Import the module or mock the cmdlet if needed
    # Import-Module 'Path\To\Your\Module.psm1'
}

Describe 'New-GhaStep Cmdlet Tests' {

    Context 'Parameter Tests' {
        It 'Should require an Id parameter' {
            { New-GhaStep -Id $null } | Should -Throw -ExpectedMessage "Cannot bind argument to parameter 'Id' because it is null."
        }

        It 'Should accept an Id parameter' {
            { New-GhaStep -Id 'step1' } | Should -Not -Throw
        }
    }

    Context 'Functionality Tests' {
        It 'Should return an object of type Step' {
            $result = New-GhaStep -Id 'step1'
            $result | Should -BeOfType ModPosh.Pipelines.Gha.Step
        }

        It 'Can have a Name parameter' {
            $name = 'ExampleStepName'
            $result = New-GhaStep -Id 'step1' -Name $name
            $result.Name | Should -Be $name
        }

        It 'Can have a Uses parameter' {
            $uses = 'actions/checkout@v2'
            $result = New-GhaStep -Id 'step1' -Uses $uses
            $result.Uses | Should -Be $uses
        }

        It 'Can have a Run parameter' {
            $run = 'echo Hello World'
            $result = New-GhaStep -Id 'step1' -Run $run
            $result.Run | Should -Be $run
        }

        It 'Can have With parameter' {
            $with = @{ name = 'value' }
            $result = New-GhaStep -Id 'step1' -With $with

            # Ensure $result.with contains all keys from $variables
            foreach ($key in $with.Keys) {
                $result.with.ContainsKey($key) | Should -Be $true
                $result.with[$key] | Should -Be $with[$key]
            }

            # Ensure $result.with does not contain extra keys
            foreach ($key in $result.with.Keys) {
                $with.ContainsKey($key) | Should -Be $true
            }
        }
    }
}