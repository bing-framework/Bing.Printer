@echo off
echo %1
cd ..

rem clear old packages
del output\* /q/f/s

rem build
dotnet build Bing.Printer.sln -c Release

rem pack
dotnet pack ./src/Bing.Printer.Abstractions/Bing.Printer.Abstractions.csproj
dotnet pack ./src/Bing.Printer.Core/Bing.Printer.Core.csproj
dotnet pack ./src/Bing.Printer.EscPos/Bing.Printer.EscPos.csproj

rem push
for %%i in (output\release\*.nupkg) do dotnet nuget push %%i -k %1 -s https://www.nuget.org/api/v2/package