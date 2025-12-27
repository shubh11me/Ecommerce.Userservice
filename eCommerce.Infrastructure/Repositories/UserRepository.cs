using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContexts;
namespace eCommerce.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private  readonly DapperDbContexts _db;
        public UserRepository(DapperDbContexts db)
        {
            _db = db;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId= Guid.NewGuid();
            string insertQuery = @"INSERT INTO Public.""Users"" (""UserId"", ""Email"", ""Password"", ""PersonName"", ""Gender"")
                       VALUES (@UserId, @Email, @Password, @PersonName, @Gender);";
            int rowAffected=await _db.DbConnection.ExecuteAsync(insertQuery, user);
            if(rowAffected==0)
            {
                return null;
            }
            return user;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            string query = @"SELECT * FROM public.""Users"" WHERE ""Email""=@Email AND ""Password""=@Password";
            object paramz = new { Email = email, Password = password };
            ApplicationUser record=await _db.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, paramz);
            if (record is null) return null;
            else return record;
        }

        public async Task<ApplicationUser?> GetUserById(Guid? userId)
        {
            string query = @"SELECT * FROM public.""Users"" WHERE ""UserId""=@UserId";
            object paramz = new { UserId = userId };
            ApplicationUser record=await _db.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, paramz);
            if (record is null) return null;
            else return record;
        }
    }
}
