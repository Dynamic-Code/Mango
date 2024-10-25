using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        // fetcing all coupon
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();
            ResponseDto? res = await _couponService.GetAllCouponAsync();

            if (res != null && res.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(res.Result));
            }
            else
            {
                TempData["error"] = res?.Message;
            }
            return View(list);
        }

        // creating new coupon view 
        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        // creating new coupon http call
        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? res = await _couponService.CreateCouponAsync(couponDto);

                if (res != null && res.IsSuccess)
                {
                    TempData["success"] = "Coupon created successfully";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = res?.Message;
                }
            }
            return View(couponDto);
        }

        //deleting coupon view
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto? res = await _couponService.GetCouponByIdAsync(couponId);

            if (res != null && res.IsSuccess)
            {
                CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(res.Result));
                return View(model);
            }
            return NotFound();
        }

        //delete action method
        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {
            ResponseDto? res = await _couponService.DeleteCouponAsync(couponDto.CouponId);

            if (res != null && res.IsSuccess)
            {
                TempData["success"] = "Coupon deleted successfully";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = res?.Message;
            }
            return NotFound();
        }
    }
}
