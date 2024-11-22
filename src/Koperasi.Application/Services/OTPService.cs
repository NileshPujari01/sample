using Koperasi.Infrastructure.Abstractions;

namespace Koperasi.Infrastructure.Services
{
    public class OTPService : IOTPService
    {
        public async Task<int> SendOTPOverEmail(string emailId)
        {
            return await GenerateRandomNumber();
        }

        public async Task<int> SendOTPOverMobile(string mobileno)
        {
            return await GenerateRandomNumber();
        }

        private async Task<int> GenerateRandomNumber()
        {
            int num = new Random().Next(1000, 9999);
            return num;
        }
    }
}
