using AutoMapper;
using Blogger.Core.Domain.Identity;
using Blogger.Core.Repositories;
using Blogger.Core.SeedWorks;
using Blogger.Data.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Blogger.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BloggerContext _context;
        public UnitOfWork(BloggerContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            Posts = new PostRepository(context, mapper, userManager);
            PostCategories = new PostCategoryRepository(context, mapper);
            Series = new SeriesRepository(context, mapper);
            Transactions = new TransactionRepository(context, mapper);
            Users = new UserRepository(context);
        }

        public IPostRepository Posts { get; private set; }

        public IPostCategoryRepository PostCategories { get; private set; }

        public ISeriesRepository Series { get; private set; }

        public ITransactionRepository Transactions { get; private set; }

        public IUserRepository Users { get; private set; }

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
