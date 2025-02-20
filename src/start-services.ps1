Write-Output "Cleaning the solution..."
dotnet clean .

Write-Output "Building the solution..."
dotnet build .

Write-Output "Build finished. Starting applications..."

# Start the WebAPI project with HTTPS profile
Start-Process "dotnet" "run --project .\Hann.Assesment\Presentation\Hahn.Assesment.WebAPI\Hahn.Assesment.WebAPI.csproj --launch-profile https"

# Start the Hangfire project with HTTPS profile
Start-Process "dotnet" "run --project .\Hann.Assesment\Presentation\Hann.Assesment.WorkerService\Hann.Assesment.WorkerService.csproj --launch-profile https"

Start-Sleep -Seconds 10 # Wait for the applications to start, increase this if needed

Write-Output "Launching browser..."

Start-Process "chrome" "https://localhost:7185/swagger/"
Start-Process "chrome" "https://localhost:7144/hangfire/"