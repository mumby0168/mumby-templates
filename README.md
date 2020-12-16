# dotnet-templates
A collection of dotnet templates for a variety of uses.

# Getting Started
The templates are available for use with dotnet new, Visual Studio 2019 and Rider. Simply install the following package to your dotnet cli tool using the followoing command.

```dotnet new --install Mumby.Templates::1.0.0```

# Templates
This section describes the templates that are available.

## Dependency Injection Console Application
This template makes use of Microsoft's common packages that are used within ASP.NET Core project templates see the packages included are shown below as well as how to use this project template.

```dotnet new consoledi```

```csproj
<PackageReference Include="Microsoft.Extensions.Configuration" Version="5.0.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.Binder" Version="5.0.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="5.0.0" />
<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="5.0.1" />
<PackageReference Include="Microsoft.Extensions.Logging" Version="5.0.0" />
<PackageReference Include="Microsoft.Extensions.Logging.Abstractions" Version="5.0.0" />
<PackageReference Include="Microsoft.Extensions.Logging.Console" Version="5.0.0" />
```

### Explained

The template takes inspiration from the standard template ```dotnet new web``` defining a very similar ```Startup.cs```.

The methods below play different roles in the template.

#### Configuring Services
This method allows you to register any normal services in DI container for your application.

```csharp
private Startup ConfigureServices(IServiceCollection services)
{
    //TODO: Register services here
    services.AddSingleton<ICleverService, CleverService>();
    return this;
}
```

#### Configuring Logging
This method allows you to setup the logger adding providers as you wish, in this case the console but other packages can be added such as NLog.

```csharp
private Startup ConfigureLogging(IServiceCollection services)
{
    //TODO: Configure logging here
    services.AddLogging(builder =>
    {
        builder.ClearProviders();
        builder.AddConsole();
    });
    return this;
}
```

#### Configuring Options
This method allows you to process configuration files such as ```appsettings.json``` and modify the DI container based on this.

```csharp
private Startup ConfigureOptions(IServiceCollection services)
{
    _configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json",  true, true)
        .Build();

    var settings = new Settings();
    _configuration.GetSection("settings").Bind(settings);

    services.AddSingleton(settings);

    //TODO: Configure options here
    return this;
}
```
