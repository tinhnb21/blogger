using Blogger.Core.Domain.Content;
using Blogger.Core.Models;
using Blogger.Core.Models.Content;
using Blogger.Core.SeedWorks;

namespace Blogger.Core.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory, Guid>
    {
        Task<PagedResult<PostCategoryDto>> GetAllPaging(string? keyword, int pageIndex = 1, int pageSize = 10);
        Task<bool> HasPost(Guid categoryId);
    }
}
