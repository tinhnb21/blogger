using Blogger.Core.Models.Content;
using Blogger.Core.Models;

namespace Blogger.WebApp.Models
{
    public class PostListByCategoryViewModel
    {
        public PostCategoryDto Category { get; set; }
        public PagedResult<PostInListDto> Posts { get; set; }
    }
}
