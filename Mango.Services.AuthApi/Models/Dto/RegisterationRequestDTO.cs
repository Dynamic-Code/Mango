﻿namespace Mango.Services.AuthApi.Models.Dto
{
    public class RegisterationRequestDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

    }
}