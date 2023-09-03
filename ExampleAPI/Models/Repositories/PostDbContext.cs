using Microsoft.EntityFrameworkCore;

namespace ExampleAPI.Models.Repositories
{
    public class PostDbContext: DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext>
            options): base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
