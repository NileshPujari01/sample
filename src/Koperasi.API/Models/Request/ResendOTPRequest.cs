namespace Koperasi.API.Models.Request
{
    public class ResendOTPRequest
    {
        public string? CustomerEmailId { get; set; }
        public string? CustomerMobileNo { get; set; }
    }
}
