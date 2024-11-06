using Mango.Services.AuthApi.Models.Dto;

namespace Mango.Services.AuthApi.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegisterationRequestDTO registerationRequestDTO);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<bool> AssignedRole(string email, string roleName);
    }
}
