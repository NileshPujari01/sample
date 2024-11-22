using System.Numerics;

namespace Koperasi.Application.Models.Response
{
    public class UserRegistrationResponse
    {
        public int CustomerUserId { get; set; }
        public string? CustomerName { get; set; }
        public BigInteger ICNumber { get; set; }
    }
}
