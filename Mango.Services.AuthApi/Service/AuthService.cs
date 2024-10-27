using Mango.Services.AuthApi.Data;
using Mango.Services.AuthApi.Models;
using Mango.Services.AuthApi.Models.Dto;
using Mango.Services.AuthApi.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthApi.Service
{
    public class AuthService : IAuthService
    {

        private readonly AppDbContext _db;
        //to do all login and register

        private readonly UserManager<ApplicationUser> _userManager;
        //To work with roles

        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(AppDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            ApplicationUser user = new()
            {
                Name = registerationRequestDTO.Name,
                Email = registerationRequestDTO.Email,
                NormalizedEmail = registerationRequestDTO.Email.ToUpper(),
                UserName = registerationRequestDTO.Email,
                PhoneNumber = registerationRequestDTO.PhoneNumber,
            };

            try
            {
                // this will automatically the user and hashing password and all will be done by dotnet Identity
                var result = await _userManager.CreateAsync(user, registerationRequestDTO.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registerationRequestDTO.Email);

                    UserDTO userDTO = new UserDTO()
                    {
                        Email = userToReturn.Email,
                        ID = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };

                    return userDTO;
                }
            }
            catch (Exception ex)
            {
                return new UserDTO();
            }
        }
    }
}
