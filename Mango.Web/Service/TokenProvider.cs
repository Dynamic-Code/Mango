using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Newtonsoft.Json.Linq;

namespace Mango.Web.Service
{
    public class TokenProvider : ITokenProvider
    {
        // to work with cookies we need IHttpContextAccessor. it must be added in program.cs as well
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void ClearToken()
        {
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete(StaticDetails.TokenCookie);
        }

        public string GetToken()
        {
            string? token = null;
            bool? hasToken = 
                _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(StaticDetails.TokenCookie, out token);
            return hasToken is true? token : null;
        }

        //setting out token in cookies
        public void SetToken(string token)
        {
            _httpContextAccessor.HttpContext?.Response.Cookies.Append(StaticDetails.TokenCookie, token);
        }
    }
}
