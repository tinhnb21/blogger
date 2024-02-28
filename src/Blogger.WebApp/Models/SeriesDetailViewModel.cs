using Blogger.Core.Models.Content;
using Blogger.Core.Models;

namespace Blogger.WebApp.Models
{
    public class SeriesDetailViewModel
    {
        public SeriesDto Series { get; set; }

        public PagedResult<PostInListDto> Posts { get; set; }
    }
}
