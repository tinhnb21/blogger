using Blogger.Core.Domain.Identity;
using Blogger.Core.SeedWorks;

namespace Blogger.Core.Repositories
{
    public interface IUserRepository : IRepository<AppUser, Guid>
    {
        Task RemoveUserFromRoles(Guid userId, string[] roles);
    }
}
