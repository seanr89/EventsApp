
namespace EventsAPI.Models.Settings;

public class PostgreSQLSettings
{
    public string ConnectionString { get; set; }
    public bool Migrate { get; set; }
    public bool SeedData { get; set; }
}