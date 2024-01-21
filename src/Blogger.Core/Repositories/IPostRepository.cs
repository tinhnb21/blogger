using Blogger.Core.Domain.Content;
using Blogger.Core.SeedWorks;

namespace Blogger.Core.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostAsync(int count);
    }
}
