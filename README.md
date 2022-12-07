# ![Serilog.Sinks.File.LatestFile](https://i.imgur.com/eX0jzL0.png)
A simple plugin for [Serilog.Sinks.File](https://github.com/serilog/serilog-sinks-file) based on the `FileLifecycleHooks` API.

# Getting Started
Install the [Serilog.Sinks.File.LatestFile](https://www.nuget.org/packages/Serilog.Sinks.File.LatestFile) package from NuGet:

## DotNet CLI
```
dotnet add package Serilog.Sinks.File.LatestFile
```

## Powershell
```
Install-Package Serilog.Sinks.File.LatestFile
```

# Usage
```csharp
using Serilog;
using Serilog.Sinks.File.LatestFile;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((host, configuration) => configuration
    .WriteTo.File("latest.txt", hooks: new LatestFileHook()));
```

## License
MIT Licence.