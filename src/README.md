# Init Migration Script

This script is used to create and apply Entity Framework Core migrations for the Hahn Assessment project.

## Usage

1. Open a command prompt or terminal.

2. Navigate to the directory containing the `init-migration.bat` script:

    ```bash
    cd /d:/Work/Personal/HahnAssesment/src
    ```

3. Run the script with the desired migration name as a parameter:

    ```bash
    init-migration.bat MigrationName
    ```

    Replace `MigrationName` with the name of your migration.

## Parameters

- `MigrationName`: The name of the migration to be created.

## Example

To create a migration named `InitialCreate`, run the following command:

```bash
init-migration.bat InitialCreate