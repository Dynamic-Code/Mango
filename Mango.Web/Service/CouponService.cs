using Mango.Web.Models;
using Mango.Web.Service.IService;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        //Added BaseCoupon Service to call all APIs
        public readonly IBaseServicecs BaseServicecs;
        public CouponService(IBaseServicecs baseServicecs)
        {
            BaseServicecs = baseServicecs;
        }

        public Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {

        }

        public Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetAllCouponAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }
    }
}
