namespace FinanceTrackerAPI.Others;

public static class CustomConfigurationManager
{
    public static IConfiguration AppSettings { get; set; }

    static CustomConfigurationManager()
    {
        AppSettings = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }
}
