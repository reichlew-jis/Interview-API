# Interview API
The Interview API is the backend for the Interview UI, intended to store and serve up Interview configuration such as dashboards, widgets, default courts, etc.

## Getting Started
The API and tests should all run locally without any additional changes, and points to the Development environment but using LocalDB for data persistance.

If you need to target a different database, such as a docker hosted database, you can override the connection string by:
* Setting a user secret
* Setting an environment variable `ConnectionStrings:InterviewDbConnectionString = <your-connection-string>`
* Modifying the `ConnectionStrings:InterviewDbConnectionString` value in `appsettings.json` (please don't commit the change!)

## Adding an Entity Framework Migration
If changes are required to the entity framework entities or context, you need to make sure that you scaffold a migration in order to update any existing databases that may have already been created.

At a high level, the process is as follows:
1. Make any entity additions/modifications/removals
   * It is generally a good idea to have smaller, more atomic migrations. Try to keep migrations specific to a single change at a time.
2. In Visual Studio, open the Package Manager Console (`View > Other Windows > Package Manager Console`)
3. Select the correct Default Project from the drop-down (`src\Interview.Data`)
4. Type `Add-Migration <migration-name>`
5. If you get a warning about data loss, that means that your migration is too complex for EF to understand and you will likely lose data
   * You should probably rethink your migration strategy - do the migration in several smaller migrations and EF will likely handle the data correctly
   * Alternatively you can modify the generated migrations to correctly map your data
6. You create/migrate your database by selecting Interview.Data project in the Package Manager Console and typing `Update-Database` or running the application locally which will automatically migrate the database configured in `appsettings.json` (LocalDB by default)
