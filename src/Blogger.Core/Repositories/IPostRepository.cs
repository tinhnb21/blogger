using Blogger.Core.Domain.Content;
using Blogger.Core.Models;
using Blogger.Core.Models.Content;
using Blogger.Core.SeedWorks;

namespace Blogger.Core.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);
        Task<PagedResult<PostInListDto>> GetPostsPagingAsync(string? keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10);
    }
}
