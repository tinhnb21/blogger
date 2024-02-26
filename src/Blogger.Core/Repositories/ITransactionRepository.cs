using Blogger.Core.Models.Royalty;
using Blogger.Core.Models;
using Blogger.Core.SeedWorks;
using Blogger.Core.Domain.Royalty;

namespace Blogger.Core.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction, Guid>
    {
        Task<PagedResult<TransactionDto>> GetAllPaging(string? userName,
         int fromMonth, int fromYear, int toMonth, int toYear, int pageIndex = 1, int pageSize = 10);
    }
}
