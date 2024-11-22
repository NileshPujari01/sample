using System.Numerics;

namespace Koperasi.API.Models.Request
{
    public class RegisterUserRequest
    {
        public string? CustomerName { get; set; }
        public int ICNumber { get; set; }
        public string? CustomerMobileNo { get; set; } //Considering string by taking consideration of international code as well
        public string? CustomerEmailId { get; set; }
        public bool AgreePrivacyPolicy { get; set; }
        public int ApplicationPIN { get; set; }
    }
}
