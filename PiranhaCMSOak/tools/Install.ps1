param($installPath, $toolsPath, $package, $project) 
$project.ProjectItems.Item("Oak").Remove() | Select-Object | Get-ChildItem -Recurse | Remove-Item -force -recurse
