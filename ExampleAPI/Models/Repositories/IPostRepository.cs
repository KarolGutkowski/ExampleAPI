namespace ExampleAPI.Models.Repositories;

public interface IPostRepository
{
    IEnumerable<Post> AllPosts { get; }
    IEnumerable<Post> GetPostById(int id);
    void AddPost(Post post);
}

