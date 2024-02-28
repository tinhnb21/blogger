﻿using Blogger.Core.Models.Content;
using Blogger.Core.Models;

namespace Blogger.WebApp.Models
{
    public class PostListByTagViewModel
    {
        public TagDto Tag { get; set; }
        public PagedResult<PostInListDto> Posts { get; set; }
    }
}
