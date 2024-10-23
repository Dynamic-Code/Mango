using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/Coupon")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ResponseDto _responseDto;
        private IMapper _mapper;
        public CouponApiController(AppDbContext appDbContext, IMapper mapper)
        {
            _context = appDbContext;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()

        {
            try
            {
                IEnumerable<Coupon> objList = _context.Coupons.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(objList); //mappig Coupon obj to couponDto 
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
                Coupon obj = _context.Coupons.First(u => u.CouponId == id);
                _responseDto.Result = _mapper.Map<CouponDto>(obj); //mappig Coupon obj to couponDto 
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)

        {
            try
            {
                Coupon obj = _context.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());
                _responseDto.Result = _mapper.Map<CouponDto>(obj); //mappig Coupon obj to couponDto 
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)

        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto); //mappig couponDto to Coupon obj
                _context.Coupons.Add(obj);
                _context.SaveChanges();

                _responseDto.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)

        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto); //mappig couponDto to Coupon obj
                _context.Coupons.Update(obj);
                _context.SaveChanges();

                _responseDto.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpDelete]
        public ResponseDto Delete(int id)

        {
            try
            {
                Coupon obj = _context.Coupons.FirstOrDefault(u => u.CouponId == id);
                _context.Coupons.Remove(obj);
                _context.SaveChanges();

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
