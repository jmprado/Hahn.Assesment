@echo off
REM Remove the Migrations directory
REM rmdir /s /q .\docker\

REM Stop and remove containers, networks, images, and volumes
docker-compose down

IF "%1"=="clean" (
    echo Cleaning DB tables...
    docker volume rm sqlserver

    echo Cleaning the <none> images...
    FOR /F "tokens=*" %%i IN ('docker images -f "dangling=true" -q') DO docker rmi %%i
)

REM Build the Docker image
docker build -t sqlserver .
docker-compose up
