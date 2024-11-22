using System.Numerics;

namespace Koperasi.Application.Models.Response
{
    public class UserLoginResponse
    {
        public int CustomerUserId { get; set; }
        public string? CustomerName { get; set; }
        public BigInteger ICNumber { get; set; }
        public string? CustomerMobileNo { get; set; }
        public string? CustomerEmailId { get; set; }
    }
}
