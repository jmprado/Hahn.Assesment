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

- Windows >10 
- Node.js 22.11 and npm
- .NET SDK 9.0
- Docker and Docker Compose
- PowerShell (for running the PowerShell script)
- Chrome web browser (e.g., Chrome, Firefox)

## Installation and Easy Way

1. Clone the repository:

    ```powershell
    git clone https://github.com/jmprado/Hahn.Assesment.git
    ```

2. Navigate to the project directory:

     Open a PowerShell terminal

    ```powershell
    cd Hahn.Assesment
    ```
3. Make sure that your docker desktop is up and running and run
    
    ```powershell
    ./run-app.ps1
    ```

4. Opening the AlertApp

    Open browser and navigate to https://localhost:5173

5. Notes

## Application URLs on this project 

- Swagger UI: [https://localhost:7185/swagger](https://localhost:7185/swagger)
- Hangfire Dashboard: [https://localhost:7144/hangfire](https://localhost:7144/hangfire)
- Vue App: [https://localhost:5173](https://localhost:5173)


## GitHub Actions Workflow

This project includes a GitHub Actions workflow for building and testing the .NET Core WebAPI. For more details, see the [dotnet.yml](./.github/workflows/dotnet.yml).

## Contributing

Contributions are welcome! Please open an issue or submit a pull request. :wink:

## License

This project is licensed under the MIT License.