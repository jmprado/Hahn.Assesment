# Hahn Assessment Project

This project contains multiple components, including a Vue.js application for displaying weather alerts and a SQL Server Docker container for managing the database.

## Tech Stack

- **Frontend**: Vue.js, Vuetify
- **Backend**: .NET 9.0, Entity Framework Core, Hangfire
- **Database**: SQL Server (Docker container)
- **Build Tools**: Docker, Docker Compose
- **Task Runner**: PowerShell, Batch scripts

## Table of Contents

- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
- [Components](#components)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)

## Requirements

- Node.js and npm
- .NET SDK 9.0
- Docker and Docker Compose
- PowerShell (for running the PowerShell script)
- A modern web browser (e.g., Chrome, Firefox)

## Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/alert-app.git
    ```

2. Navigate to the project directory:

    ```bash
    cd alert-app
    ```

## Installation and Usage

### Installation

1. Start the SQL Server container:

    ```bash
    ./.dbcontainer/build.bat
    ```

2. Initialize the database migration:

    ```bash
    ./src/init-migration.bat MigrationName
    ```

    Replace `MigrationName` with the name of your migration.

### Usage

1. Start the netcore services:

    ```powershell
    ./src/start-services.ps1
    ```

1.1. If the application does not open the .NET Core applications in Chrome automatically, please open your browser and navigate to the following URLs:
    - Swagger UI: [https://localhost:7185/swagger/](https://localhost:7185/swagger/)
    - Hangfire Dashboard: [https://localhost:7144/hangfire/](https://localhost:7144/hangfire/)

## Vue App

For instructions to run the Vue app, see the Alert App [./src/alert-app/README.md](README.md).

## Configuration

### `api-urls.js`

This file defines the API endpoints for fetching weather alerts and reports.

### `api-client.js`

This file contains the API client for making HTTP requests to the Deutscher Wetterdienst API.

### `useAlertAppStore.js`

This file contains the Pinia store for managing the state of the application.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.