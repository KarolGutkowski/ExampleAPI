using Microsoft.EntityFrameworkCore;

namespace ExampleAPI.Models.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PostDbContext _dbContext;

        public PostRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Post> AllPosts => 
            _dbContext.Posts
            .Include(a => a.Author);

        public IEnumerable<Post> GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddPost(Post post)
        {
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }
    }
}
