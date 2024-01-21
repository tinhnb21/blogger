using Blogger.Core.Domain.Content;
using Blogger.Core.Repositories;
using Blogger.Data.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post, Guid>, IPostRepository
    {
        public PostRepository(BloggerContext context) : base(context)
        {
        }

        public Task<List<Post>> GetPopularPostAsync(int count)
        {
            return _context.Posts.OrderByDescending(x => x.ViewCount).Take(count).ToListAsync();
        }
    }
}
