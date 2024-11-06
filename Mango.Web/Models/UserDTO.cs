namespace Mango.Web.Models.Dto
{
    // ASPNETUSER identity table a lot of col. 
    // we are adding only that we need
    public class UserDTO
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
