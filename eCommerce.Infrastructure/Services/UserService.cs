using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper ) {
            _userRepository=userRepository;
            _mapper=mapper;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser response = await _userRepository.GetUserByEmailAndPassword(loginRequest.email, loginRequest.password);
            if(response == null) return null;
            return _mapper.Map<AuthenticationResponse>(response) with { success = true, token = "Token" };
            //return new AuthenticationResponse(response.UserId,response.Email, response.PersonName,response.Gender,"token",true);
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            ApplicationUser response = await _userRepository.AddUser(new ApplicationUser()
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                PersonName = registerRequest.PersonName,
                Gender =registerRequest.Gender.ToString()
            });
            if (response == null) return null;
            return _mapper.Map<AuthenticationResponse>(response) with { success=true,token="Token"};
        }
    }
}
