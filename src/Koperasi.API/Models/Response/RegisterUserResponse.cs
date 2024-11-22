using System.Numerics;

namespace Koperasi.API.Models.Response
{
    public class RegisterUserResponse
    {
        public int CustomerUserId { get; set; }
        public string? CustomerName { get; set; }
        public BigInteger ICNumber { get; set; }
        public int MobileNoOTP { get; set; }
        public int EmailIdOTP { get; set; }
    }
}
