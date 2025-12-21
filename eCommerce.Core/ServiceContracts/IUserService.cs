using eCommerce.Core.DTO;
namespace eCommerce.Core.ServiceContracts
{
    /// <summary>
    /// Contracts for User services
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Method to return the Authentication Result after auth operation.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
        /// <summary>
        /// Method to handle the registration process.
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    }
}
