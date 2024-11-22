using System.Numerics;

namespace Koperasi.Domain.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string? CustomerName { get; set; }
        public int ICNumber { get; set; }
        public string? CustomerMobileNo { get; set; }
        public string? CustomerEmailId { get; set; }
        public bool AgreePrivacyPolicy { get; set; }
        public int ApplicationPIN { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
