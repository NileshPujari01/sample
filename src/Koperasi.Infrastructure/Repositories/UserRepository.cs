using Koperasi.Domain.Entities;
using Koperasi.Infrastructure.Abstractions;
using Koperasi.Infrastructure.Persistence;
using Koperasi.Infrastructure.Repositories.Base;

namespace Koperasi.Infrastructure.Repositories
{
    /// <summary>
    /// User Repository implementation
    /// </summary>
    public class UserRepository : RepositoryBase<UserEntity, DataContext>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
