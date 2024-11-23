using Koperasi.Domain.Entities;
using Koperasi.Infrastructure.Abstractions.Base;

namespace Koperasi.Infrastructure.Abstractions
{
    /// <summary>
    /// User Repository declaration
    /// </summary>
    public interface IUserRepository : IAsyncRepository<UserEntity>
    {
    }
}
