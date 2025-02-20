# Alert App

This is a Vue.js application that displays weather alerts from the Deutscher Wetterdienst. The application includes a grid to display weather reports and an overlay to show detailed images of the alerts.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Components](#components)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)

## Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/alert-app.git
    ```

2. Navigate to the project directory:

    ```bash
    cd ./.dbcontauner alert-app
    ```

3. Install the dependencies:

    ```bash
    npm install
    ```

## Usage

1. Start the development server:

    ```bash
    npm run dev
    ```

2. Open your browser and navigate to `http://localhost:8080`.

## Components

### `BaseView.vue`

This component serves as a base layout for other views. It includes a `v-app-bar` that displays a title passed as a prop.

### `HomePage.vue`

This is the home page of the application. It uses the `BaseView` component and includes the `AlertDetails` component to display detailed information about the alerts.

### `AlertDetails.vue`

This component displays detailed information about a specific weather alert, including categories and reports.

### `AlertReports.vue`

This component displays a grid of weather reports using the `ag-grid-vue3` component. It also includes an overlay to show detailed images of the alerts.

### `AlertImage.vue`

This component displays an image of the alert in the overlay.

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