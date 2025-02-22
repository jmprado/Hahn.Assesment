# SQL Server Docker Container

This folder contains the necessary files to build and run a SQL Server Docker container for the Alert App.

## Table of Contents

- [Files](#files)
- [Usage](#usage)
- [Cleaning Up](#cleaning-up)

## Files

- `build.bat`: A batch script to build and run the SQL Server Docker container.

## Usage

1. To build and start the SQL Server container, run the following command:

    ```bash
    ./.dbcontainer/build.bat
    ```

2. If you want to clean the database tables and remove dangling docker images, use the `clean` argument:

    ```bash
    ./.dbcontainer/build.bat clean
    ```

## Cleaning Up

- The [build.bat](http://_vscodecontentref_/2) script can also clean up the database tables and remove dangling images if the `clean` argument is provided.

    ```bash
    ./.dbcontainer/build.bat clean
    ```

This will:
- Stop and remove containers, networks, images, and volumes.
- Remove the `sqlserver` Docker volume.
- Remove dangling Docker images.

## Notes

- Ensure Docker is installed and running on your machine before executing the script.
- The script uses `docker-compose` to manage the container lifecycle.