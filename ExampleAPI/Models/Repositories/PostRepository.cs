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

        public Post GetPostById(int id)
        {
            return _dbContext.Posts
                .Where(post => post.Id == id)
                .Include(a => a.Author)
                .Single();
        }

        public void AddPost(Post post)
        {
            if(_dbContext.Users.Any(p => p.Name == post.Author.Name))
            {
                post.Author = _dbContext.Users
                    .First(a => a.Name == post.Author.Name);
            }

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }
    }
}
