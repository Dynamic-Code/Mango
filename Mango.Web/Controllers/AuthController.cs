using Mango.Web.Models;
using Mango.Web.Models.Dto;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO loginRequestDTO = new ();
            return View(loginRequestDTO);   
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO obj)
        {
            ResponseDto responseDto = await _authService.LoginAsync(obj);

            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDTO loginResponseDTO = 
                    JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(responseDto.Result));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", responseDto.Message);
                return View(obj);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text = StaticDetails.RoleAdmin,Value = StaticDetails.RoleAdmin},
                new SelectListItem{Text = StaticDetails.RoleCust,Value = StaticDetails.RoleCust}
            };

            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterationRequestDTO obj)
        {
            ResponseDto result = await _authService.RegisterAsync(obj);
            ResponseDto assignRole;
            if(result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(obj.Role))
                {
                    obj.Role = StaticDetails.RoleCust;
                }
                assignRole = await _authService.AssignedRoleAsync(obj);
                if (assignRole!= null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Registeration Successfull";
                    return RedirectToAction(nameof(Login));
                }
            }
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text = StaticDetails.RoleAdmin,Value = StaticDetails.RoleAdmin},
                new SelectListItem{Text = StaticDetails.RoleCust,Value = StaticDetails.RoleCust}
            };
            ViewBag.RoleList = roleList;
            return View(obj);
        }

        public IActionResult Logout()
        {
            return View();
        }

    }
}
