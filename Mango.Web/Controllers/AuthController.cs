﻿using Mango.Web.Models.Dto;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }

    }
}
