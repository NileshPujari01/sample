namespace Koperasi.Application.Models.Request
{
    /// <summary>
    /// User Registration Model
    /// </summary>
    public class UserRegistrationRequest
    {
        public string? CustomerName { get; set; }
        public int ICNumber { get; set; }
        public string? CustomerMobileNo { get; set; } //Considering string by taking consideration of international code as well
        public string? CustomerEmailId { get; set; }
        public bool AgreePrivacyPolicy { get; set; }
        public bool IsVerified { get; set; }
        public int ApplicationPIN { get; set; }
    }
}
