$solutionPath = "D:\GitHub\WPF-VisionMaster\Solution\WPF-VisionMaster.sln"
$projectsFolder = "D:\GitHub\WPF-VisionMaster\Source\WPF-Control\Source"

# 获取所有项目文件
$projectFiles = Get-ChildItem -Path $projectsFolder -Recurse -Filter *.csproj

# 遍历并添加每个项目
foreach ($projectFile in $projectFiles) {
    $projectPath = $projectFile.FullName
    $projectName = $projectFile.BaseName
    $projectGuid = [guid]::NewGuid().ToString().ToUpper()

    # 添加项目到解决方案
    dotnet sln $solutionPath add $projectPath
}