using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Blogger.Data
{
    public class BloggerContextFactory : IDesignTimeDbContextFactory<BloggerContext>
    {
        public BloggerContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<BloggerContext>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new BloggerContext(builder.Options);
        }
    }
}
