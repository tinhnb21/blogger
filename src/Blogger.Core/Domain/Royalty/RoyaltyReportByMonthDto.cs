﻿namespace Blogger.Core.Domain.Royalty
{
    public class RoyaltyReportByMonthDto
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int NumberOfDraftPosts { get; set; }
        public int NumberOfWaitingApprovalPosts { get; set; }
        public int NumberOfRejectedPosts { get; set; }

        public int NumberOfUnpaidPublishPosts { get; set; }
        public int NumberOfPaidPublishPosts { get; set; }
        public int NumberOfPublishPosts { get; set; }
    }
}
