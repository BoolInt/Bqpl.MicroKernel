@echo off

set project=Bqpl.MicroKernel

set config=%1
if "%config%" == "" (
   set config=Release
)

REM Restore
call dotnet restore
if not "%errorlevel%"=="0" goto failure

REM Build
"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" %project%.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
if not "%errorlevel%"=="0" goto failure

REM Unit tests
call %nuget% install NUnit.Runners -Version 3.4.1 -OutputDirectory packages
packages\NUnit.Runners.3.4.1\tools\nunit-console.exe /config:%config% /framework:net-4.6.1 %project%.Test\bin\%config%\%project%.Test.dll
if not "%errorlevel%"=="0" goto failure

REM Package
REM Die Paket-Informationen werden aus der project.json gezogen. Diese ist aber nicht aktuell (Version)
REM mkdir %cd%\Artifacts
REM call dotnet pack %project% --configuration %config% --output Artifacts
REM if not "%errorlevel%"=="0" goto failure

REM Pack
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
