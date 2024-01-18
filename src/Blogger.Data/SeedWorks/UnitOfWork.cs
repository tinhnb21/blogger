using Blogger.Core.SeedWorks;

namespace Blogger.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BloggerContext _context;
        public UnitOfWork(BloggerContext context)
        {
            _context = context;
        }

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
