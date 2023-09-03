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
            if(!_dbContext.Users.Any(p => p.Id == post.Author.Id))
            {
                _dbContext.Users.Add(post.Author);
            }

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }
    }
}
