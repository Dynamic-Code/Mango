namespace Mango.Services.CouponAPI.Models.Dto
{
    //It is a general dto class for all the response from our endpoint
    //Common response for all our API
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
