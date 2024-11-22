using Koperasi.Domain.Entities;
using Koperasi.Infrastructure.Abstractions.Base;

namespace Koperasi.Infrastructure.Abstractions
{
    public interface IUserRepository : IAsyncRepository<UserEntity>
    {
    }
}
