@echo off
@echo off

REM Check if a parameter is provided
IF "%1"=="" (
    ECHO Please provide a migration name.
    EXIT /B 1
)

SET MigrationName=%1

dotnet ef migrations add %MigrationName% --verbose -s .\Hann.Assesment\Presentation\Hahn.Assesment.WebAPI -p .\Hann.Assesment\Infrastructure\Hahn.Assesment.Persistence\Hahn.Assesment.Persistence.csproj
dotnet ef database update -s .\Hann.Assesment\Presentation\Hahn.Assesment.WebAPI