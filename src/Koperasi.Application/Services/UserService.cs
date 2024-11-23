using AutoMapper;
using Koperasi.Application.Interfaces;
using Koperasi.Application.Models.Request;
using Koperasi.Application.Models.Response;
using Koperasi.Domain.Entities;
using Koperasi.Infrastructure.Abstractions;
using Koperasi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Koperasi.Application.Services
{
    /// <summary>
    /// Service to manage all operations of user
    /// </summary>
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _registerUserRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public UserService(
            ILogger<UserService> logger,
            IUserRepository registerUserRepository,
            IMapper mapper,
            IConnectionStringProvider connectionStringProvider
            )
        {
            _logger = logger;
            _registerUserRepository = registerUserRepository;
            _mapper = mapper;
            _dataContext = new DataContext(new DbContextOptions<DataContext>(), connectionStringProvider);
        }

        /// <summary>
        /// Method to manage user registration
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns>UserRegistrationResponse</returns>
        public async Task<UserRegistrationResponse> RegisterUser(UserRegistrationRequest registerRequest)
        {
            var request = _mapper.Map<UserEntity>(registerRequest);
            var dbResponse = await _registerUserRepository.AddAsync(request);
            var response = _mapper.Map<UserRegistrationResponse>(dbResponse);
            return response;
        }

        /// <summary>
        /// Method to manage user login
        /// </summary>
        /// <param name="userLoginRequest"></param>
        /// <returns>UserLoginResponse</returns>
        public async Task<UserLoginResponse> UserLogin(UserLoginRequest userLoginRequest)
        {
            var request = _mapper.Map<UserEntity>(userLoginRequest);
            var dbResponse = await _registerUserRepository.GetAsync(x => x.ICNumber == userLoginRequest.ICNumber);
            var response = _mapper.Map<UserLoginResponse>(dbResponse);
            return response;
        }
    }
}
