Write-Output "Cleaning the solution..."
dotnet clean .

Write-Output "Building the solution..."
dotnet build .

Write-Output "Build finished. Starting applications..."

$presentation_path = ".\src\Hann.Assesment\Presentation"

# Start the WebAPI project with HTTPS profile
Start-Process "dotnet" "run --project $presentation_path\Hahn.Assesment.WebAPI\Hahn.Assesment.WebAPI.csproj --launch-profile https"

# Start the Hangfire project with HTTPS profile
Start-Process "dotnet" "run --project $presentation_path\Hann.Assesment.WorkerService\Hann.Assesment.WorkerService.csproj --launch-profile https"

Start-Sleep -Seconds 10 # Wait for the applications to start, increase this if needed

Write-Output "Launching browser for backend applications..."

Start-Process "chrome" "https://localhost:7185/swagger/"
Start-Process "chrome" "https://localhost:7144/hangfire/"


