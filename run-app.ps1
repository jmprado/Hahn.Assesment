# Run the build script
Write-Output "Running build script..."
& .\.dbcontainer\build.ps1

# Run the migrations script
Write-Output "Running migrations script..."
& .\run-migrations.ps1 -n "InitialMigration"

# Run the start-app script
Write-Output "Starting WebAPI and Hangfire..."
& .\start-backend.ps1

Write-Output "Starting Vue AlertApp..."
& .\start-frontend.ps1
