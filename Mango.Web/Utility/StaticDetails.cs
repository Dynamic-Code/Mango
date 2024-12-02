namespace Mango.Web.Utility
{
    public class StaticDetails
    {
        public static string AuthAPIBase { get; set; }
        public static string CouponAPIBase { get; set; }
        public const string RoleAdmin = "ADMIN";
        public const string RoleCust = "CUSTOMER";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
