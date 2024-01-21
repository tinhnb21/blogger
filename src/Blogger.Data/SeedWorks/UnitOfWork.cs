using AutoMapper;
using Blogger.Core.Repositories;
using Blogger.Core.SeedWorks;
using Blogger.Data.Repositories;

namespace Blogger.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BloggerContext _context;
        public UnitOfWork(BloggerContext context, IMapper mapper)
        {
            _context = context;
            Posts = new PostRepository(context, mapper);
        }

        public IPostRepository Posts { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
