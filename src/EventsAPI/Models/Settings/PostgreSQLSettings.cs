
namespace EventsAPI.Models.Settings;

/// <summary>
/// DB App Settings
/// </summary>
public class PostgreSQLSettings
{
    /// <summary>
    /// DBConnection string
    /// </summary>
    /// <value></value>
    public string ConnectionString { get; init; }
    /// <summary>
    /// Controls if migration is to be executed
    /// </summary>
    /// <value></value>
    public bool Migrate { get; init; }
    /// <summary>
    /// Controls if data seeding is to occur
    /// </summary>
    /// <value></value>
    public bool SeedData { get; init; }

    /// <summary>
    /// default constructor
    /// </summary>
    /// <param name="connectionString"></param>
    /// <param name="migrate"></param>
    /// <param name="seedData"></param>
    public PostgreSQLSettings(string connectionString, bool migrate, bool seedData)
    {
        this.ConnectionString = connectionString;
        this.Migrate = migrate;
        this.SeedData = seedData;
    }
}