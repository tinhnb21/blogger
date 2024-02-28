using Blogger.Core.Domain.Content;
using Blogger.Core.Models.Content;
using Blogger.Core.SeedWorks;

namespace Blogger.Core.Repositories
{
    public interface ITagRepository : IRepository<Tag, Guid>
    {
        Task<TagDto> GetBySlug(string slug);
    }
}
