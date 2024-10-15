using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ResponseDto _responseDto;
        public CouponApiController(AppDbContext appDbContext)
        {
            _context = appDbContext;
            _responseDto = new ResponseDto();

        }

        [HttpGet]
        public ResponseDto Get() 
        
        {
            try
            {
                IEnumerable<Coupon> obj = _context.Coupons.ToList();
                _responseDto.Result = obj;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }



        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)

        {
            try
            {
                Coupon obj = _context.Coupons.First(u=>u.CouponId == id);
                _responseDto.Result = obj;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
