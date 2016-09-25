REM @echo off

set project=Bqpl.MicroKernel

set config=%1
if "%config%" == "" (
   set config=Release
)

REM Restore Packages by DotNet
call dotnet restore
if not "%errorlevel%"=="0" goto failure

REM Update AssemblyInfo by GitVersion
call %GitVersion% /updateassemblyinfo true
if not "%errorlevel%"=="0" goto failure

REM Build Solution by MSBuild
"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" %project%.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
if not "%errorlevel%"=="0" goto failure

REM Run Unittests by NUnit
call %XUnit20Path%\xunit.console.exe /config:%config% /framework:net-4.6.1 %project%.Test\bin\%config%\%project%.Test.dll
if not "%errorlevel%"=="0" goto failure

REM Pack NuSpec-Packages by NuGet
set version=
if not "%PackageVersion%" == "" (
   set version=-Version %PackageVersion%
)
call %nuget% pack "%project%\%project%.nuspec" %version%
if not "%errorlevel%"=="0" goto failure
call %nuget% pack "%project%\%project%.symbols.nuspec" %version%
if not "%errorlevel%"=="0" goto failure

:success
exit 0

:failure
exit -1
