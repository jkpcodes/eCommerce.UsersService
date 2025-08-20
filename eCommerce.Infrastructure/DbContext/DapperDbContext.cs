using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string? connectionString = _configuration.GetConnectionString("PostgresConnection");

        // Create new NpgsqlConnection instance using the connection string
        _connection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection Connection => _connection;
}
