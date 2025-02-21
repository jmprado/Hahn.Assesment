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

2. Create the migrations and init the database:

    ```bash
    ./src/init-migration.ps1 init_migration
    ```

### Usage

1. Start the netcore services:

    ```powershell
    ./src/start-services.ps1
    ```

1.1. If the application does not open the .NET Core applications in Chrome automatically, please open your browser and navigate to the following URLs:
    - Swagger UI: [https://localhost:7185/swagger/](https://localhost:7185/swagger/)
    - Hangfire Dashboard: [https://localhost:7144/hangfire/](https://localhost:7144/hangfire/)

## GitHub Actions Workflow

This project includes a GitHub Actions workflow for building and testing the .NET Core WebAPI. For more details, see the [dotnet.yml](./.github/workflows/dotnet.yml).

## Vue App

For instructions to run the Vue app, see the Alert App README.

## Configuration

### `api-urls.js`

This file defines the API endpoints for fetching weather alerts and reports.

### `api-client.js`

This file contains the API client for making HTTP requests to the Deutscher Wetterdienst API.

### `useAlertAppStore.js`

This file contains the Pinia store for managing the state of the application.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request. :wink:

## License

This project is licensed under the MIT License.