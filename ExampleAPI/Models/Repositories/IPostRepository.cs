namespace ExampleAPI.Models.Repositories;

public interface IPostRepository
{
    IEnumerable<Post> AllPosts { get; }
    Post GetPostById(int id);
    void AddPost(Post post);
}

