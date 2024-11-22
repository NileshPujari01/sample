namespace Koperasi.Infrastructure.Abstractions
{
    public interface IOTPService
    {
        public Task<int> SendOTPOverEmail(string emailId);
        public Task<int> SendOTPOverMobile(string mobileno);
    }
}
