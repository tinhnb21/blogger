using Blogger.Core.Domain.Royalty;

namespace Blogger.Core.Services
{
    public interface IRoyaltyService
    {
        Task<List<RoyaltyReportByUserDto>> GetRoyaltyReportByUserAsync(string? username, int fromMonth, int fromYear, int toMonth, int toYear);
        Task<List<RoyaltyReportByMonthDto>> GetRoyaltyReportByMonthAsync(string? username, int fromMonth, int fromYear, int toMonth, int toYear);
        Task PayRoyaltyForUserAsync(Guid fromUserId, Guid toUserId);
    }
}

