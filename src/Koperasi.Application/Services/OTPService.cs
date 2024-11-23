using Koperasi.Infrastructure.Abstractions;

namespace Koperasi.Infrastructure.Services
{
    /// <summary>
    /// Service to handle all operations regarding OTP sending over mobile / email
    /// </summary>
    public class OTPService : IOTPService
    {
        /// <summary>
        /// Sends OTP over email
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns>4 digit code</returns>
        public async Task<int> SendOTPOverEmail(string emailId)
        {
            //Here we will be sending OTP over email via SMTP / AWS SES
            return await GenerateRandomNumber();
        }

        /// <summary>
        /// Sends OTP over mobile
        /// </summary>
        /// <param name="mobileno"></param>
        /// <returns>4 digit code</returns>
        public async Task<int> SendOTPOverMobile(string mobileno)
        {
            //Here we will be sending OTP over mobile. It will required 3rd party API to manage OTP and TRI rules
            return await GenerateRandomNumber();
        }

        /// <summary>
        /// Generating random number
        /// </summary>
        /// <returns>4 digit code</returns>
        private async Task<int> GenerateRandomNumber()
        {
            int num = new Random().Next(1000, 9999);
            return num;
        }
    }
}
