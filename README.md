# SingletonApp

[![NuGet](https://img.shields.io/nuget/v/Asjc.SingletonApp)](https://www.nuget.org/packages/Asjc.SingletonApp/)

Ensure only one instance of the application is running.

## Usage

1. Initializes the singleton check.

   ```csharp
   SingletonApp.Initialize();
   ```

2. Check if the current instance is the first/only one.

   ```csharp
   if (!SingletonApp.IsNew)
   {
       // Do something.
   }
   ```

3. **Recommended**: Clean up resources when the application exits.

   ```csharp
   SingletonApp.Cleanup();
   ```

## Credits

- Icon from https://www.iconfinder.com/icons/2190995