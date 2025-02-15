@echo off
dotnet ef migrations add AlertAppDbContext --verbose -s .\Hann.Assesment\Presentation\Hahn.Assesment.WebAPI -p .\Hann.Assesment\Infrastructure\Hahn.Assesment.Persistence\Hahn.Assesment.Persistence.csproj
dotnet ef database update -s .\Hann.Assesment\Presentation\Hahn.Assesment.WebAPI