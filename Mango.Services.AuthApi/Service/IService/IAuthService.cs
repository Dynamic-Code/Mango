using Mango.Services.AuthApi.Models.Dto;

namespace Mango.Services.AuthApi.Service.IService
{
    public interface IAuthService
    {
        Task<UserDTO> Register(RegisterationRequestDTO registerationRequestDTO);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
    }
}
