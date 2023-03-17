#this is not tested fully on a more complex solution, but gives you some
#ideas to find possible conflicts in libraries

$solution = ".\test-deps.sln"
$outputPath = "\bin\Debug\netcoreapp3.1"

$solutionLibraries = @{}
$conflictLibraries = @{}

foreach ($line in Get-Content $solution) {

    if ($line.StartsWith("Project")) {

        $parts = $line.Split(',')
        $projectPart = $parts[1].Trim(' ').Trim('"').Split("\")
        $projectName = $projectPart[0]
        $projectFolder = ".\" + $projectPart[0] + $outputPath + "\"
        $depsFile = $projectFolder + $projectPart[1].Replace(".csproj", ".deps.json")
       
        
        $deps = Get-Content $depsFile | ConvertFrom-Json
        $libraries = $deps.libraries

        $props = Get-Member -InputObject $libraries -MemberType NoteProperty

        foreach($prop in $props) {
            $lib = $prop.Name.Split("/")

            $libraryName = $lib[0]
            $libraryVersion = $lib[1]

                        
            if ($solutionLibraries.ContainsKey($libraryName)) {

                if ($solutionLibraries[$libraryName] -ne $libraryVersion)
                {
                    $conflictLibraries[$prop.Name] = $projectName
                }
            }
            else
            {
                $solutionLibraries[$libraryName] = $libraryVersion
            }
           
        }
    }
}


Write-Host "Possible Conflicts"
Write-Host "=================================================="
$conflictLibraries
Write-Host ""
Write-Host "All Libraries"
Write-Host "=================================================="
$solutionLibraries
