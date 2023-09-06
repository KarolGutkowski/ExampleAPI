namespace ExampleAPI.Models.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll { get; }
        User? GetById(int id);
        IEnumerable<User> GetByName(string name);
        void AddUser(User user);
    }
}
