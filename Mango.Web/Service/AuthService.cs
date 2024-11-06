using Mango.Web.Models;
using Mango.Web.Models.Dto;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseServicecs _baseService;
        public AuthService(IBaseServicecs baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> AssignedRoleAsync(RegisterationRequestDTO registerationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.POST,
                Url = StaticDetails.AuthAPIBase + "/api/auth/AssignedRole",
                Data = registerationRequestDTO
            });
        }

        public async Task<ResponseDto> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.POST,
                Url = StaticDetails.AuthAPIBase + "/api/auth/login",
                Data = loginRequestDTO
            });
        }

        public async Task<ResponseDto> RegisterAsync(RegisterationRequestDTO registerationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = StaticDetails.ApiType.POST,
                Url = StaticDetails.AuthAPIBase + "/api/auth/register",
                Data = registerationRequestDTO
            });
        }
    }
}
