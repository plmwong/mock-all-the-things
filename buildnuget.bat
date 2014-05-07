@echo off
.\.nuget\NuGet.exe pack MockAllTheThings.Core\MockAllTheThings.Core.csproj
.\.nuget\NuGet.exe pack MockAllTheThings.Moq\MockAllTheThings.Moq.csproj
.\.nuget\NuGet.exe pack MockAllTheThings.RhinoMocks\MockAllTheThings.RhinoMocks.csproj
.\.nuget\NuGet.exe pack MockAllTheThings.FakeItEasy\MockAllTheThings.FakeItEasy.csproj
