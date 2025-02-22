param (
    [string]$Action
)

# Stop and remove containers, networks, images, and volumes
docker-compose down

if ($Action -eq "clean") {
    Write-Host "Cleaning container volume..."
    docker volume rm sqlserver

    Write-Host "Cleaning the <none> images..."
    $danglingImages = docker images -f "dangling=true" -q
    foreach ($image in $danglingImages) {
        docker rmi $image
    }
}

# Build the Docker image
docker build -t sqlserver .

# Start the container
docker-compose up -d