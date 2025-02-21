param (
    [string]$n
)

if (-not $n) {
    Write-Host ""
    Write-Host "Error: Please provide a migration name."
    Write-Host "Usage: .\init-migration.ps1 -n <MigrationName>"
    Write-Host ""
    exit 1
}

$webapi_path = ".\src\Hann.Assesment\Presentation\Hahn.Assesment.WebAPI"
$migrations_path = ".\src\Hann.Assesment\Infrastructure\Hahn.Assesment.Persistence"

dotnet ef migrations add $n --verbose -s $webapi_path -p $migrations_path
dotnet ef database update -s $webapi_path