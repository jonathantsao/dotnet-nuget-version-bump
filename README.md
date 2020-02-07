# dotnet-nuget-version-bump

Dotnet global tool for updating nuget package ids

## Installation
- Fork project
- In project, run `dotnet pack` and `dotnet tool install --global --add-source ./nupkg Version.Bump`

## Usage
- run `version-bump <PATH_TO_PROJECT_CONTAINING_CSPROJ> <patch | minor | major>`
