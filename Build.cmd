@echo off
set config=%1
if "%config%" == "" (
	set config=Release
)

set version=
if not "%PackageVersion%" == "" (
	set version=-Version %PackageVersion%
)

REM Package Restore
tools\nuget.exe restore Cors.ConfigProfiles.sln -OutputDirectory %cd%\packages -NonInteractive

REM Build
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild Cors.ConfigProfiles.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false

REM Package
mkdir Build
mkdir Build\nuget
tools\nuget.exe pack "Cors.ConfigProfiles\Cors.ConfigProfiles.csproj" -symbols -o Build\nuget -p Configuration=%config% %version%

REM Assemblies
mkdir Build\assemblies
copy Cors.ConfigProfiles\bin\%config%\Cors.ConfigProfiles.dll Build\assemblies
copy Cors.ConfigProfiles\bin\%config%\Cors.ConfigProfiles.pdb Build\assemblies