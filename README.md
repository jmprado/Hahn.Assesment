# Hahn Assessment Project - Alert App

Hey there! Welcome to the Hahn Assessment Project - Alert App. 🚀

This application fetches and displays data provided by the Deutscher Wetterdienst public API.

You can find the complete API documentation here.

The data source chosen is the `crowd_meldungen_overview_v2.json` file. You can check it out using the link below:

Heads up! This is a JSON file: [crowd_meldungen_overview_v2.json](https://s3.eu-central-1.amazonaws.com/app-prod-static.warnwetter.de/v16/crowd_meldungen_overview_v2.json) 

The main projects for this assessment are located at:

- [WebAPI](./src/Hann.Assesment/Presentation/Hahn.Assesment.WebAPI/)
- [WorkerService](./src/Hann.Assesment/Presentation/Hann.Assesment.WorkerService/)
- [Vue app](./src/alert-app/)
- [Hangfire Scheduling](./src/Hann.Assesment/Core/Hahn.Assesment.Hangfire/)

Projects that provides Clean Architecture and DDD:
- [Core](./src/Hann.Assesment/Core/)
- [Domain](./src/Hann.Assesment/Core/Hahn.Assesment.Domain/)
- [Infrastructure](./src/Hann.Assesment/Infrastructure/)

## Extra services/projects
- [SqlServer Container](./src/dbcontainer/)
- [Unit Tests](./src/Hann.Assesment/Tests/)
- [CI](./.github/workflows/dotnet.yml)

## Tech Stack

- **Frontend**: Vue.js, Vuetify
- **Backend**: .NET 9.0, Entity Framework Core, Hangfire
- **Build Tools**: Docker, Docker Compose
- **Database**: SQL Server (Docker container)
- **Task Runner**: PowerShell

## Requirements

- Windows version >= 10 
- Node.js 22.11 and npm
- .NET Core 9 SDK
- .NET Core 9 runtime 
- Docker and Docker Compose
- PowerShell (for running the PowerShell scripts)
- Chrome web browser (e.g., Chrome, Firefox)

## Installation and Usage

1. Clone the repository:

    ```powershell
    git clone https://github.com/jmprado/Hahn.Assesment.git
    ```

2. Navigate to the project directory:

     Open a PowerShell terminal and navigate to the project root folder

    ```powershell
    cd Hahn.Assesment
    ```

3. Make sure that your docker desktop is started then run
    
    ```powershell
    ./run-app.ps1
    ```

4. Opening the AlertApp

    Open browser and navigate to https://localhost:5173

## Application URLs

- Swagger UI: [https://localhost:7185/swagger](https://localhost:7185/swagger)
- Hangfire Dashboard: [https://localhost:7144/hangfire](https://localhost:7144/hangfire)
- Vue App: [https://localhost:5173](https://localhost:5173)

## GitHub Actions Workflow

This project includes a GitHub Actions workflow for building and testing the .NET Core WebAPI. For more details, see the dotnet.yml.

> Check the GitHub Actions tab to see the actions that have been run.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request. :wink:

## License

This project is licensed under the MIT License.
