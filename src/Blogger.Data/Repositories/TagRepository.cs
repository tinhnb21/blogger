using AutoMapper;
using Blogger.Core.Domain.Content;
using Blogger.Core.Models.Content;
using Blogger.Core.Repositories;
using Blogger.Data.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Data.Repositories
{
    public class TagRepository : RepositoryBase<Tag, Guid>, ITagRepository
    {
        private readonly IMapper _mapper;
        public TagRepository(BloggerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<TagDto?> GetBySlug(string slug)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Slug == slug);
            if (tag == null) return null;
            return _mapper.Map<TagDto?>(tag);
        }
    }
}
