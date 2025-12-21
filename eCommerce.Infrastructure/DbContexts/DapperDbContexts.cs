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
            dbConnection= new Npgsql.NpgsqlConnection(ConnectionString);
        }
        public IDbConnection DbConnection => dbConnection;
    }
}
