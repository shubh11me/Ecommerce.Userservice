using eCommerce.Core.Entities;
namespace eCommerce.Core.RepositoryContracts
{
    /// <summary>
    /// Contract for UserRepository.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>The new user object including generated Guid</returns>
        Task<ApplicationUser?> AddUser(ApplicationUser user);

        /// <summary>
        /// Get User by email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>The user object (can be null)</returns>
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email,string? password);

        /// <summary>
        /// Get User by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ApplicationUser?> GetUserById(Guid? userId);
    }
}
