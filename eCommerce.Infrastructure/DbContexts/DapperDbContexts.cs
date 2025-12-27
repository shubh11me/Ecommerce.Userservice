using Microsoft.Extensions.Configuration;
using System.Data;

namespace eCommerce.Infrastructure.DbContexts
{
    public class DapperDbContexts
    {
        public string ConnectionString { get; }
        private IDbConnection dbConnection;
        public DapperDbContexts(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("PostgresConn");
            ConnectionString = ConnectionString.Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST")).
            Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));
            dbConnection= new Npgsql.NpgsqlConnection(ConnectionString);
        }
        public IDbConnection DbConnection => dbConnection;
    }
}
