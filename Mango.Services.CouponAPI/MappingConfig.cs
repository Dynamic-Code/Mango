using AutoMapper;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;

namespace Mango.Services.CouponAPI
{
    //Adding AutoMapper Config
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            //when property name is same, it will do the mapping itself
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>(); // (source,destination)
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
