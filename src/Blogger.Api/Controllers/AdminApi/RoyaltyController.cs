using Blogger.Core.Domain.Royalty;
using Blogger.Core.Models.Royalty;
using Blogger.Core.Models;
using Blogger.Core.SeedWorks;
using Blogger.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Blogger.Core.SeedWorks.Contants.Permissions;
using Blogger.Api.Extensions;

namespace Blogger.Api.Controllers.AdminApi
{
    [Route("api/admin/royalty")]
    [ApiController]
    public class RoyaltyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoyaltyService _RoyaltyService;
        public RoyaltyController(IUnitOfWork unitOfWork, IRoyaltyService royaltyService)
        {
            _unitOfWork = unitOfWork;
            _RoyaltyService = royaltyService;
        }

        [HttpGet]
        [Route("transaction-histories")]
        [Authorize(Royalty.View)]
        public async Task<ActionResult<PagedResult<TransactionDto>>> GetTransactionHistory(string? keyword,
          int fromMonth, int fromYear, int toMonth, int toYear,
            int pageIndex, int pageSize = 10)
        {
            var result = await _unitOfWork.Transactions.GetAllPaging(keyword, fromMonth, fromYear, toMonth, toYear, pageIndex, pageSize);
            return Ok(result);
        }

        [HttpGet]
        [Route("Royalty-report-by-user")]
        [Authorize(Royalty.View)]
        public async Task<ActionResult<List<RoyaltyReportByUserDto>>> GetRoyaltyReportByUser(Guid? userId,
          int fromMonth, int fromYear, int toMonth, int toYear)
        {
            var result = await _RoyaltyService.GetRoyaltyReportByUserAsync(userId, fromMonth, fromYear, toMonth, toYear);
            return Ok(result);
        }

        [HttpGet]
        [Route("Royalty-report-by-month")]
        [Authorize(Royalty.View)]
        public async Task<ActionResult<List<RoyaltyReportByMonthDto>>> GetRoyaltyReportByMonth(Guid? userId,
         int fromMonth, int fromYear, int toMonth, int toYear)
        {
            var result = await _RoyaltyService.GetRoyaltyReportByMonthAsync(userId, fromMonth, fromYear, toMonth, toYear);
            return Ok(result);
        }

        [HttpPost]
        [Route("{userId}")]
        [Authorize(Royalty.Pay)]
        public async Task<IActionResult> PayRoyalty(Guid userId)
        {
            var fromUserId = User.GetUserId();
            await _RoyaltyService.PayRoyaltyForUserAsync(fromUserId, userId);
            return Ok();
        }

    }
}
