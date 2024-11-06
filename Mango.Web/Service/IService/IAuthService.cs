using Mango.Web.Models;
using Mango.Web.Models.Dto;

namespace Mango.Web.Service.IService
{
    //Interface to call Auth project api
    public interface IAuthService
    {
        Task<ResponseDto> LoginAsync(LoginRequestDTO loginRequestDTO);
        Task<ResponseDto> RegisterAsync(RegisterationRequestDTO registerationRequestDTO);
        Task<ResponseDto> AssignedRoleAsync(RegisterationRequestDTO registerationRequestDTO);
    }
}
