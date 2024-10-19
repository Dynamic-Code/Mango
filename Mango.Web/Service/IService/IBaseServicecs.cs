using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IBaseServicecs
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
