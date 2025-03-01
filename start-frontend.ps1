Write-Output "Starting vue app..."
Write-Output "Installing node packages... "
$alert_app_path = ".\src\alert-app"
powershell.exe -Command "cd `"$alert_app_path`" `n npm install"

if ($errors_npm_install.Length -gt 0) {
    Write-Output "Error: npm install failed."
    Write-Output $errors_npm_install
    exit 1
}

Write-Output "Running alert-app..."
powershell.exe -Command "cd `"$alert_app_path`" `n npm run dev"

