using Microsoft.Extensions.Configuration;

public class Settings
{
    private IConfigurationRoot configuration;

    public Settings()
    {
        this.configuration = new ConfigurationBuilder()
        .AddJsonFile("local.appsettings.json")
        .AddEnvironmentVariables()
        .Build();
    }

    public string Get(string key)
    {
        return configuration[key] ?? "";
    }
}